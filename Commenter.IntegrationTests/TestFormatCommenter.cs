namespace ShellServices_10.IntegrationTests
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Operations;
    using Microsoft.VisualStudio.Utilities;
    using Microsoft.VSSDK.Tools.VsIdeTesting;
    using Tvl.VisualStudio.Shell;
    using Tvl.VisualStudio.Text.Commenter;

    [TestClass]
    public class TestFormatCommenter
    {
        private static readonly string TestContentType = "IntegrationTestContentType";

        private static SVsServiceProvider ServiceProvider
        {
            get
            {
                return VsIdeTestHostContext.ServiceProvider.AsVsServiceProvider();
            }
        }

        public static IContentTypeRegistryService ContentTypeRegistryService
        {
            get
            {
                return ServiceProvider.GetComponentModel().DefaultExportProvider.GetExportedValue<IContentTypeRegistryService>();
            }
        }

        public static ITextUndoHistoryRegistry TextUndoHistoryRegistry
        {
            get
            {
                return ServiceProvider.GetComponentModel().DefaultExportProvider.GetExportedValue<ITextUndoHistoryRegistry>();
            }
        }

        public static ITextBufferFactoryService TextBufferFactoryService
        {
            get
            {
                return ServiceProvider.GetComponentModel().DefaultExportProvider.GetExportedValue<ITextBufferFactoryService>();
            }
        }

        public static IEditorOperationsFactoryService EditorOperationsFactoryService
        {
            get
            {
                return ServiceProvider.GetComponentModel().DefaultExportProvider.GetExportedValue<IEditorOperationsFactoryService>();
            }
        }

        [ClassInitialize]
        public static void PrepareSolution(TestContext context)
        {
            ContentTypeRegistryService.AddContentType(TestContentType, new[] { TextBufferFactoryService.TextContentType.TypeName });
        }

        private void TestSimpleLineComment(string initialText, string finalText, int caretPosition)
        {
            ITextBuffer textBuffer = TextBufferFactoryService.CreateTextBuffer(initialText, ContentTypeRegistryService.GetContentType(TestContentType));

            LineCommentFormat lineCommentFormat = new LineCommentFormat("//");
            FormatCommenter commenter = new FormatCommenter(textBuffer, lineCommentFormat);
            VirtualSnapshotPoint caret = new VirtualSnapshotPoint(textBuffer.CurrentSnapshot.Lines.First(), caretPosition);
            VirtualSnapshotSpan caretSpan = new VirtualSnapshotSpan(caret, caret);
            ReadOnlyCollection<VirtualSnapshotSpan> commentSpans = commenter.CommentSpans(new ReadOnlyCollection<VirtualSnapshotSpan>(new[] { caretSpan }));

            Assert.AreEqual(finalText, textBuffer.CurrentSnapshot.GetText());
            Assert.AreEqual(1, commentSpans.Count);
            Assert.AreEqual(0, commentSpans[0].Start.Position);
            Assert.AreEqual(initialText.Length + lineCommentFormat.StartText.Length, commentSpans[0].End.Position);
        }

        private void TestSimpleBlockComment(string initialText, string finalText, int caretPosition)
        {
            ITextBuffer textBuffer = TextBufferFactoryService.CreateTextBuffer(initialText, ContentTypeRegistryService.GetContentType(TestContentType));

            BlockCommentFormat blockCommentFormat = new BlockCommentFormat("/*", "*/");
            FormatCommenter commenter = new FormatCommenter(textBuffer, blockCommentFormat);
            VirtualSnapshotPoint caret = new VirtualSnapshotPoint(textBuffer.CurrentSnapshot.Lines.First(), caretPosition);
            VirtualSnapshotSpan caretSpan = new VirtualSnapshotSpan(caret, caret);
            ReadOnlyCollection<VirtualSnapshotSpan> commentSpans = commenter.CommentSpans(new ReadOnlyCollection<VirtualSnapshotSpan>(new[] { caretSpan }));

            Assert.AreEqual(finalText, textBuffer.CurrentSnapshot.GetText());
            Assert.AreEqual(1, commentSpans.Count);
            Assert.AreEqual(finalText.Length - finalText.TrimStart().Length, commentSpans[0].Start.Position);
            Assert.AreEqual(initialText.Length + blockCommentFormat.StartText.Length + blockCommentFormat.EndText.Length, commentSpans[0].End.Position);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleLineComment_CaretAtBOL()
        {
            string initialText = "    Initial text";
            string finalText = "    //Initial text";
            TestSimpleLineComment(initialText, finalText, 0);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleLineComment_CaretBeforeFirstNonWSChar()
        {
            string initialText = "    Initial text";
            string finalText = "    //Initial text";
            TestSimpleLineComment(initialText, finalText, 2);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleLineComment_CaretAtFirstNonWSChar()
        {
            string initialText = "    Initial text";
            string finalText = "    //Initial text";
            TestSimpleLineComment(initialText, finalText, 4);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleLineComment_CaretAtEOL()
        {
            string initialText = "    Initial text";
            string finalText = "    //Initial text";
            TestSimpleLineComment(initialText, finalText, initialText.Length);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleLineComment_CaretBeforeEOL()
        {
            string initialText = "    Initial text";
            string finalText = "    //Initial text";
            TestSimpleLineComment(initialText, finalText, initialText.Length - 2);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleLineComment_CaretAfterEOL()
        {
            string initialText = "    Initial text";
            string finalText = "    //Initial text";
            TestSimpleLineComment(initialText, finalText, initialText.Length + 2);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleBlockComment_CaretAtBOL()
        {
            string initialText = "    Initial text";
            string finalText = "    /*Initial text*/";
            TestSimpleBlockComment(initialText, finalText, 0);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleBlockComment_CaretBeforeFirstNonWSChar()
        {
            string initialText = "    Initial text";
            string finalText = "    /*Initial text*/";
            TestSimpleBlockComment(initialText, finalText, 2);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleBlockComment_CaretAtFirstNonWSChar()
        {
            string initialText = "    Initial text";
            string finalText = "    /*Initial text*/";
            TestSimpleBlockComment(initialText, finalText, 4);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleBlockComment_CaretAtEOL()
        {
            string initialText = "    Initial text";
            string finalText = "    /*Initial text*/";
            TestSimpleBlockComment(initialText, finalText, initialText.Length);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleBlockComment_CaretBeforeEOL()
        {
            string initialText = "    Initial text";
            string finalText = "    /*Initial text*/";
            TestSimpleBlockComment(initialText, finalText, initialText.Length - 2);
        }

        [TestMethod]
        [HostType("VS IDE")]
        public void TestSimpleBlockComment_CaretAfterEOL()
        {
            string initialText = "    Initial text";
            string finalText = "    /*Initial text*/";
            TestSimpleBlockComment(initialText, finalText, initialText.Length + 2);
        }
    }
}
