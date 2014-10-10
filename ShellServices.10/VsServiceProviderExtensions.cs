namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Diagnostics.Contracts;
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
    public static partial class VsServiceProviderExtensions
    {
#if false // this service needs to be provided through a "ShellServices.10Only" assembly...
        public static ICallHierarchy GetCallHierarchy(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SCallHierarchy, ICallHierarchy>();
        }
#endif

        /// <summary>
        /// Gets the global <see cref="IComponentModel"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IComponentModel"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IComponentModel GetComponentModel(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SComponentModel, IComponentModel>();
        }

#if false
        // DTE shouldn't be Dte
        [SuppressMessage("Microsoft.Naming", "CA1709")]
        public static DTE GetDTE(this SVsServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new ArgumentNullException("serviceProvider"); Contract.EndContractBlock();
            {
                return serviceProvider.GetService<EnvDTE._DTE, DTE>();
            }
        }

        // DTE2 shouldn't be Dte2
        [SuppressMessage("Microsoft.Naming", "CA1709")]
        public static DTE2 GetDTE2(this SVsServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new ArgumentNullException("serviceProvider"); Contract.EndContractBlock();
            {
                return serviceProvider.GetService<EnvDTE._DTE, DTE2>();
            }
        }
#endif

        /// <summary>
        /// Gets the global <see cref="IGlyphService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IGlyphService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static IGlyphService GetGlyphService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetComponentModel().GetService<IGlyphService>();
        }
    }
}
