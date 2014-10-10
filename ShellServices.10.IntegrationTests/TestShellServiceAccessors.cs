namespace ShellServices_10.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.VisualStudio.ComponentModelHost;
    using Microsoft.VisualStudio.Language.Intellisense;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.TextManager.Interop;
    using Microsoft.VSSDK.Tools.VsIdeTesting;
    using Tvl.VisualStudio.Shell;
    using IOleComponentManager = Microsoft.VisualStudio.OLE.Interop.IOleComponentManager;
    using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
    using Path = System.IO.Path;

    [TestClass]
    public class TestShellServiceAccessors
    {
        // Hosted tests run out of a TestResults directory in the solution path.
        private static readonly string SolutionDir = Path.Combine(Path.GetDirectoryName(typeof(TestShellServiceAccessors).Assembly.Location), @"..\..\..\ShellServices.10.IntegrationTests\Fixtures\CSharpClassLibrary");

        private SVsServiceProvider ServiceProvider
        {
            get
            {
                return VsIdeTestHostContext.ServiceProvider.AsVsServiceProvider();
            }
        }

        [ClassInitialize]
        public static void PrepareSolution(TestContext context)
        {
            var dte = VsIdeTestHostContext.Dte;
            dte.Solution.Open(Path.Combine(SolutionDir, "CSharpClassLibrary.sln"));
            dte.Solution.Close(false);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void GenerateShellService10Tests()
        {
            StringBuilder tests = new StringBuilder();
            bool pass = true;

            MethodInfo[] methods = typeof(VsServiceProviderExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (MethodInfo methodInfo in methods.OrderBy(i => i.Name))
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();
                if (parameters.Length != 1 || parameters[0].ParameterType != typeof(SVsServiceProvider))
                    continue;

                tests.AppendLine("[TestMethod]");
                tests.AppendLine("[HostType(\"VS IDE\")]");
                tests.Append("public void Test").Append(methodInfo.Name).AppendLine("()");
                tests.AppendLine("{");
                tests.Append("    Assert.IsInstanceOfType(ServiceProvider.").Append(methodInfo.Name).Append("(), typeof(").Append(methodInfo.ReturnParameter.ParameterType.Name).AppendLine("));");
                tests.AppendLine("}");
                tests.AppendLine();

                pass &= typeof(TestShellServiceAccessors).GetMethod("Test" + methodInfo.Name) != null;
            }

            Console.WriteLine(tests);
            Assert.IsTrue(pass);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetActivityLog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetActivityLog(), typeof(IVsActivityLog));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetAddProjectItemDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAddProjectItemDialog(), typeof(IVsAddProjectItemDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetAddWebReferenceDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAddWebReferenceDialog(), typeof(IVsAddWebReferenceDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetAppCommandLine()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAppCommandLine(), typeof(IVsAppCommandLine));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetAssemblyNameUnification()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAssemblyNameUnification(), typeof(IVsAssemblyNameUnification));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCallBrowser()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCallBrowser(), typeof(IVsCallBrowser));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetClassView()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetClassView(), typeof(IVsNavigationTool));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCodeDefView()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCodeDefView(), typeof(IVsCodeDefView));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCodeShareHandler()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCodeShareHandler(), typeof(IVsCodeShareHandler));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCommandNameMapping()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCommandNameMapping(), typeof(IVsCmdNameMapping));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCommandWindow()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCommandWindow(), typeof(IVsCommandWindow));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCommandWindowsCollection()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCommandWindowsCollection(), typeof(IVsCommandWindowsCollection));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetComponentModel()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetComponentModel(), typeof(IComponentModel));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetComponentModelHost()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetComponentModelHost(), typeof(IVsComponentModelHost));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetComponentSelectorDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetComponentSelectorDialog(), typeof(IVsComponentSelectorDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetComponentSelectorDialog2()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetComponentSelectorDialog2(), typeof(IVsComponentSelectorDlg2));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetConfigurationManagerDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetConfigurationManagerDialog(), typeof(IVsConfigurationManagerDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetCreateAggregateProject()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetCreateAggregateProject(), typeof(IVsCreateAggregateProject));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDebuggableProtocol()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDebuggableProtocol(), typeof(IVsDebuggableProtocol));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDebugLaunch()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDebugLaunch(), typeof(IVsDebugLaunch));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDetermineWizardTrust()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDetermineWizardTrust(), typeof(IVsDetermineWizardTrust));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDiscoveryService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDiscoveryService(), typeof(IVsDiscoveryService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetEnumHierarchyItemsFactory()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetEnumHierarchyItemsFactory(), typeof(IVsEnumHierarchyItemsFactory));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetErrorList()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetErrorList(), typeof(IVsErrorList));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetExpansionManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetExpansionManager(), typeof(IVsExpansionManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetExternalFilesManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetExternalFilesManager(), typeof(IVsExternalFilesManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFileChange()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFileChange(), typeof(IVsFileChangeEx));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFilterAddProjectItemDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFilterAddProjectItemDialog(), typeof(IVsFilterAddProjectItemDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFilterKeys()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFilterKeys(), typeof(IVsFilterKeys));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFindSymbol()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFindSymbol(), typeof(IVsFindSymbol));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFontAndColorCacheManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFontAndColorCacheManager(), typeof(IVsFontAndColorCacheManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFontAndColorStorage()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFontAndColorStorage(), typeof(IVsFontAndColorStorage));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFontAndColorUtilities()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFontAndColorUtilities(), typeof(IVsFontAndColorUtilities));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFrameworkMultiTargeting()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFrameworkMultiTargeting(), typeof(IVsFrameworkMultiTargeting));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFrameworkRetargetingDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFrameworkRetargetingDialog(), typeof(IVsFrameworkRetargetingDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetGlyphService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetGlyphService(), typeof(IGlyphService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetHelpSystem()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetHelpSystem(), typeof(IVsHelpSystem));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetHtmlConverter()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetHtmlConverter(), typeof(IVsHTMLConverter));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetIme()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetIme(), typeof(IVsIME));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetIntelliMouseHandler()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetIntelliMouseHandler(), typeof(IVsIntelliMouseHandler));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetIntellisenseEngine()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetIntellisenseEngine(), typeof(IVsIntellisenseEngine));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetIntellisenseProjectHost()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetIntellisenseProjectHost(), typeof(IVsIntellisenseProjectHost));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetIntellisenseProjectManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetIntellisenseProjectManager(), typeof(IVsIntellisenseProjectManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetInvisibleEditorManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetInvisibleEditorManager(), typeof(IVsInvisibleEditorManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetLaunchPad()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetLaunchPad(), typeof(IVsLaunchPad));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetLaunchPadFactory()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetLaunchPadFactory(), typeof(IVsLaunchPadFactory));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetMacroRecorder()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetMacroRecorder(), typeof(IVsMacroRecorder));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetMacros()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetMacros(), typeof(IVsMacros));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetMDTypeResolutionService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetMDTypeResolutionService(), typeof(IVSMDTypeResolutionService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetMenuEditor()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetMenuEditor(), typeof(IVsMenuEditor));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetMonitorSelection()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetMonitorSelection(), typeof(IVsMonitorSelection));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetMonitorUserContext()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetMonitorUserContext(), typeof(IVsMonitorUserContext));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetObjectBrowser()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetObjectBrowser(), typeof(IVsNavigationTool));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetObjectManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetObjectManager(), typeof(IVsObjectManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetObjectSearch()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetObjectSearch(), typeof(IVsObjectSearch));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetObjectSearchPane()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetObjectSearchPane(), typeof(IVsObjectSearchPane));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetOleComponentManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetOleComponentManager(), typeof(IOleComponentManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetOleServiceProvider()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetOleServiceProvider(), typeof(IOleServiceProvider));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetOpenProjectOrSolutionDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetOpenProjectOrSolutionDialog(), typeof(IVsOpenProjectOrSolutionDlg));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetOutputWindow()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetOutputWindow(), typeof(IVsOutputWindow));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetParseCommandLine()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetParseCommandLine(), typeof(IVsParseCommandLine));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetPathVariableResolver()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetPathVariableResolver(), typeof(IVsPathVariableResolver));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetPreviewChangesService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetPreviewChangesService(), typeof(IVsPreviewChangesService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetProfileDataManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetProfileDataManager(), typeof(IVsProfileDataManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetProfilesManagerUI()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetProfilesManagerUI(), typeof(IVsProfilesManagerUI));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetPropertyPageFrame()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetPropertyPageFrame(), typeof(IVsPropertyPageFrame));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetQueryEditQuerySave()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetQueryEditQuerySave(), typeof(IVsQueryEditQuerySave2));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetRegisterEditors()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetRegisterEditors(), typeof(IVsRegisterEditors));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetRegisterNewDialogFilters()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetRegisterNewDialogFilters(), typeof(IVsRegisterNewDialogFilters));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetRegisterPriorityCommandTarget()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetRegisterPriorityCommandTarget(), typeof(IVsRegisterPriorityCommandTarget));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetRegisterProjectDebugTargetProvider()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetRegisterProjectDebugTargetProvider(), typeof(IVsRegisterProjectDebugTargetProvider));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetRegisterProjectTypes()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetRegisterProjectTypes(), typeof(IVsRegisterProjectTypes));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetResourceManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetResourceManager(), typeof(IVsResourceManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetResourceView()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetResourceView(), typeof(IVsResourceView));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetRunningDocumentTable()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetRunningDocumentTable(), typeof(IVsRunningDocumentTable));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSettingsReader()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSettingsReader(), typeof(IVsSettingsReader));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetShell()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetShell(), typeof(IVsShell));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetShellDebugger()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetShellDebugger(), typeof(IVsDebugger2));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetShellMonitorSelection()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetShellMonitorSelection(), typeof(IVsMonitorSelection));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSmartOpenScope()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSmartOpenScope(), typeof(IVsSmartOpenScope));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSolution()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSolution(), typeof(IVsSolution));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSolutionBuildManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSolutionBuildManager(), typeof(IVsSolutionBuildManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        [Obsolete]
        public void TestGetSolutionObject()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSolutionObject(), typeof(IVsSolution));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSolutionPersistence()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSolutionPersistence(), typeof(IVsSolutionPersistence));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSourceControlManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSourceControlManager(), typeof(IVsSccManager2));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSourceControlToolsOptions()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSourceControlToolsOptions(), typeof(IVsSccToolsOptions));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSqlClrReferences()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSqlClrReferences(), typeof(IVsSQLCLRReferences));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetStartPageDownload()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetStartPageDownload(), typeof(IVsStartPageDownload));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetStatusBar()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetStatusBar(), typeof(IVsStatusbar));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetStrongNameKeys()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetStrongNameKeys(), typeof(IVsStrongNameKeys));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetStructuredFileIO()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetStructuredFileIO(), typeof(IVsStructuredFileIO));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetSymbolicNavigationManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetSymbolicNavigationManager(), typeof(IVsSymbolicNavigationManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTargetFrameworkAssemblies()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTargetFrameworkAssemblies(), typeof(IVsTargetFrameworkAssemblies));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTaskList()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTaskList(), typeof(IVsTaskList));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTextManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTextManager(), typeof(IVsTextManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTextManager2()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTextManager2(), typeof(IVsTextManager2));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTextOut()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTextOut(), typeof(IVsTextOut));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetThreadedWaitDialog()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetThreadedWaitDialog(), typeof(IVsThreadedWaitDialog));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetThreadPool()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetThreadPool(), typeof(IVsThreadPool));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetToolbox()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetToolbox(), typeof(IVsToolbox));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetToolboxActiveXDataProvider()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetToolboxActiveXDataProvider(), typeof(IVsToolboxDataProvider));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetToolboxDataProviderRegistry()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetToolboxDataProviderRegistry(), typeof(IVsToolboxDataProviderRegistry));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetToolsOptions()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetToolsOptions(), typeof(IVsToolsOptions));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTrackProjectDocuments2()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTrackProjectDocuments2(), typeof(IVsTrackProjectDocuments2));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTrackProjectDocuments3()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTrackProjectDocuments3(), typeof(IVsTrackProjectDocuments3));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTrackProjectRetargeting()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTrackProjectRetargeting(), typeof(IVsTrackProjectRetargeting));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTrackSelection()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTrackSelection(), typeof(IVsTrackSelectionEx));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetUIHierarchyWindowClipboardHelper()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetUIHierarchyWindowClipboardHelper(), typeof(IVsUIHierWinClipboardHelper));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetUIShell()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetUIShell(), typeof(IVsUIShell));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetUIShellDocumentWindowManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetUIShellDocumentWindowManager(), typeof(IVsUIShellDocumentWindowMgr));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetUIShellOpenDocument()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetUIShellOpenDocument(), typeof(IVsUIShellOpenDocument));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetUpgradeLogger()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetUpgradeLogger(), typeof(IVsUpgradeLogger));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetVba()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetVba(), typeof(IVsVba));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetWebBrowsingService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetWebBrowsingService(), typeof(IVsWebBrowsingService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetWebFavorites()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetWebFavorites(), typeof(IVsWebFavorites));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetWebPreview()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetWebPreview(), typeof(IVsWebPreview));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetWebProxy()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetWebProxy(), typeof(IVsWebProxy));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetWebUrlMru()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetWebUrlMru(), typeof(IVsWebURLMRU));
        }
    }
}
