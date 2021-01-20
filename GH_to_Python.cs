using System;
using System.Collections;
using System.Collections.Generic;

using Rhino;
using Rhino.Geometry;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

using System.IO;

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
  private void RunScript(string x, string y, string z, string u, string v, ref object A)
  {

    System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

    //strCommand is path and file name of command to run
    pProcess.StartInfo.FileName = "cmd.exe";

    string result = Path.GetTempPath();

    string file_path_vertices = result + "vertices.txt";
    string file_path_faces = result + "faces.txt";

    File.WriteAllText(file_path_vertices, x);
    File.WriteAllText(file_path_faces, y);

    string env = Environment.GetEnvironmentVariable("AppData");

    //strCommandParameters are parameters to pass to program
    // the @ is to make sure the / is not an exit littoral
    // the /c is to carry out the command specified by the string and then terminate
    pProcess.StartInfo.Arguments = @"/c" + env + "/Grasshopper/Libraries/Conformal_Mapping/Conformal_Mapping_py.exe " + file_path_vertices + " " + file_path_faces + " " + z + " " + u + " " + v;

    pProcess.StartInfo.UseShellExecute = false;

    //Set output of program to be written to process output stream
    pProcess.StartInfo.RedirectStandardOutput = true;

    //Optional
    //pProcess.StartInfo.WorkingDirectory = strWorkingDirectory;

    pProcess.StartInfo.CreateNoWindow = true;

    //Start the process
    pProcess.Start();

    //Get program output
    string strOutput = pProcess.StandardOutput.ReadToEnd();

    //Wait for process to finish
    pProcess.WaitForExit();

    File.Delete(file_path_vertices);
    File.Delete(file_path_faces);

    Print(strOutput);

  }

  // <Custom additional code> 

  // </Custom additional code> 
}
