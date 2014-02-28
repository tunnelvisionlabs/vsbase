namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TextManager.Interop;

    partial class VsServiceProviderExtensions
    {
        /// <summary>
        /// Gets the global <see cref="IVsExpansionManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsExpansionManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static IVsExpansionManager GetExpansionManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");

            IVsExpansionManager expMgr;
            var tmgr = serviceProvider.GetTextManager() as IVsTextManager2;
            if (tmgr != null && ErrorHandler.Succeeded(tmgr.GetExpansionManager(out expMgr)))
                return expMgr;

            return null;
        }

        /// <summary>
        /// Gets the global <see cref="IVsTextManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTextManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static IVsTextManager GetTextManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<VsTextManagerClass, IVsTextManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTextManager2"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTextManager2"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static IVsTextManager2 GetTextManager2(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<VsTextManagerClass, IVsTextManager2>();
        }
    }
}
