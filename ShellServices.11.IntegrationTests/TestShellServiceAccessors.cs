namespace ShellServices_11.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VSSDK.Tools.VsIdeTesting;
    using Tvl.VisualStudio.Shell;
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
        public void GenerateShellService11Tests()
        {
            StringBuilder tests = new StringBuilder();
            bool pass = true;

            MethodInfo[] methods = typeof(VsServiceProviderExtensions11).GetMethods(BindingFlags.Static | BindingFlags.Public);
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
        public void TestGetAppContainerDeveloperLicensing()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAppContainerDeveloperLicensing(), typeof(IVsAppContainerDeveloperLicensing));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetAppContainerProjectDeploy()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAppContainerProjectDeploy(), typeof(IVsAppContainerProjectDeploy));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetAppxManifestDesignerService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetAppxManifestDesignerService(), typeof(IAppxManifestDesignerService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDebugRemoteDiscoveryUI()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDebugRemoteDiscoveryUI(), typeof(IVsDebugRemoteDiscoveryUI));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDebugTargetSelectionService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDebugTargetSelectionService(), typeof(IVsDebugTargetSelectionService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetDifferenceService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetDifferenceService(), typeof(IVsDifferenceService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetFileMergeService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetFileMergeService(), typeof(IVsFileMergeService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetGlobalSearch()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetGlobalSearch(), typeof(IVsGlobalSearch));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetHierarchyManipulation()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetHierarchyManipulation(), typeof(IVsHierarchyManipulation));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetImageService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetImageService(), typeof(IVsImageService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetProfilerLauncher()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetProfilerLauncher(), typeof(IVsProfilerLauncher));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetProjectCapabilityExpressionMatcher()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetProjectCapabilityExpressionMatcher(), typeof(IVsBooleanSymbolExpressionEvaluator));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetReferenceManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetReferenceManager(), typeof(IVsReferenceManager));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetTaskSchedulerService()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetTaskSchedulerService(), typeof(IVsTaskSchedulerService));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestGetWindowSearchHostFactory()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetWindowSearchHostFactory(), typeof(IVsWindowSearchHostFactory));
        }
    }
}
