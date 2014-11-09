namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// Registers a path that should be probed for candidate assemblies at assembly load time.
    /// </summary>
    /// <remarks>
    /// <note type="note">
    /// <para>This attribute may only be used in an assembly which has a <see cref="GuidAttribute"/> applied to the
    /// assembly.</para>
    /// </note>
    /// <para>
    /// This attribute registers a path that should be probed for candidate assemblies at assembly load time. For
    /// example, the following would register the "PackageFolder" (i.e. the location of the pkgdef file) as a directory
    /// to be probed for assemblies to load.
    /// </para>
    /// <code language="none">
    /// [...\VisualStudio\10.0\BindingPaths\{5C48C732-5C7F-40f0-87A7-05C4F15BC8C3}]
    /// "$PackageFolder$"=""
    /// </code>
    /// <para>Extensions which are compiled using Visual Studio 2012+ may apply this attribute to the assembly.
    /// Extensions which are compiled using Visual Studio 2010 (including for testing purposes) must apply this
    /// attribute to a class. In either case, the output produced by the attribute is equivalent.</para>
    /// <code language="cs">
    /// <![CDATA[
    /// // This attribute is placed on a class due to a limitation in the Visual Studio 2010 SDK.
    /// [ProvideBindingPath]
    /// internal sealed class RegistrationClass { }
    /// ]]>
    /// </code>
    /// </remarks>
    /// <threadsafety static="true" instance="false"/>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ProvideBindingPathAttribute : RegistrationAttribute
    {
        private static string GetPathToKey(RegistrationContext context)
        {
            Guid componentGuid = GetAssemblyGuid(context.CodeBase);
            return string.Concat(@"BindingPaths\", componentGuid.ToString("B").ToUpperInvariant());
        }

        private static Guid GetAssemblyGuid(string codeBase)
        {
            string assemblyFile = new Uri(codeBase).LocalPath;
            Assembly assembly = Assembly.LoadFrom(codeBase);
            object[] attributesData = assembly.GetCustomAttributes(typeof(GuidAttribute), false);
            if (attributesData.Length == 0)
                throw new ArgumentException("The specified assembly did not contain a [Guid] attribute.");

            return new Guid(((GuidAttribute)attributesData[0]).Value);
        }

        /// <inheritdoc/>
        public override void Register(RegistrationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            using (Key childKey = context.CreateKey(GetPathToKey(context)))
            {
                childKey.SetValue(context.ComponentPath, string.Empty);
            }
        }

        /// <inheritdoc/>
        public override void Unregister(RegistrationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.RemoveKey(GetPathToKey(context));
        }
    }
}
