namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

    /// <summary>
    /// Provides extension methods for <see cref="IServiceProvider"/> and <see cref="IOleServiceProvider"/>.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Get an <see cref="SVsServiceProvider"/> instance wrapping an <see cref="IServiceProvider"/>.
        /// </summary>
        /// <remarks>
        /// This method can be used to access the extension methods defined in <see cref="VsServiceProviderExtensions"/>
        /// to easily access global IDE service instances.
        /// </remarks>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>An <see cref="SVsServiceProvider"/> implementation wrapping the specified service provider.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static SVsServiceProvider AsVsServiceProvider(this IServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            Contract.Ensures(Contract.Result<SVsServiceProvider>() != null);

            return new VsServiceProviderWrapper(serviceProvider);
        }

        /// <summary>
        /// Get an instance of a service from an <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TService">The type of service to locate.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>An instance of the service, or <see langword="null"/> if the service provider was unable to provide the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static TService GetService<TService>(this IServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return GetService<TService, TService>(serviceProvider);
        }

        /// <summary>
        /// Get an instance of <typeparamref name="TServiceInterface"/> by requesting an
        /// instance of <typeparamref name="TServiceClass"/> from the specified service provider.
        /// </summary>
        /// <typeparam name="TServiceClass">The type of service to request from the service provider.</typeparam>
        /// <typeparam name="TServiceInterface">The type to cast the resulting service object to.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>An instance of the service, or <see langword="null"/> if the service provider was unable to provide the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidCastException">If the instance returned by the service provider for <typeparamref name="TServiceClass"/> could not be cast to <typeparamref name="TServiceInterface"/>.</exception>
        public static TServiceInterface GetService<TServiceClass, TServiceInterface>(this IServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return (TServiceInterface)serviceProvider.GetService(typeof(TServiceClass));
        }

        /// <summary>
        /// Get an instance of <see cref="IOleServiceProvider"/> from the specified service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>An instance of <see cref="IOleServiceProvider"/> returned by the service provider, or <see langword="null"/> if the service provider was unable to provide the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public static IOleServiceProvider TryGetOleServiceProvider(this IServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<IOleServiceProvider>();
        }

        /// <summary>
        /// Get an instance of <typeparamref name="TServiceInterface"/> by requesting an
        /// instance of <typeparamref name="TServiceClass"/> from the specified OLE service
        /// provider.
        /// </summary>
        /// <typeparam name="TServiceClass">The type of service to request from the service provider.</typeparam>
        /// <typeparam name="TServiceInterface">The type to cast the resulting service object to.</typeparam>
        /// <param name="serviceProvider">The OLE service provider.</param>
        /// <returns>An instance of the service, or <see langword="null"/> if the service provider was unable to provide the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidCastException">If the instance returned by the service provider for <typeparamref name="TServiceClass"/> could not be cast to <typeparamref name="TServiceInterface"/>.</exception>
        public static TServiceInterface TryGetGlobalService<TServiceClass, TServiceInterface>(this IOleServiceProvider serviceProvider)
            where TServiceInterface : class
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");

            Guid guidService = typeof(TServiceClass).GUID;
            Guid riid = typeof(TServiceClass).GUID;
            IntPtr obj = IntPtr.Zero;
            int result = ErrorHandler.CallWithCOMConvention(() => serviceProvider.QueryService(ref guidService, ref riid, out obj));
            if (ErrorHandler.Failed(result) || obj == IntPtr.Zero)
                return null;

            try
            {
                TServiceInterface service = (TServiceInterface)Marshal.GetObjectForIUnknown(obj);
                return service;
            }
            finally
            {
                Marshal.Release(obj);
            }
        }
    }
}
