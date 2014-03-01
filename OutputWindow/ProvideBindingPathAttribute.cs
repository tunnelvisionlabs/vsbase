namespace Tvl.VisualStudio.OutputWindow
{
    using System;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This attribute registers a path that should be probed for candidate assemblies at assembly load time.
    /// 
    /// For example:
    ///   [...\VisualStudio\10.0\BindingPaths\{5C48C732-5C7F-40f0-87A7-05C4F15BC8C3}]
    ///     "$PackageFolder$"=""
    ///     
    /// This would register the "PackageFolder" (i.e. the location of the pkgdef file) as a directory to be probed
    /// for assemblies to load.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    internal sealed class ProvideBindingPathAttribute : RegistrationAttribute
    {
        private static string GetPathToKey(RegistrationContext context)
        {
            return string.Concat(@"BindingPaths\", context.ComponentType.GUID.ToString("B").ToUpperInvariant());
        }

        public override void Register(RegistrationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            using (Key childKey = context.CreateKey(GetPathToKey(context)))
            {
                childKey.SetValue(context.ComponentPath, string.Empty);
            }
        }

        public override void Unregister(RegistrationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.RemoveKey(GetPathToKey(context));
        }
    }
}
