namespace Tvl.VisualStudio.Text.Commenter.Implementation
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.TextManager.Interop;
    using Tvl.VisualStudio.Shell;
    using Tvl.VisualStudio.Text.Commenter.Interfaces;
    using ITextBuffer = Microsoft.VisualStudio.Text.ITextBuffer;
    using OLECMDEXECOPT = Microsoft.VisualStudio.OLE.Interop.OLECMDEXECOPT;
    using OLECMDF = Microsoft.VisualStudio.OLE.Interop.OLECMDF;
    using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;

    /// <summary>
    /// This command filter provides support for commenting and uncommenting selections
    /// in the editor by delegating the implementation to an instance of
    /// <see cref="ICommenter"/>.
    /// </summary>
    [ComVisible(true)]
    internal class CommenterFilter : TextViewCommandFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommenterFilter"/> class for
        /// the specified text view and commenter.
        /// </summary>
        /// <param name="textViewAdapter"></param>
        /// <param name="textView">The text view.</param>
        /// <param name="commenter">The commenter implementation.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="textViewAdapter"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="textView"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="commenter"/> is <see langword="null"/>.</para>
        /// </exception>
        public CommenterFilter(IVsTextView textViewAdapter, ITextView textView, ICommenter commenter)
            : base(textViewAdapter)
        {
            Contract.Requires(textViewAdapter != null);
            Contract.Requires<ArgumentNullException>(textView != null, "textView");
            Contract.Requires<ArgumentNullException>(commenter != null, "commenter");

            this.TextView = textView;
            this.Commenter = commenter;
            textView.Closed += (sender, e) => Dispose();
        }

        /// <summary>
        /// Gets the <see cref="ITextView"/> which this filter is attached to.
        /// </summary>
        public ITextView TextView
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="ICommenter"/> which provides the implementation for the
        /// commenting and uncommenting operations.
        /// </summary>
        public ICommenter Commenter
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        /// <remarks>
        /// This command filter supports the <see cref="VsCommands2K.COMMENT_BLOCK"/>
        /// and <see cref="VsCommands2K.UNCOMMENT_BLOCK"/> commands. The commands are
        /// enabled when <see cref="ITextBuffer.CheckEditAccess"/> is <see langword="true"/>.
        /// </remarks>
        protected override OLECMDF QueryCommandStatus(ref Guid group, uint id, OleCommandText oleCommandText)
        {
            if (group == typeof(VsCommands2K).GUID)
            {
                VsCommands2K cmd = (VsCommands2K)id;
                switch (cmd)
                {
                case VsCommands2K.COMMENT_BLOCK:
                case VsCommands2K.UNCOMMENT_BLOCK:
                    if (TextView.TextBuffer.CheckEditAccess())
                        return OLECMDF.OLECMDF_SUPPORTED | OLECMDF.OLECMDF_ENABLED;
                    else
                        return OLECMDF.OLECMDF_SUPPORTED;
                }
            }

            return base.QueryCommandStatus(ref group, id, oleCommandText);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// This method handles execution of the <see cref="VsCommands2K.COMMENT_BLOCK"/>
        /// and <see cref="VsCommands2K.UNCOMMENT_BLOCK"/> commands by calling
        /// <see cref="CommentSelection"/> and <see cref="UncommentSelection"/> (respectively)
        /// and returning <see langword="true"/>.
        /// </remarks>
        protected override bool HandlePreExec(ref Guid commandGroup, uint commandId, OLECMDEXECOPT executionOptions, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (commandGroup == typeof(VsCommands2K).GUID)
            {
                VsCommands2K cmd = (VsCommands2K)commandId;
                switch (cmd)
                {
                case VsCommands2K.COMMENT_BLOCK:
                    this.CommentSelection();
                    return true;

                case VsCommands2K.UNCOMMENT_BLOCK:
                    this.UncommentSelection();
                    return true;
                }
            }

            return base.HandlePreExec(ref commandGroup, commandId, executionOptions, pvaIn, pvaOut);
        }

        /// <summary>
        /// Comment out the currently selected spans.
        /// </summary>
        /// <remarks>
        /// The base implementation calls <see cref="ICommenter.CommentSpans"/> to perform
        /// the commenting operation and update the currently selected spans. It then
        /// updates the selection in the editor to match the result of the operation.
        /// </remarks>
        protected virtual void CommentSelection()
        {
            bool reversed = TextView.Selection.IsReversed;
            var newSelection = Commenter.CommentSpans(TextView.Selection.VirtualSelectedSpans);
            // TODO: detect rectangle selection if present
            if (newSelection.Count > 0)
            {
                VirtualSnapshotPoint anchorPoint = reversed ? newSelection[0].End : newSelection[0].Start;
                VirtualSnapshotPoint activePoint = reversed ? newSelection[0].Start : newSelection[0].End;
                TextView.Selection.Select(anchorPoint, activePoint);
            }
        }

        /// <summary>
        /// Uncomment the currently selected spans.
        /// </summary>
        /// <remarks>
        /// The base implementation calls <see cref="ICommenter.UncommentSpans"/> to perform
        /// the uncommenting operation and update the currently selected spans. It then
        /// updates the selection in the editor to match the result of the operation.
        /// </remarks>
        protected virtual void UncommentSelection()
        {
            bool reversed = TextView.Selection.IsReversed;
            var newSelection = Commenter.UncommentSpans(TextView.Selection.VirtualSelectedSpans);
            // TODO: detect rectangle selection if present
            if (newSelection.Count > 0)
            {
                VirtualSnapshotPoint anchorPoint = reversed ? newSelection[0].End : newSelection[0].Start;
                VirtualSnapshotPoint activePoint = reversed ? newSelection[0].Start : newSelection[0].End;
                TextView.Selection.Select(anchorPoint, activePoint);
            }
        }
    }
}
