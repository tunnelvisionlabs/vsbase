namespace ShellServices_10.IntegrationTests
{
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VSSDK.Tools.VsIdeTesting;
    using Tvl.VisualStudio.OutputWindow.Interfaces;
    using Tvl.VisualStudio.Shell;
    using Path = System.IO.Path;

    [TestClass]
    public class TestCustomPanes
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
        public void TestUnknownPane()
        {
            Assert.IsNull(OutputWindowService.TryGetPane(Path.GetRandomFileName()));
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestTvlDiagnosticsPane()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.TvlDiagnostics);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            TestStandardPanes.TestOutputPaneBehavior(pane, PredefinedOutputWindowPanes.TvlDiagnostics);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestTvlIntellisensePane()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.TvlIntellisense);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            TestStandardPanes.TestOutputPaneBehavior(pane, PredefinedOutputWindowPanes.TvlIntellisense);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestRenameCustomPaneDoesNotAffectPaneLookup()
        {
            IOutputWindowService outputWindowService = OutputWindowService;
            IOutputWindowPane pane = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.TvlDiagnostics);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));

            string newName = PredefinedOutputWindowPanes.TvlDiagnostics + " Something Else";
            pane.Name = newName;
            IOutputWindowPane retry = outputWindowService.TryGetPane(PredefinedOutputWindowPanes.TvlDiagnostics);
            Assert.IsInstanceOfType(pane, typeof(IOutputWindowPane));
            Assert.AreEqual(newName, retry.Name);

            retry.Name = PredefinedOutputWindowPanes.TvlDiagnostics;
            Assert.AreEqual(PredefinedOutputWindowPanes.TvlDiagnostics, pane.Name);
        }
    }
}
