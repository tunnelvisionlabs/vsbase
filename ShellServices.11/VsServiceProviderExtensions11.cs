namespace Tvl.VisualStudio.Shell
{
    using System;
    using Microsoft.VisualStudio.ComponentModelHost;
    using Microsoft.VisualStudio.Shell;
    using IGlyphService = Microsoft.VisualStudio.Language.Intellisense.IGlyphService;
#if false
    using Microsoft.VisualStudio.CallHierarchy.Package.Definitions;
#endif

    /// <summary>
    /// Provides extension methods for <see cref="SVsServiceProvider"/>, primarily
    /// for easy access to the various global services provided by Visual Studio.
    /// </summary>
    /// <threadsafety/>
    public static partial class VsServiceProviderExtensions11
    {
#if false // this service needs to be provided through a "ShellServices.11Only" assembly...
        public static ICallHierarchy GetCallHierarchy(this SVsServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            return serviceProvider.GetService<SCallHierarchy, ICallHierarchy>();
        }
#endif
    }
}
