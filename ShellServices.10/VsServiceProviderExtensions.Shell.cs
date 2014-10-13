namespace Tvl.VisualStudio.Shell
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    partial class VsServiceProviderExtensions
    {
        /// <summary>
        /// Gets the global <see cref="IVsActivityLog"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsActivityLog"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsActivityLog GetActivityLog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsActivityLog, IVsActivityLog>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsAddProjectItemDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsAddProjectItemDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsAddProjectItemDlg GetAddProjectItemDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsAddProjectItemDlg, IVsAddProjectItemDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsAddWebReferenceDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsAddWebReferenceDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsAddWebReferenceDlg GetAddWebReferenceDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsAddWebReferenceDlg, IVsAddWebReferenceDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsAppCommandLine"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsAppCommandLine"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsAppCommandLine GetAppCommandLine(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsAppCommandLine, IVsAppCommandLine>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsAssemblyNameUnification"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsAssemblyNameUnification"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsAssemblyNameUnification GetAssemblyNameUnification(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsAssemblyNameUnification, IVsAssemblyNameUnification>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCallBrowser"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCallBrowser"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCallBrowser GetCallBrowser(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCallBrowser, IVsCallBrowser>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsNavigationTool"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsNavigationTool"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsNavigationTool GetClassView(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsClassView, IVsNavigationTool>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCodeDefView"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCodeDefView"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCodeDefView GetCodeDefView(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCodeDefView, IVsCodeDefView>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCodeShareHandler"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCodeShareHandler"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCodeShareHandler GetCodeShareHandler(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCodeShareHandler, IVsCodeShareHandler>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCmdNameMapping"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCmdNameMapping"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCmdNameMapping GetCommandNameMapping(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCmdNameMapping, IVsCmdNameMapping>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCommandWindow"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCommandWindow"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCommandWindow GetCommandWindow(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCommandWindow, IVsCommandWindow>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCommandWindowsCollection"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCommandWindowsCollection"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCommandWindowsCollection GetCommandWindowsCollection(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCommandWindowsCollection, IVsCommandWindowsCollection>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsComponentModelHost"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsComponentModelHost"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsComponentModelHost GetComponentModelHost(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsComponentModelHost, IVsComponentModelHost>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsComponentSelectorDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsComponentSelectorDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsComponentSelectorDlg GetComponentSelectorDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsComponentSelectorDlg, IVsComponentSelectorDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsComponentSelectorDlg2"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsComponentSelectorDlg2"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsComponentSelectorDlg2 GetComponentSelectorDialog2(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsComponentSelectorDlg2, IVsComponentSelectorDlg2>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsConfigurationManagerDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsConfigurationManagerDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsConfigurationManagerDlg GetConfigurationManagerDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsConfigurationManagerDlg, IVsConfigurationManagerDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsCreateAggregateProject"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsCreateAggregateProject"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsCreateAggregateProject GetCreateAggregateProject(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsCreateAggregateProject, IVsCreateAggregateProject>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDebuggableProtocol"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDebuggableProtocol"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDebuggableProtocol GetDebuggableProtocol(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDebuggableProtocol, IVsDebuggableProtocol>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDebugLaunch"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDebugLaunch"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDebugLaunch GetDebugLaunch(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDebugLaunch, IVsDebugLaunch>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDetermineWizardTrust"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDetermineWizardTrust"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDetermineWizardTrust GetDetermineWizardTrust(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDetermineWizardTrust, IVsDetermineWizardTrust>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDiscoveryService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDiscoveryService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDiscoveryService GetDiscoveryService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsDiscoveryService, IVsDiscoveryService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsEnumHierarchyItemsFactory"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsEnumHierarchyItemsFactory"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsEnumHierarchyItemsFactory GetEnumHierarchyItemsFactory(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsEnumHierarchyItemsFactory, IVsEnumHierarchyItemsFactory>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsErrorList"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsErrorList"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsErrorList GetErrorList(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsErrorList, IVsErrorList>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsExternalFilesManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsExternalFilesManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsExternalFilesManager GetExternalFilesManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsExternalFilesManager, IVsExternalFilesManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFileChangeEx"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFileChangeEx"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFileChangeEx GetFileChange(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFileChangeEx, IVsFileChangeEx>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFilterAddProjectItemDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFilterAddProjectItemDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFilterAddProjectItemDlg GetFilterAddProjectItemDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFilterAddProjectItemDlg, IVsFilterAddProjectItemDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFilterKeys"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFilterKeys"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFilterKeys GetFilterKeys(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFilterKeys, IVsFilterKeys>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFindSymbol"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFindSymbol"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFindSymbol GetFindSymbol(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsObjectSearch, IVsFindSymbol>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFontAndColorCacheManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFontAndColorCacheManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFontAndColorCacheManager GetFontAndColorCacheManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFontAndColorCacheManager, IVsFontAndColorCacheManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFontAndColorStorage"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFontAndColorStorage"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFontAndColorStorage GetFontAndColorStorage(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFontAndColorStorage, IVsFontAndColorStorage>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFontAndColorUtilities"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFontAndColorUtilities"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFontAndColorUtilities GetFontAndColorUtilities(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return (IVsFontAndColorUtilities)serviceProvider.GetFontAndColorStorage();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFrameworkMultiTargeting"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFrameworkMultiTargeting"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFrameworkMultiTargeting GetFrameworkMultiTargeting(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFrameworkMultiTargeting, IVsFrameworkMultiTargeting>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsFrameworkRetargetingDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsFrameworkRetargetingDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsFrameworkRetargetingDlg GetFrameworkRetargetingDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsFrameworkRetargetingDlg, IVsFrameworkRetargetingDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsHelpSystem"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsHelpSystem"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsHelpSystem GetHelpSystem(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsHelpService, IVsHelpSystem>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsHTMLConverter"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsHTMLConverter"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsHTMLConverter GetHtmlConverter(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsHTMLConverter, IVsHTMLConverter>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsIME"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsIME"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsIME GetIme(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsIME, IVsIME>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsIntelliMouseHandler"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsIntelliMouseHandler"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        // spelling as intended
        [SuppressMessage("Microsoft.Naming", "CA1704")]
        [CLSCompliant(false)]
        public static IVsIntelliMouseHandler GetIntelliMouseHandler(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsIntelliMouseHandler, IVsIntelliMouseHandler>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsIntellisenseEngine"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsIntellisenseEngine"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsIntellisenseEngine GetIntellisenseEngine(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsIntellisenseEngine, IVsIntellisenseEngine>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsIntellisenseProjectHost"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsIntellisenseProjectHost"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsIntellisenseProjectHost GetIntellisenseProjectHost(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsIntellisenseProjectHost, IVsIntellisenseProjectHost>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsIntellisenseProjectManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsIntellisenseProjectManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsIntellisenseProjectManager GetIntellisenseProjectManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsIntellisenseProjectManager, IVsIntellisenseProjectManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsInvisibleEditorManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsInvisibleEditorManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsInvisibleEditorManager GetInvisibleEditorManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsInvisibleEditorManager, IVsInvisibleEditorManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsLaunchPad"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsLaunchPad"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsLaunchPad GetLaunchPad(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsLaunchPad, IVsLaunchPad>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsLaunchPadFactory"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsLaunchPadFactory"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsLaunchPadFactory GetLaunchPadFactory(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsLaunchPadFactory, IVsLaunchPadFactory>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsMacroRecorder"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsMacroRecorder"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsMacroRecorder GetMacroRecorder(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsMacroRecorder, IVsMacroRecorder>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsMacros"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsMacros"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsMacros GetMacros(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsMacros, IVsMacros>();
        }

        /// <summary>
        /// Gets the global <see cref="IVSMDTypeResolutionService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVSMDTypeResolutionService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVSMDTypeResolutionService GetMDTypeResolutionService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVSMDTypeResolutionService, IVSMDTypeResolutionService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsMenuEditor"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsMenuEditor"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsMenuEditor GetMenuEditor(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsMenuEditor, IVsMenuEditor>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsMonitorUserContext"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsMonitorUserContext"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsMonitorUserContext GetMonitorUserContext(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsMonitorUserContext, IVsMonitorUserContext>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsMonitorSelection"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsMonitorSelection"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsMonitorSelection GetMonitorSelection(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<IVsMonitorSelection, IVsMonitorSelection>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsNavigationTool"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsNavigationTool"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsNavigationTool GetObjectBrowser(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsObjBrowser, IVsNavigationTool>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsObjectManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsObjectManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsObjectManager GetObjectManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsObjectManager, IVsObjectManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsObjectSearch"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsObjectSearch"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsObjectSearch GetObjectSearch(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsObjectSearch, IVsObjectSearch>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsObjectSearchPane"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsObjectSearchPane"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsObjectSearchPane GetObjectSearchPane(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetObjectSearch() as IVsObjectSearchPane;
        }

        /// <summary>
        /// Gets the global <see cref="IVsOpenProjectOrSolutionDlg"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsOpenProjectOrSolutionDlg"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        // We don't mean 'Projector'
        [SuppressMessage("Microsoft.Naming", "CA1702")]
        [CLSCompliant(false)]
        public static IVsOpenProjectOrSolutionDlg GetOpenProjectOrSolutionDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsOpenProjectOrSolutionDlg, IVsOpenProjectOrSolutionDlg>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsOutputWindow"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsOutputWindow"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsOutputWindow GetOutputWindow(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsOutputWindow, IVsOutputWindow>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsParseCommandLine"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsParseCommandLine"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsParseCommandLine GetParseCommandLine(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsParseCommandLine, IVsParseCommandLine>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsPathVariableResolver"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsPathVariableResolver"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsPathVariableResolver GetPathVariableResolver(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsPathVariableResolver, IVsPathVariableResolver>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsPreviewChangesService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsPreviewChangesService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsPreviewChangesService GetPreviewChangesService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsPreviewChangesService, IVsPreviewChangesService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsProfileDataManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsProfileDataManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsProfileDataManager GetProfileDataManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsProfileDataManager, IVsProfileDataManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsProfilesManagerUI"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsProfilesManagerUI"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsProfilesManagerUI GetProfilesManagerUI(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsProfilesManagerUI, IVsProfilesManagerUI>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsPropertyPageFrame"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsPropertyPageFrame"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsPropertyPageFrame GetPropertyPageFrame(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsPropertyPageFrame, IVsPropertyPageFrame>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsQueryEditQuerySave2"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsQueryEditQuerySave2"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsQueryEditQuerySave2 GetQueryEditQuerySave(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsQueryEditQuerySave, IVsQueryEditQuerySave2>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsRegisterProjectDebugTargetProvider"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsRegisterProjectDebugTargetProvider"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsRegisterProjectDebugTargetProvider GetRegisterProjectDebugTargetProvider(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsRegisterDebugTargetProvider, IVsRegisterProjectDebugTargetProvider>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsRegisterEditors"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsRegisterEditors"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsRegisterEditors GetRegisterEditors(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsRegisterEditors, IVsRegisterEditors>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsRegisterNewDialogFilters"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsRegisterNewDialogFilters"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsRegisterNewDialogFilters GetRegisterNewDialogFilters(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsRegisterNewDialogFilters, IVsRegisterNewDialogFilters>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsRegisterPriorityCommandTarget"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsRegisterPriorityCommandTarget"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsRegisterPriorityCommandTarget GetRegisterPriorityCommandTarget(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsRegisterPriorityCommandTarget, IVsRegisterPriorityCommandTarget>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsRegisterProjectTypes"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsRegisterProjectTypes"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsRegisterProjectTypes GetRegisterProjectTypes(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsRegisterProjectTypes, IVsRegisterProjectTypes>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsResourceManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsResourceManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsResourceManager GetResourceManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsResourceManager, IVsResourceManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsResourceView"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsResourceView"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsResourceView GetResourceView(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsResourceView, IVsResourceView>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsRunningDocumentTable"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsRunningDocumentTable"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsRunningDocumentTable GetRunningDocumentTable(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsRunningDocumentTable, IVsRunningDocumentTable>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSccManager2"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSccManager2"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSccManager2 GetSourceControlManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSccManager, IVsSccManager2>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSccToolsOptions"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSccToolsOptions"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSccToolsOptions GetSourceControlToolsOptions(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSccToolsOptions, IVsSccToolsOptions>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSettingsReader"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSettingsReader"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSettingsReader GetSettingsReader(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSettingsReader, IVsSettingsReader>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsShell"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsShell"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsShell GetShell(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsShell, IVsShell>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsDebugger2"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsDebugger2"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsDebugger2 GetShellDebugger(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsShellDebugger, IVsDebugger2>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsMonitorSelection"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsMonitorSelection"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsMonitorSelection GetShellMonitorSelection(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsShellMonitorSelection, IVsMonitorSelection>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSmartOpenScope"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSmartOpenScope"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSmartOpenScope GetSmartOpenScope(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSmartOpenScope, IVsSmartOpenScope>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSolution"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSolution"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSolution GetSolution(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSolution, IVsSolution>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSolutionBuildManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSolutionBuildManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSolutionBuildManager GetSolutionBuildManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSolutionBuildManager, IVsSolutionBuildManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSolution"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSolution"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [Obsolete("Use GetSolution() instead.")]
        [CLSCompliant(false)]
        public static IVsSolution GetSolutionObject(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSolutionObject, IVsSolution>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSolutionPersistence"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSolutionPersistence"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSolutionPersistence GetSolutionPersistence(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSolutionPersistence, IVsSolutionPersistence>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSQLCLRReferences"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSQLCLRReferences"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSQLCLRReferences GetSqlClrReferences(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSQLCLRReferences, IVsSQLCLRReferences>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsStartPageDownload"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsStartPageDownload"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsStartPageDownload GetStartPageDownload(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsStartPageDownload, IVsStartPageDownload>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsStatusbar"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsStatusbar"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsStatusbar GetStatusBar(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsStatusbar, IVsStatusbar>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsStrongNameKeys"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsStrongNameKeys"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsStrongNameKeys GetStrongNameKeys(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsStrongNameKeys, IVsStrongNameKeys>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsStructuredFileIO"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsStructuredFileIO"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsStructuredFileIO GetStructuredFileIO(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsStructuredFileIO, IVsStructuredFileIO>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsSymbolicNavigationManager"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsSymbolicNavigationManager"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsSymbolicNavigationManager GetSymbolicNavigationManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsSymbolicNavigationManager, IVsSymbolicNavigationManager>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTargetFrameworkAssemblies"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTargetFrameworkAssemblies"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTargetFrameworkAssemblies GetTargetFrameworkAssemblies(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTargetFrameworkAssemblies, IVsTargetFrameworkAssemblies>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTaskList"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTaskList"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTaskList GetTaskList(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTaskList, IVsTaskList>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTextOut"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTextOut"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTextOut GetTextOut(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTextOut, IVsTextOut>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsThreadedWaitDialog"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsThreadedWaitDialog"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsThreadedWaitDialog GetThreadedWaitDialog(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsThreadedWaitDialog, IVsThreadedWaitDialog>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsThreadPool"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsThreadPool"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsThreadPool GetThreadPool(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsThreadPool, IVsThreadPool>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsToolbox"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsToolbox"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsToolbox GetToolbox(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsToolbox, IVsToolbox>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsToolboxDataProvider"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsToolboxDataProvider"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsToolboxDataProvider GetToolboxActiveXDataProvider(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsToolboxActiveXDataProvider, IVsToolboxDataProvider>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsToolboxDataProviderRegistry"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsToolboxDataProviderRegistry"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsToolboxDataProviderRegistry GetToolboxDataProviderRegistry(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsToolboxDataProviderRegistry, IVsToolboxDataProviderRegistry>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsToolsOptions"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsToolsOptions"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsToolsOptions GetToolsOptions(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsToolsOptions, IVsToolsOptions>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTrackProjectDocuments2"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTrackProjectDocuments2"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTrackProjectDocuments2 GetTrackProjectDocuments2(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTrackProjectDocuments, IVsTrackProjectDocuments2>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTrackProjectDocuments3"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTrackProjectDocuments3"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTrackProjectDocuments3 GetTrackProjectDocuments3(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTrackProjectDocuments, IVsTrackProjectDocuments3>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTrackProjectRetargeting"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTrackProjectRetargeting"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTrackProjectRetargeting GetTrackProjectRetargeting(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTrackProjectRetargeting, IVsTrackProjectRetargeting>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsTrackSelectionEx"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsTrackSelectionEx"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsTrackSelectionEx GetTrackSelection(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsTrackSelectionEx, IVsTrackSelectionEx>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsUIHierWinClipboardHelper"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsUIHierWinClipboardHelper"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsUIHierWinClipboardHelper GetUIHierarchyWindowClipboardHelper(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsUIHierWinClipboardHelper, IVsUIHierWinClipboardHelper>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsUIShell"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsUIShell"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsUIShell GetUIShell(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsUIShell, IVsUIShell>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsUIShellDocumentWindowMgr"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsUIShellDocumentWindowMgr"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsUIShellDocumentWindowMgr GetUIShellDocumentWindowManager(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsUIShellDocumentWindowMgr, IVsUIShellDocumentWindowMgr>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsUIShellOpenDocument"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsUIShellOpenDocument"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsUIShellOpenDocument GetUIShellOpenDocument(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsUIShellOpenDocument, IVsUIShellOpenDocument>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsUpgradeLogger"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsUpgradeLogger"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsUpgradeLogger GetUpgradeLogger(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsUpgradeLogger, IVsUpgradeLogger>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsVba"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsVba"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsVba GetVba(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsVba, IVsVba>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsWebBrowsingService"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsWebBrowsingService"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsWebBrowsingService GetWebBrowsingService(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsWebBrowsingService, IVsWebBrowsingService>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsWebFavorites"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsWebFavorites"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsWebFavorites GetWebFavorites(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsWebFavorites, IVsWebFavorites>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsWebPreview"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsWebPreview"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsWebPreview GetWebPreview(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsWebPreview, IVsWebPreview>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsWebProxy"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsWebProxy"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsWebProxy GetWebProxy(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsWebProxy, IVsWebProxy>();
        }

        /// <summary>
        /// Gets the global <see cref="IVsWebURLMRU"/> service.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The <see cref="IVsWebURLMRU"/> service provided by the service provider, or <see langword="null"/> if the service provider was not able to provide an instance of the service.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        [CLSCompliant(false)]
        public static IVsWebURLMRU GetWebUrlMru(this SVsServiceProvider serviceProvider)
        {
            Contract.Requires<ArgumentNullException>(serviceProvider != null, "serviceProvider");
            return serviceProvider.GetService<SVsWebURLMRU, IVsWebURLMRU>();
        }
    }
}
