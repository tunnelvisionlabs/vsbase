namespace ShellServices_10.IntegrationTests
{
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VSSDK.Tools.VsIdeTesting;
    using Tvl.VisualStudio.OutputWindow.Interfaces;
    using Tvl.VisualStudio.Shell;
    using Path = System.IO.Path;

    [TestClass]
    public class TestStandardPanes
    {
        private SVsServiceProvider ServiceProvider
        {
            get
            {
                return VsIdeTestHostContext.ServiceProvider.AsVsServiceProvider();
            }
        }

        private IOutputWindowService OutputWindowService
        {
            get
            {
                var componentModel = ServiceProvider.AsVsServiceProvider().GetComponentModel();
                return componentModel.DefaultExportProvider.GetExportedValue<IOutputWindowService>();
            }
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestAccessOutputWindowService()
        {
            Assert.IsNotNull(OutputWindowService);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestPredefinedBuildPane()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.Build);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            TestOutputPaneBehavior(pane, PredefinedOutputWindowPanes.Build);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestPredefinedDebugPane()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.Debug);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            TestOutputPaneBehavior(pane, PredefinedOutputWindowPanes.Debug);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestPredefinedGeneralPane()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.General);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            TestOutputPaneBehavior(pane, PredefinedOutputWindowPanes.General);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestRenameGeneralPaneDoesNotAffectPaneLookup()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.General);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));

            string newName = PredefinedOutputWindowPanes.General + " Something Else";
            pane.Name = newName;
            IOutputWindowPane retry = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.General);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            Assert.AreEqual(newName, retry.Name);

            retry.Name = PredefinedOutputWindowPanes.General;
            Assert.AreEqual(PredefinedOutputWindowPanes.General, pane.Name);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestRenameBuildPaneDoesNotAffectPaneLookup()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.Build);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));

            string newName = PredefinedOutputWindowPanes.Build + " Something Else";
            pane.Name = newName;
            IOutputWindowPane retry = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.Build);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            Assert.AreEqual(newName, retry.Name);

            retry.Name = PredefinedOutputWindowPanes.Build;
            Assert.AreEqual(PredefinedOutputWindowPanes.Build, pane.Name);
        }

        internal static void TestOutputPaneBehavior(IOutputWindowPane pane, string initialName)
        {
            Assert.IsNotNull(pane);
            Assert.AreEqual(initialName, pane.Name);

            pane.Activate();
            pane.Hide();
            pane.Activate();
            string newName = pane.Name + " - " + Path.GetRandomFileName();
            pane.Name = newName;
            Assert.AreEqual(newName, pane.Name);
            pane.Write("Writing  text...");
            pane.WriteLine(" done.");
        }
    }
}
