using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if DEV10
[assembly: AssemblyTitle("Tvl.VisualStudio.ShellServices.10")]
[assembly: AssemblyProduct("Tvl.VisualStudio.ShellServices.10")]
#elif DEV11
[assembly: AssemblyTitle("Tvl.VisualStudio.ShellServices.11")]
[assembly: AssemblyProduct("Tvl.VisualStudio.ShellServices.11")]
#elif DEV12
[assembly: AssemblyTitle("Tvl.VisualStudio.ShellServices.12")]
[assembly: AssemblyProduct("Tvl.VisualStudio.ShellServices.12")]
#else
#error Unknown target version.
#endif
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Tunnel Vision Laboratories, LLC")]
[assembly: AssemblyCopyright("Copyright © Sam Harwell 2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("68ce578a-3be8-450c-bc85-7490971f9cd4")]

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
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0-dev")]
