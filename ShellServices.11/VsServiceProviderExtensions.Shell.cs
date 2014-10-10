namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    partial class VsServiceProviderExtensions11
    {
        /// <summary>
        /// Gets the global <see cref="IVsAppContainerDeveloperLicensing"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsAppContainerDeveloperLicensing"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsAppContainerDeveloperLicensing GetAppContainerDeveloperLicensing(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsAppContainerDeveloperLicensing, IVsAppContainerDeveloperLicensing>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsAppContainerProjectDeploy"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsAppContainerProjectDeploy"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsAppContainerProjectDeploy GetAppContainerProjectDeploy(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsAppContainerProjectDeploy, IVsAppContainerProjectDeploy>();
        }

        /// <summary>
        /// Gets the global <see cref="IAppxManifestDesignerService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IAppxManifestDesignerService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IAppxManifestDesignerService GetAppxManifestDesignerService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SAppxManifestDesignerService, IAppxManifestDesignerService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDebugRemoteDiscoveryUI"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDebugRemoteDiscoveryUI"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDebugRemoteDiscoveryUI GetDebugRemoteDiscoveryUI(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDebugRemoteDiscoveryUI, IVsDebugRemoteDiscoveryUI>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDebugTargetSelectionService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDebugTargetSelectionService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDebugTargetSelectionService GetDebugTargetSelectionService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDebugTargetSelectionService, IVsDebugTargetSelectionService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDifferenceService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDifferenceService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDifferenceService GetDifferenceService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDifferenceService, IVsDifferenceService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFileMergeService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFileMergeService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFileMergeService GetFileMergeService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFileMergeService, IVsFileMergeService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsGlobalSearch"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsGlobalSearch"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsGlobalSearch GetGlobalSearch(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsGlobalSearch, IVsGlobalSearch>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsHierarchyManipulation"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsHierarchyManipulation"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsHierarchyManipulation GetHierarchyManipulation(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsHierarchyManipulation, IVsHierarchyManipulation>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsImageService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsImageService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsImageService GetImageService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsImageService, IVsImageService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsProfilerLauncher"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsProfilerLauncher"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsProfilerLauncher GetProfilerLauncher(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsProfilerLauncher, IVsProfilerLauncher>();
        }

        /// <summary>
        /// Gets the global <see cref="VsProjectCapabilityExpressionMatcher"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsBooleanSymbolExpressionEvaluator"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsBooleanSymbolExpressionEvaluator GetProjectCapabilityExpressionMatcher(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<VsProjectCapabilityExpressionMatcher, IVsBooleanSymbolExpressionEvaluator>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsReferenceManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsReferenceManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsReferenceManager GetReferenceManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsReferenceManager, IVsReferenceManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTaskSchedulerService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTaskSchedulerService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTaskSchedulerService GetTaskSchedulerService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTaskSchedulerService, IVsTaskSchedulerService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsWindowSearchHostFactory"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsWindowSearchHostFactory"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsWindowSearchHostFactory GetWindowSearchHostFactory(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsWindowSearchHostFactory, IVsWindowSearchHostFactory>();
        }
    }
}
