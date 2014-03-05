namespace Tvl.VisualStudio.Text.Commenter
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Operations;
    using Tvl.VisualStudio.Text.Commenter.Interfaces;

    /// <summary>
    /// This class provides a default implementation of <see cref="ICommenter"/> that provides
    /// standard comment and uncomment handling for languages supporting one or more comment
    /// formats.
    /// </summary>
    /// <threadsafety/>
    /// <preliminary/>
    public class Commenter : ICommenter
    {
        /// <summary>
        /// This is the backing field for the <see cref="TextView"/> property.
        /// </summary>
        private readonly ITextView _textView;

        /// <summary>
        /// This is the backing field for the <see cref="TextUndoHistoryRegistry"/> property.
        /// </summary>
        private readonly ITextUndoHistoryRegistry _textUndoHistoryRegistry;

        /// <summary>
        /// This is the backing field for the <see cref="CommentFormats"/> property.
        /// </summary>
        private readonly ReadOnlyCollection<CommentFormat> _commentFormats;

        /// <summary>
        /// This is the backing field for the <see cref="BlockFormats"/> and <see cref="PreferredBlockFormat"/> properties.
        /// </summary>
        private readonly ReadOnlyCollection<BlockCommentFormat> _blockFormats;

        /// <summary>
        /// This is the backing field for the <see cref="LineFormats"/> and <see cref="PreferredLineFormat"/> properties.
        /// </summary>
        private readonly ReadOnlyCollection<LineCommentFormat> _lineFormats;

        /// <summary>
        /// This is the backing field for the <see cref="UseLineComments"/> property.
        /// </summary>
        private readonly bool _useLineComments;

        /// <summary>
        /// Initializes a new instance of the <see cref="Commenter"/> class for the specified text view, undo history, and comment formats.
        /// </summary>
        /// <param name="textView">The text view.</param>
        /// <param name="textUndoHistoryRegistry">The global <see cref="ITextUndoHistoryRegistry"/> service provided by Visual Studio.</param>
        /// <param name="commentFormats">A collection of <see cref="CommentFormat"/> instances describing the comment formats supported by this commenter.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="textView"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="textUndoHistoryRegistry"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="commentFormats"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="commentFormats"/> contains any <see langword="null"/> entries.
        /// </exception>
        public Commenter(ITextView textView, ITextUndoHistoryRegistry textUndoHistoryRegistry, params CommentFormat[] commentFormats)
            : this(textView, textUndoHistoryRegistry, commentFormats.AsEnumerable())
        {
            Contract.Requires(textView != null);
            Contract.Requires(textUndoHistoryRegistry != null);
            Contract.Requires(commentFormats != null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Commenter"/> class for the specified text view, undo history, and comment formats.
        /// </summary>
        /// <param name="textView">The text view.</param>
        /// <param name="textUndoHistoryRegistry">The global <see cref="ITextUndoHistoryRegistry"/> service provided by Visual Studio.</param>
        /// <param name="commentFormats">A collection of <see cref="CommentFormat"/> instances describing the comment formats supported by this commenter.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="textView"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="textUndoHistoryRegistry"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="commentFormats"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="commentFormats"/> contains any <see langword="null"/> entries.
        /// </exception>
        public Commenter(ITextView textView, ITextUndoHistoryRegistry textUndoHistoryRegistry, IEnumerable<CommentFormat> commentFormats)
        {
            Contract.Requires<ArgumentNullException>(textView != null, "textView");
            Contract.Requires<ArgumentNullException>(textUndoHistoryRegistry != null, "textUndoHistoryRegistry");
            Contract.Requires<ArgumentNullException>(commentFormats != null, "commentFormats");
            Contract.Requires<ArgumentException>(!commentFormats.Contains(null));

            this._textView = textView;
            this._textUndoHistoryRegistry = textUndoHistoryRegistry;
            this._commentFormats = commentFormats.ToList().AsReadOnly();
            this._blockFormats = _commentFormats.OfType<BlockCommentFormat>().ToList().AsReadOnly();
            this._lineFormats = _commentFormats.OfType<LineCommentFormat>().ToList().AsReadOnly();
            this._useLineComments = this._lineFormats.Count > 0;
        }

        /// <summary>
        /// Gets the underlying <see cref="ITextView"/> for this commenter.
        /// </summary>
        public ITextView TextView
        {
            get
            {
                Contract.Ensures(Contract.Result<ITextView>() != null);
                return _textView;
            }
        }

        /// <summary>
        /// Gets a collection of all comment formats recognized by this commenter.
        /// </summary>
        public virtual ReadOnlyCollection<CommentFormat> CommentFormats
        {
            get
            {
                Contract.Ensures(Contract.Result<ReadOnlyCollection<CommentFormat>>() != null);
                return _commentFormats;
            }
        }

        /// <summary>
        /// Gets a collection of block comment formats recognized by this commenter.
        /// </summary>
        public virtual ReadOnlyCollection<BlockCommentFormat> BlockFormats
        {
            get
            {
                Contract.Ensures(Contract.Result<ReadOnlyCollection<BlockCommentFormat>>() != null);
                return _blockFormats;
            }
        }

        /// <summary>
        /// Gets the preferred <see cref="BlockCommentFormat"/> to use when creating new block comments.
        /// </summary>
        /// <value>
        /// The preferred <see cref="BlockCommentFormat"/>, or <see langword="null"/> if <see cref="BlockFormats"/> is empty.
        /// </value>
        public virtual BlockCommentFormat PreferredBlockFormat
        {
            get
            {
                var formats = BlockFormats;
                if (formats == null || formats.Count == 0)
                    return null;

                return formats[0];
            }
        }

        /// <summary>
        /// Gets a collection of line comment formats recognized by this commenter.
        /// </summary>
        public virtual ReadOnlyCollection<LineCommentFormat> LineFormats
        {
            get
            {
                Contract.Ensures(Contract.Result<ReadOnlyCollection<LineCommentFormat>>() != null);
                return _lineFormats;
            }
        }

        /// <summary>
        /// Gets the preferred <see cref="LineCommentFormat"/> to use when creating new line comments.
        /// </summary>
        /// <value>
        /// The preferred <see cref="LineCommentFormat"/>, or <see langword="null"/> if <see cref="LineFormats"/> is empty.
        /// </value>
        public virtual LineCommentFormat PreferredLineFormat
        {
            get
            {
                var formats = LineFormats;
                if (formats == null || formats.Count == 0)
                    return null;

                return formats[0];
            }
        }

        /// <summary>
        /// Gets whether the commenter should prefer to use line comments, even when a block comment format
        /// is available and the input span(s) to <see cref="CommentSpans"/> cross multiple lines and would
        /// normally support a block comment.
        /// </summary>
        public virtual bool UseLineComments
        {
            get
            {
                return _useLineComments;
            }
        }

        /// <summary>
        /// Gets the global <see cref="ITextUndoHistoryRegistry"/> service provided by Visual Studio.
        /// </summary>
        protected ITextUndoHistoryRegistry TextUndoHistoryRegistry
        {
            get
            {
                Contract.Ensures(Contract.Result<ITextUndoHistoryRegistry>() != null);
                return _textUndoHistoryRegistry;
            }
        }

        /// <inheritdoc/>
        public virtual NormalizedSnapshotSpanCollection CommentSpans(NormalizedSnapshotSpanCollection spans)
        {
            List<SnapshotSpan> result = new List<SnapshotSpan>();

            if (spans.Count == 0)
                return new NormalizedSnapshotSpanCollection();

            var undoHistory = TextUndoHistoryRegistry.RegisterHistory(TextView);
            using (var transaction = undoHistory.CreateTransaction("Comment Selection"))
            {
                ITextSnapshot snapshot = spans[0].Snapshot;

                using (var edit = snapshot.TextBuffer.CreateEdit())
                {
                    foreach (var span in spans)
                    {
                        var selection = CommentSpan(span, edit);
                        result.Add(selection);
                    }

                    edit.Apply();
                }

                if (snapshot != TextView.TextSnapshot)
                    transaction.Complete();
            }

            if (result.Count > 1)
                result.RemoveAll(span => span.IsEmpty);

            var target = TextView.TextBuffer.CurrentSnapshot;
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].TranslateTo(target, SpanTrackingMode.EdgeInclusive);
            }

            return new NormalizedSnapshotSpanCollection(result);
        }

        /// <inheritdoc/>
        public virtual NormalizedSnapshotSpanCollection UncommentSpans(NormalizedSnapshotSpanCollection spans)
        {
            List<SnapshotSpan> result = new List<SnapshotSpan>();

            if (spans.Count == 0)
                return new NormalizedSnapshotSpanCollection();

            var undoHistory = TextUndoHistoryRegistry.RegisterHistory(TextView);
            using (var transaction = undoHistory.CreateTransaction("Uncomment Selection"))
            {
                ITextSnapshot snapshot = spans[0].Snapshot;

                using (var edit = snapshot.TextBuffer.CreateEdit())
                {
                    foreach (var span in spans)
                    {
                        var selection = UncommentSpan(span, edit);
                        result.Add(selection);
                    }

                    edit.Apply();
                }

                if (snapshot != TextView.TextSnapshot)
                    transaction.Complete();
            }

            if (result.Count > 1)
                result.RemoveAll(span => span.IsEmpty);

            var target = TextView.TextBuffer.CurrentSnapshot;
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].TranslateTo(target, SpanTrackingMode.EdgeInclusive);
            }

            return new NormalizedSnapshotSpanCollection(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// The default implementation uses line comments if <see cref="UseLineComments"/> is <see langword="true"/>
        /// and one of the following is true.
        /// <list type="number">
        /// <item>There is no selected text.</item>
        /// <item>
        /// On the line where the selection starts, there is only whitespace up to the selection start point, <strong>and</strong>
        /// one of the following is true.
        /// <list type="bullet">
        /// <item>On the line where the selection ends, there is only whitespace up to the selection end point, <strong>or</strong></item>
        /// <item>There is only whitespace from the selection end point to the end of the line.</item>
        /// </list>
        /// </item>
        /// </list>
        /// 
        /// The default implementation uses block comments if <em>all</em> of the following are true.
        /// <list type="bullet">
        /// <item>We are not using line comments.</item>
        /// <item>Some text is selected.</item>
        /// <item><see cref="PreferredBlockFormat"/> is not <see langword="null"/>.</item>
        /// </list>
        /// </remarks>
        /// <param name="span">The span of text to comment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> to apply the changes to.</param>
        /// <returns>A <see cref="SnapshotSpan"/> containing the commented code.</returns>
        protected virtual SnapshotSpan CommentSpan(SnapshotSpan span, ITextEdit edit)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");

            span = span.TranslateTo(edit.Snapshot, SpanTrackingMode.EdgeExclusive);

            var startContainingLine = span.Start.GetContainingLine();
            var endContainingLine = span.End.GetContainingLine();

            if (UseLineComments
                && (span.IsEmpty ||
                    (string.IsNullOrWhiteSpace(startContainingLine.GetText().Substring(0, span.Start - startContainingLine.Start))
                        && (string.IsNullOrWhiteSpace(endContainingLine.GetText().Substring(0, span.End - endContainingLine.Start))
                            || string.IsNullOrWhiteSpace(endContainingLine.GetText().Substring(span.End - endContainingLine.Start)))
                   )))
            {
                span = CommentLines(span, edit, PreferredLineFormat);
            }
            else if (
                span.Length > 0
                && PreferredBlockFormat != null
                )
            {
                span = CommentBlock(span, edit, PreferredBlockFormat);
            }

            return span;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// The default algorithm for line comments is designed to meet the following conditions.
        /// <list type="bullet">
        /// <item>Make sure line comments are indented as far as possible, skipping empty lines as necessary.</item>
        /// <item>Don't comment N+1 lines when only N lines were selected by clicking in the left margin.</item>
        /// </list>
        /// </remarks>
        /// <param name="span"></param>
        /// <param name="edit"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        protected virtual SnapshotSpan CommentLines(SnapshotSpan span, ITextEdit edit, LineCommentFormat format)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(format != null, "format");

            if (span.End.GetContainingLine().LineNumber > span.Start.GetContainingLine().LineNumber && span.End.GetContainingLine().Start == span.End)
            {
                SnapshotPoint start = span.Start;
                SnapshotPoint end = span.Snapshot.GetLineFromLineNumber(span.End.GetContainingLine().LineNumber - 1).Start;
                if (end < start)
                    start = end;

                span = new SnapshotSpan(start, end);
            }

            int minindex = (from i in Enumerable.Range(span.Start.GetContainingLine().LineNumber, span.End.GetContainingLine().LineNumber - span.Start.GetContainingLine().LineNumber + 1)
                            where span.Snapshot.GetLineFromLineNumber(i).GetText().Trim().Length > 0
                            select ScanToNonWhitespaceChar(span.Snapshot.GetLineFromLineNumber(i)))
                           .Min();

            //comment each line
            for (int line = span.Start.GetContainingLine().LineNumber; line <= span.End.GetContainingLine().LineNumber; line++)
            {
                if (span.Snapshot.GetLineFromLineNumber(line).GetText().Trim().Length > 0)
                    edit.Insert(span.Snapshot.GetLineFromLineNumber(line).Start + minindex, format.StartText);
            }

            span = new SnapshotSpan(span.Start.GetContainingLine().Start, span.End.GetContainingLine().End);
            return span;
        }

        /// <summary>
        /// Comment out a span of text using the specified block comment format. If the span is empty, the
        /// entire line containing the span's start point is commented.
        /// </summary>
        /// <param name="span">The span of text to comment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> to use for applying changes.</param>
        /// <param name="format">The block comment format.</param>
        /// <returns>The span of text which was commented.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="edit"/> is <see langword="null"/>.
        /// <para>-or-</para>
        /// <para>If <paramref name="format"/> is <see langword="null"/>.</para>
        /// </exception>
        protected virtual SnapshotSpan CommentBlock(SnapshotSpan span, ITextEdit edit, BlockCommentFormat format)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(format != null, "format");

            //special case no selection
            if (span.IsEmpty)
            {
                span = new SnapshotSpan(span.Start.GetContainingLine().Start + ScanToNonWhitespaceChar(span.Start.GetContainingLine()), span.End.GetContainingLine().End);
            }

            // add start comment
            edit.Insert(span.Start, format.StartText);
            // add end comment
            edit.Insert(span.End, format.EndText);

            return span;
        }

        /// <summary>
        /// Uncomment the span of text.
        /// </summary>
        /// <param name="span">The span of text to uncomment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> instance to use for applying changes.</param>
        /// <returns>The span of text which was uncommented.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="edit"/> is <see langword="null"/>.</exception>
        protected virtual SnapshotSpan UncommentSpan(SnapshotSpan span, ITextEdit edit)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");

            span = span.TranslateTo(edit.Snapshot, SpanTrackingMode.EdgeExclusive);
            bool useLineComments = true;
            var startContainingLine = span.Start.GetContainingLine();
            var endContainingLine = span.End.GetContainingLine();

            // special case: empty span
            if (span.IsEmpty)
            {
                if (useLineComments)
                    span = UncommentLines(span, edit, LineFormats);
            }
            else
            {
                SnapshotSpan resultSpan;
                if (TryUncommentBlock(span, edit, BlockFormats, out resultSpan))
                    return resultSpan;

                if (useLineComments)
                {
                    span = UncommentLines(span, edit, LineFormats);
                }
            }

            return span;
        }

        protected virtual SnapshotSpan UncommentLines(SnapshotSpan span, ITextEdit edit, ReadOnlyCollection<LineCommentFormat> formats)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(formats != null, "formats");
            Contract.Requires(Contract.ForAll(formats, i => i != null));

            if (span.End.GetContainingLine().LineNumber > span.Start.GetContainingLine().LineNumber && span.End == span.End.GetContainingLine().Start)
            {
                SnapshotPoint start = span.Start;
                SnapshotPoint end = span.Snapshot.GetLineFromLineNumber(span.End.GetContainingLine().LineNumber - 1).Start;
                if (end < start)
                    start = end;

                span = new SnapshotSpan(start, end);
            }

            // Remove line comments
            for (int line = span.Start.GetContainingLine().LineNumber; line <= span.End.GetContainingLine().LineNumber; line++)
            {
                int i = ScanToNonWhitespaceChar(span.Snapshot.GetLineFromLineNumber(line));
                string text = span.Snapshot.GetLineFromLineNumber(line).GetText();
                foreach (var format in formats)
                {
                    int clen = format.StartText.Length;
                    if ((text.Length > i + clen) && text.Substring(i, clen) == format.StartText)
                    {
                        // remove line comment.
                        edit.Delete(span.Snapshot.GetLineFromLineNumber(line).Start.Position + i, clen);
                        break;
                    }
                }
            }

            span = new SnapshotSpan(span.Start.GetContainingLine().Start, span.End.GetContainingLine().End);
            return span;
        }

        protected virtual bool TryUncommentBlock(SnapshotSpan span, ITextEdit edit, ReadOnlyCollection<BlockCommentFormat> formats, out SnapshotSpan result)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(formats != null, "formats");
            Contract.Requires(Contract.ForAll(formats, i => i != null));

            foreach (var format in formats)
            {
                if (TryUncommentBlock(span, edit, format, out result))
                    return true;
            }

            result = default(SnapshotSpan);
            return false;
        }

        protected virtual bool TryUncommentBlock(SnapshotSpan span, ITextEdit edit, BlockCommentFormat format, out SnapshotSpan result)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(format != null, "format");

            string blockStart = format.StartText;
            string blockEnd = format.EndText;

            int startLen = span.Start.GetContainingLine().Length;
            int endLen = span.End.GetContainingLine().Length;

            TrimSpan(ref span);

            //special case no selection, try and uncomment the current line.
            if (span.IsEmpty)
            {
                span = new SnapshotSpan(span.Start.GetContainingLine().Start + ScanToNonWhitespaceChar(span.Start.GetContainingLine()), span.End.GetContainingLine().End);
            }

            // Check that comment start and end blocks are possible.
            if ((span.Start - span.Start.GetContainingLine().Start) + blockStart.Length <= startLen && (span.End - span.End.GetContainingLine().Start) - blockStart.Length >= 0)
            {
                string startText = span.Snapshot.GetText(span.Start.Position, blockStart.Length);

                if (startText == blockStart)
                {
                    SnapshotSpan linespan = span;
                    linespan = new SnapshotSpan(span.End - blockEnd.Length, span.End);
                    string endText = linespan.GetText();
                    if (endText == blockEnd)
                    {
                        //yes, block comment selected; remove it
                        edit.Delete(linespan);
                        edit.Delete(span.Start.Position, blockStart.Length);
                        result = span;
                        return true;
                    }
                }
            }

            result = default(SnapshotSpan);
            return false;
        }

        protected static void TrimSpan(ref SnapshotSpan span)
        {
            string text = span.GetText();
            int length = text.Trim().Length;

            int offset = 0;
            while (offset < text.Length && char.IsWhiteSpace(text[offset]))
                offset++;

            if (offset > 0 || length != text.Length)
                span = new SnapshotSpan(span.Start + offset, length);
        }

        protected static int ScanToNonWhitespaceChar(ITextSnapshotLine line)
        {
            Contract.Requires<ArgumentNullException>(line != null, "line");

            string text = line.GetText();
            int len = text.Length;
            int i = 0;
            while (i < len && char.IsWhiteSpace(text[i]))
            {
                i++;
            }
            return i;
        }
    }
}
