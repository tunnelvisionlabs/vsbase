namespace Tvl.VisualStudio.Shell
{
    using System;
    using Microsoft.VisualStudio.Shell;
    using IOleComponentManager = Microsoft.VisualStudio.OLE.Interop.IOleComponentManager;
    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using SOleComponentManager = Microsoft.VisualStudio.OLE.Interop.SOleComponentManager;

    partial class VsServiceProviderExtensions
    {
        /// <summary>
        /// Gets the global <see cref="IOleComponentManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IOleComponentManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IOleComponentManager GetOleComponentManager(this SVsServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            return serviceProvider.GetService<SOleComponentManager, IOleComponentManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IOleServiceProvider"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IOleServiceProvider"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IOleServiceProvider GetOleServiceProvider(this SVsServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            return serviceProvider.GetService<IOleServiceProvider, IOleServiceProvider>();
        }
    }
}
