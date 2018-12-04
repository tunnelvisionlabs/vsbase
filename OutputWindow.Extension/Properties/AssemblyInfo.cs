using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Tvl.VisualStudio.OutputWindow")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Tunnel Vision Laboratories, LLC")]
[assembly: AssemblyProduct("Tvl.VisualStudio.OutputWindow")]
[assembly: AssemblyCopyright("Copyright © Sam Harwell 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: Guid("AFEED8FC-7461-4CC2-821C-8163AAAD30C6")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("3.1.0.0")]
[assembly: AssemblyFileVersion("3.1.0.0")]
[assembly: AssemblyInformationalVersion("3.1.0")]

[assembly: ProvideCodeBase(
    AssemblyName = "Tvl.VisualStudio.OutputWindow.Implementation",
    Version = "3.1.0.0",
    CodeBase = "$PackageFolder$\\Tvl.VisualStudio.OutputWindow.Implementation.dll")]
[assembly: ProvideCodeBase(
    AssemblyName = "Tvl.VisualStudio.OutputWindow.Interfaces",
    Version = "2.0.0.0",
    CodeBase = "$PackageFolder$\\Tvl.VisualStudio.OutputWindow.Interfaces.dll")]
[assembly: ProvideCodeBase(
    AssemblyName = "Tvl.VisualStudio.ShellServices.10",
    Version = "2.0.0.0",
    CodeBase = "$PackageFolder$\\Tvl.VisualStudio.ShellServices.10.dll")]
