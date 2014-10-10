namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    partial class VsServiceProviderExtensions12
    {
        /// <summary>
        /// Gets the global <see cref="IVsLongIdleManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsLongIdleManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsLongIdleManager GetLongIdleManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsLongIdleManager, IVsLongIdleManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsProjectMRU"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsProjectMRU"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsProjectMRU GetProjectMRU(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsProjectMRU, IVsProjectMRU>();
        }
    }
}
