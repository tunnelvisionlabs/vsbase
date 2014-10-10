namespace ShellServices_12.IntegrationTests
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

    [TestClass]
    public class TestShellServiceAccessors
    {
        private SVsServiceProvider ServiceProvider
        {
            get
            {
                return VsIdeTestHostContext.ServiceProvider.AsVsServiceProvider();
            }
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void GenerateShellService12Tests()
        {
            StringBuilder tests = new StringBuilder();
            bool pass = true;

            MethodInfo[] methods = typeof(VsServiceProviderExtensions12).GetMethods(BindingFlags.Static | BindingFlags.Public);
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
        public void TestGetLongIdleManager()
        {
            Assert.IsInstanceOfType(ServiceProvider.GetLongIdleManager(), typeof(IVsLongIdleManager));
        }
    }
}
