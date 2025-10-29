using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;



/// <summary>
/// This class will be instantiated on demand by the Script component.
/// </summary>
public class Script_Instance : GH_ScriptInstance
{
#region Utility functions
  /// <summary>Print a String to the [Out] Parameter of the Script component.</summary>
  /// <param name="text">String to print.</param>
  private void Print(string text) { /* Implementation hidden. */ }
  /// <summary>Print a formatted String to the [Out] Parameter of the Script component.</summary>
  /// <param name="format">String format.</param>
  /// <param name="args">Formatting parameters.</param>
  private void Print(string format, params object[] args) { /* Implementation hidden. */ }
  /// <summary>Print useful information about an object instance to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj) { /* Implementation hidden. */ }
  /// <summary>Print the signatures of all the overloads of a specific method to the [Out] Parameter of the Script component. </summary>
  /// <param name="obj">Object instance to parse.</param>
  private void Reflect(object obj, string method_name) { /* Implementation hidden. */ }
#endregion

#region Members
  /// <summary>Gets the current Rhino document.</summary>
  private readonly RhinoDoc RhinoDocument;
  /// <summary>Gets the Grasshopper document that owns this script.</summary>
  private readonly GH_Document GrasshopperDocument;
  /// <summary>Gets the Grasshopper script component that owns this script.</summary>
  private readonly IGH_Component Component;
  /// <summary>
  /// Gets the current iteration count. The first call to RunScript() is associated with Iteration==0.
  /// Any subsequent call within the same solution will increment the Iteration count.
  /// </summary>
  private readonly int Iteration;
#endregion

  /// <summary>
  /// This procedure contains the user code. Input parameters are provided as regular arguments,
  /// Output parameters as ref arguments. You don't have to assign output parameters,
  /// they will have a default value.
  /// </summary>
  private void RunScript(string ClusterName, string NewPassword, bool Run, ref object Report)
  {

  }

  // <Custom additional code> 
  // Inputs: ClusterName (string), NewPassword (string), Run (bool)
  // Output: Report (string)

  // Inputs: ClusterName (string), NewPassword (string), Run (bool)
  // Output: Report (string)

  void RunScript(string ClusterName, string NewPassword, bool Run, ref object Report)
  {
    if (!Run)
    {
      Report = "Idle. Toggle Run = true to execute.";
      return;
    }
    if (string.IsNullOrWhiteSpace(NewPassword))
    {
      Report = "NewPassword is empty. Aborting.";
      return;
    }

    try
    {
      Grasshopper.Kernel.GH_Document doc = GrasshopperDocument;
      if (doc == null) { Report = "No active Grasshopper document."; return; }

      // 1) Locate target cluster by NickName or by selection
      Grasshopper.Kernel.GH_Cluster target = null;

      if (!string.IsNullOrWhiteSpace(ClusterName))
      {
        foreach (var obj in doc.Objects)
        {
          var cl = obj as Grasshopper.Kernel.GH_Cluster;
          if (cl != null && string.Equals(cl.NickName, ClusterName, System.StringComparison.OrdinalIgnoreCase))
          {
            target = cl; break;
          }
        }
      }
      if (target == null)
      {
        foreach (var obj in doc.Objects)
        {
          var cl = obj as Grasshopper.Kernel.GH_Cluster;
          if (cl != null && cl.Attributes.Selected)
          {
            target = cl; break;
          }
        }
      }
      if (target == null)
      {
        Report = "No GH_Cluster found. Set ClusterName or select a cluster and re-run.";
        return;
      }

      // 2) Reflect the private password field
      System.Type tCluster = typeof(Grasshopper.Kernel.GH_Cluster);
      var pwField = tCluster.GetField("m_password",
        System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

      if (pwField == null)
      {
        foreach (var f in tCluster.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
        {
          if (f.FieldType == typeof(byte[]) && f.Name.ToLowerInvariant().Contains("pass"))
          { pwField = f; break; }
        }
      }
      if (pwField == null)
      {
        Report = "Could not locate the private password field on GH_Cluster (API change?).";
        return;
      }

      // 3) Synthesize correct byte[] for the new password via a temporary cluster
      byte[] newPwBytes = null;
      try
      {
        var temp = System.Activator.CreateInstance(tCluster) as Grasshopper.Kernel.GH_Cluster;
        var assign = tCluster.GetMethod("AssignNewPassword",
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic,
          null,
          new System.Type[] { typeof(string), typeof(string) },
          null);

        if (assign != null)
        {
          assign.Invoke(temp, new object[] { null, NewPassword });
          newPwBytes = (byte[]) pwField.GetValue(temp);
        }
      }
      catch { newPwBytes = null; }

      if (newPwBytes == null || newPwBytes.Length == 0)
      {
        Report = "Could not synthesize password bytes (AssignNewPassword not available on this build).";
        return;
      }

      // 4) Write new bytes into the target cluster and expire
      pwField.SetValue(target, newPwBytes);
      target.ExpireSolution(true);
      doc.ExpireSolution();

      Report = "Success. The target cluster now accepts the new password.";
    }
    catch (System.Reflection.TargetInvocationException tie)
    {
      Report = "Invocation error: " + (tie.InnerException != null ? tie.InnerException.Message : tie.Message);
    }
    catch (System.Exception ex)
    {
      Report = "Error: " + ex.Message;
    }
  }

  // </Custom additional code> 
}