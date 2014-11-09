namespace Tvl.VisualStudio.Text.Commenter
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Microsoft.VisualStudio.Text;
    using Tvl.VisualStudio.Text.Commenter.Interfaces;

    /// <summary>
    /// This class provides a default implementation of <see cref="ICommenter"/> that provides
    /// standard comment and uncomment handling for languages supporting one or more comment
    /// formats.
    /// </summary>
    /// <threadsafety/>
    public class FormatCommenter : ICommenter
    {
        /// <summary>
        /// This is the backing field for the <see cref="TextBuffer"/> property.
        /// </summary>
        private readonly ITextBuffer _textBuffer;

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
        /// Initializes a new instance of the <see cref="FormatCommenter"/> class for the specified text buffer, undo
        /// history, and comment formats.
        /// </summary>
        /// <param name="textBuffer">The text buffer.</param>
        /// <param name="commentFormats">A collection of <see cref="CommentFormat"/> instances describing the comment
        /// formats supported by this commenter.</param>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="textBuffer"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="commentFormats"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="commentFormats"/> contains any <see langword="null"/> entries.
        /// </exception>
        public FormatCommenter(ITextBuffer textBuffer, params CommentFormat[] commentFormats)
            : this(textBuffer, commentFormats.AsEnumerable())
        {
            Contract.Requires(textBuffer != null);
            Contract.Requires(commentFormats != null);
        }

        /// <inheritdoc cref="FormatCommenter(ITextBuffer, CommentFormat[])"/>
        public FormatCommenter(ITextBuffer textBuffer, IEnumerable<CommentFormat> commentFormats)
        {
            Contract.Requires<ArgumentNullException>(textBuffer != null, "textBuffer");
            Contract.Requires<ArgumentNullException>(commentFormats != null, "commentFormats");
            Contract.Requires<ArgumentException>(!commentFormats.Contains(null));

            this._textBuffer = textBuffer;
            this._commentFormats = commentFormats.ToList().AsReadOnly();
            this._blockFormats = _commentFormats.OfType<BlockCommentFormat>().ToList().AsReadOnly();
            this._lineFormats = _commentFormats.OfType<LineCommentFormat>().ToList().AsReadOnly();
            this._useLineComments = this._lineFormats.Count > 0;
        }

        /// <summary>
        /// Gets the underlying <see cref="ITextBuffer"/> for this commenter.
        /// </summary>
        /// <value>
        /// The underlying <see cref="ITextBuffer"/> for this commenter.
        /// </value>
        public ITextBuffer TextBuffer
        {
            get
            {
                Contract.Ensures(Contract.Result<ITextBuffer>() != null);
                return _textBuffer;
            }
        }

        /// <summary>
        /// Gets a collection of all comment formats recognized by this commenter.
        /// </summary>
        /// <value>
        /// A collection of all comment formats recognized by this commenter.
        /// </value>
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
        /// <value>
        /// A collection of block comment formats recognized by this commenter.
        /// </value>
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
        /// <para>The preferred <see cref="BlockCommentFormat"/>.</para>
        /// <para>-or-</para>
        /// <para><see langword="null"/> if this commenter does not support creating block comments with the Comment
        /// command.</para>
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
        /// <value>
        /// A collection of line comment formats recognized by this commenter.
        /// </value>
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
        /// <para>The preferred <see cref="LineCommentFormat"/>.</para>
        /// <para>-or-</para>
        /// <para><see langword="null"/> if this commenter does not support creating line comments with the Comment
        /// command.</para>
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
        /// Gets whether the commenter should prefer to use line comments when commenting selections of code.
        /// </summary>
        /// <remarks>
        /// <para>The default implementation returns <see langword="true"/> when <see cref="PreferredLineFormat"/> is
        /// not <see langword="null"/>. This property may be overridden to specify that block comments should be used
        /// whenever possible for the creating of new comments with the Comment command.</para>
        /// </remarks>
        /// <value>
        /// <para><see langword="true"/> to use line comments whenever possible for the
        /// <strong>Selection Comment</strong> command.</para>
        /// <para>-or-</para>
        /// <para><see langword="false"/> to use block comments whenever possible for the
        /// <strong>Selection Comment</strong> command.</para>
        /// </value>
        public virtual bool UseLineComments
        {
            get
            {
                return _useLineComments;
            }
        }

        /// <inheritdoc/>
        public virtual ReadOnlyCollection<VirtualSnapshotSpan> CommentSpans(ReadOnlyCollection<VirtualSnapshotSpan> spans)
        {
            List<VirtualSnapshotSpan> result = new List<VirtualSnapshotSpan>();

            if (spans.Count == 0)
                return new ReadOnlyCollection<VirtualSnapshotSpan>(new VirtualSnapshotSpan[0]);

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

            if (result.Count > 1)
                result.RemoveAll(span => span.IsEmpty);

            var target = TextBuffer.CurrentSnapshot;
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].TranslateTo(target, SpanTrackingMode.EdgeInclusive);
            }

            return result.AsReadOnly();
        }

        /// <inheritdoc/>
        public virtual ReadOnlyCollection<VirtualSnapshotSpan> UncommentSpans(ReadOnlyCollection<VirtualSnapshotSpan> spans)
        {
            List<VirtualSnapshotSpan> result = new List<VirtualSnapshotSpan>();

            if (spans.Count == 0)
                return new ReadOnlyCollection<VirtualSnapshotSpan>(new VirtualSnapshotSpan[0]);

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

            if (result.Count > 1)
                result.RemoveAll(span => span.IsEmpty);

            var target = TextBuffer.CurrentSnapshot;
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].TranslateTo(target, SpanTrackingMode.EdgeInclusive);
            }

            return result.AsReadOnly();
        }

        /// <summary>
        /// Comment out the code in a single <see cref="VirtualSnapshotSpan"/>.
        /// </summary>
        /// <remarks>
        /// <para>The default implementation uses line comments if <see cref="UseLineComments"/> is
        /// <see langword="true"/> and one of the following is true.</para>
        /// <list type="number">
        /// <item>There is no selected text.</item>
        /// <item>
        /// On the line where the selection starts, there is only whitespace up to the selection start point,
        /// <strong>and</strong> one of the following is true.
        /// <list type="bullet">
        /// <item>On the line where the selection ends, there is only whitespace up to the selection end point,
        /// <strong>or</strong></item>
        /// <item>There is only whitespace from the selection end point to the end of the line.</item>
        /// </list>
        /// </item>
        /// </list>
        ///
        /// <para>The default implementation uses block comments if <em>all</em> of the following are true.</para>
        /// <list type="bullet">
        /// <item>We are not using line comments.</item>
        /// <item><see cref="PreferredBlockFormat"/> is not <see langword="null"/>.</item>
        /// </list>
        /// </remarks>
        /// <param name="span">The span of text to comment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> to apply the changes to.</param>
        /// <returns>A <see cref="VirtualSnapshotSpan"/> containing the commented code.</returns>
        protected virtual VirtualSnapshotSpan CommentSpan(VirtualSnapshotSpan span, ITextEdit edit)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");

            span = span.TranslateTo(edit.Snapshot, SpanTrackingMode.EdgeExclusive);

            var startContainingLine = span.Start.Position.GetContainingLine();
            var endContainingLine = span.End.Position.GetContainingLine();

            if (UseLineComments
                && (span.IsEmpty ||
                    (string.IsNullOrWhiteSpace(startContainingLine.GetText().Substring(0, span.Start.Position - startContainingLine.Start))
                        && (string.IsNullOrWhiteSpace(endContainingLine.GetText().Substring(0, span.End.Position - endContainingLine.Start))
                            || string.IsNullOrWhiteSpace(endContainingLine.GetText().Substring(span.End.Position - endContainingLine.Start)))
                   )))
            {
                span = CommentLines(span, edit, PreferredLineFormat);
            }
            else if (PreferredBlockFormat != null)
            {
                span = CommentBlock(span, edit, PreferredBlockFormat);
            }

            return span;
        }

        /// <summary>
        /// Comment out a span using a particular line comment format. If the <paramref name="span"/> is empty, the
        /// entire line containing the span's start point is commented.
        /// </summary>
        /// <remarks>
        /// <para>The default algorithm for line comments is designed to meet the following conditions.</para>
        /// <list type="bullet">
        /// <item>Make sure line comments are indented as far as possible, skipping empty lines as necessary.</item>
        /// <item>Don't comment <em>N</em>+1 lines when only <em>N</em> lines were selected by clicking in the left
        /// margin.</item>
        /// </list>
        /// </remarks>
        /// <param name="span">The span of text to comment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> to apply the changes to.</param>
        /// <param name="format">The line comment format to use for commenting the code.</param>
        /// <returns>A <see cref="VirtualSnapshotSpan"/> containing the commented code.</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="edit"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="format"/> is <see langword="null"/>.</para>
        /// </exception>
        protected virtual VirtualSnapshotSpan CommentLines(VirtualSnapshotSpan span, ITextEdit edit, LineCommentFormat format)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(format != null, "format");

            if (span.End.Position.GetContainingLine().LineNumber > span.Start.Position.GetContainingLine().LineNumber && span.End.Position.GetContainingLine().Start == span.End.Position)
            {
                VirtualSnapshotPoint start = span.Start;
                VirtualSnapshotPoint end = new VirtualSnapshotPoint(span.Snapshot.GetLineFromLineNumber(span.End.Position.GetContainingLine().LineNumber - 1).Start);
                if (end < start)
                    start = end;

                span = new VirtualSnapshotSpan(start, end);
            }

            int minindex = (from i in Enumerable.Range(span.Start.Position.GetContainingLine().LineNumber, span.End.Position.GetContainingLine().LineNumber - span.Start.Position.GetContainingLine().LineNumber + 1)
                            where span.Snapshot.GetLineFromLineNumber(i).GetText().Trim().Length > 0
                            select ScanToNonWhitespaceChar(span.Snapshot.GetLineFromLineNumber(i)))
                           .Min();

            //comment each line
            for (int line = span.Start.Position.GetContainingLine().LineNumber; line <= span.End.Position.GetContainingLine().LineNumber; line++)
            {
                if (span.Snapshot.GetLineFromLineNumber(line).GetText().Trim().Length > 0)
                    edit.Insert(span.Snapshot.GetLineFromLineNumber(line).Start + minindex, format.StartText);
            }

            span = new VirtualSnapshotSpan(new SnapshotSpan(span.Start.Position.GetContainingLine().Start, span.End.Position.GetContainingLine().End));
            return span;
        }

        /// <summary>
        /// Comment out a span of text using the specified block comment format. If the <paramref name="span"/> is
        /// empty, the entire line containing the span's start point is commented.
        /// </summary>
        /// <param name="span">The span of text to comment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> to use for applying changes.</param>
        /// <param name="format">The block comment format.</param>
        /// <returns>A <see cref="VirtualSnapshotSpan"/> containing the commented code.</returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="edit"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="format"/> is <see langword="null"/>.</para>
        /// </exception>
        protected virtual VirtualSnapshotSpan CommentBlock(VirtualSnapshotSpan span, ITextEdit edit, BlockCommentFormat format)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(format != null, "format");

            //special case no selection
            if (span.IsEmpty)
            {
                VirtualSnapshotPoint start = new VirtualSnapshotPoint(span.Start.Position.GetContainingLine().Start + ScanToNonWhitespaceChar(span.Start.Position.GetContainingLine()));
                VirtualSnapshotPoint end = span.IsInVirtualSpace ? span.End : new VirtualSnapshotPoint(span.End.Position.GetContainingLine().End);
                span = new VirtualSnapshotSpan(start, end);
            }

            // add start comment
            edit.Insert(span.Start.Position, format.StartText);
            // add end comment
            edit.Insert(span.End.Position, format.EndText);

            return span;
        }

        /// <summary>
        /// Uncomment the span of text.
        /// </summary>
        /// <param name="span">The span of text to uncomment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> instance to use for applying changes.</param>
        /// <returns>A <see cref="VirtualSnapshotSpan"/> containing the uncommented code.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="edit"/> is <see langword="null"/>.</exception>
        protected virtual VirtualSnapshotSpan UncommentSpan(VirtualSnapshotSpan span, ITextEdit edit)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");

            span = span.TranslateTo(edit.Snapshot, SpanTrackingMode.EdgeExclusive);
            bool useLineComments = true;
            var startContainingLine = span.Start.Position.GetContainingLine();
            var endContainingLine = span.End.Position.GetContainingLine();

            // special case: empty span
            if (span.IsEmpty)
            {
                if (useLineComments)
                    TryUncommentLines(span, edit, LineFormats, out span);
            }
            else
            {
                VirtualSnapshotSpan resultSpan;
                if (TryUncommentBlock(span, edit, BlockFormats, out resultSpan))
                    return resultSpan;

                if (useLineComments)
                {
                    TryUncommentLines(span, edit, LineFormats, out span);
                }
            }

            return span;
        }

        /// <summary>
        /// Attempt to uncomment a span of text using any of a collection of line comment formats.
        /// </summary>
        /// <param name="span">The span of text to uncomment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> instance to use for applying changes.</param>
        /// <param name="formats">The line comment formats to use for attempting to uncomment the code.</param>
        /// <param name="result">Upon return, a <see cref="VirtualSnapshotSpan"/> containing the uncommented
        /// code.</param>
        /// <returns>
        /// <para><see langword="true"/> if one or more lines of the span of text were successfully uncommented using
        /// one of the specified line comment <paramref name="formats"/>.</para>
        /// <para>-or-</para>
        /// <para><see langword="false"/> if none of the lines in the span of text could be uncommented using any of the
        /// specified <paramref name="formats"/>.</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="edit"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="formats"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="formats"/> contains any <see langword="null"/>
        /// values.</exception>
        protected virtual bool TryUncommentLines(VirtualSnapshotSpan span, ITextEdit edit, ReadOnlyCollection<LineCommentFormat> formats, out VirtualSnapshotSpan result)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(formats != null, "formats");
            Contract.Requires(Contract.ForAll(formats, i => i != null));

            if (span.End.Position.GetContainingLine().LineNumber > span.Start.Position.GetContainingLine().LineNumber && span.End.Position == span.End.Position.GetContainingLine().Start)
            {
                VirtualSnapshotPoint start = span.Start;
                VirtualSnapshotPoint end = new VirtualSnapshotPoint(span.Snapshot.GetLineFromLineNumber(span.End.Position.GetContainingLine().LineNumber - 1).Start);
                if (end < start)
                    start = end;

                span = new VirtualSnapshotSpan(start, end);
            }

            // Remove line comments
            bool containedComments = false;
            for (int line = span.Start.Position.GetContainingLine().LineNumber; line <= span.End.Position.GetContainingLine().LineNumber; line++)
            {
                int i = ScanToNonWhitespaceChar(span.Snapshot.GetLineFromLineNumber(line));
                string text = span.Snapshot.GetLineFromLineNumber(line).GetText();
                foreach (var format in formats)
                {
                    int clen = format.StartText.Length;
                    if ((text.Length > i + clen) && text.Substring(i, clen).Equals(format.StartText, StringComparison.Ordinal))
                    {
                        // remove line comment.
                        edit.Delete(span.Snapshot.GetLineFromLineNumber(line).Start.Position + i, clen);
                        containedComments = true;
                        break;
                    }
                }
            }

            span = new VirtualSnapshotSpan(new SnapshotSpan(span.Start.Position.GetContainingLine().Start, span.End.Position.GetContainingLine().End));
            result = span;
            return containedComments;
        }

        /// <summary>
        /// Attempt to uncomment a span of text using any of a collection of block comment formats.
        /// </summary>
        /// <param name="span">The span of text to uncomment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> instance to use for applying changes.</param>
        /// <param name="formats">The block comment formats to use for attempting to uncomment the code.</param>
        /// <param name="result">Upon return, a <see cref="VirtualSnapshotSpan"/> containing the uncommented
        /// code.</param>
        /// <returns>
        /// <para><see langword="true"/> if the span of text was successfully uncommented using one of the specified
        /// block comment <paramref name="formats"/>.</para>
        /// <para>-or-</para>
        /// <para><see langword="false"/> if the span of text was not a complete block comment using any of the
        /// specified <paramref name="formats"/>.</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="edit"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="formats"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="formats"/> contains any <see langword="null"/>
        /// values.</exception>
        protected virtual bool TryUncommentBlock(VirtualSnapshotSpan span, ITextEdit edit, ReadOnlyCollection<BlockCommentFormat> formats, out VirtualSnapshotSpan result)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(formats != null, "formats");
            Contract.Requires(Contract.ForAll(formats, i => i != null));

            foreach (var format in formats)
            {
                if (TryUncommentBlock(span, edit, format, out result))
                    return true;
            }

            result = default(VirtualSnapshotSpan);
            return false;
        }

        /// <summary>
        /// Attempt to uncomment a span of text using a particular block comment format.
        /// </summary>
        /// <param name="span">The span of text to uncomment.</param>
        /// <param name="edit">The <see cref="ITextEdit"/> instance to use for applying changes.</param>
        /// <param name="format">The block comment format to use for uncommenting the code.</param>
        /// <param name="result">Upon return, a <see cref="VirtualSnapshotSpan"/> containing the uncommented
        /// code.</param>
        /// <returns>
        /// <para><see langword="true"/> if the span of text was uncommented using the specified block comment
        /// <paramref name="format"/>.</para>
        /// <para>-or-</para>
        /// <para>false if the span of text was not a complete block comment with the specified
        /// <paramref name="format"/>.</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="edit"/> is <see langword="null"/>.</exception>
        protected virtual bool TryUncommentBlock(VirtualSnapshotSpan span, ITextEdit edit, BlockCommentFormat format, out VirtualSnapshotSpan result)
        {
            Contract.Requires<ArgumentNullException>(edit != null, "edit");
            Contract.Requires<ArgumentNullException>(format != null, "format");

            string blockStart = format.StartText;
            string blockEnd = format.EndText;

            int startLen = span.Start.Position.GetContainingLine().Length;
            int endLen = span.End.Position.GetContainingLine().Length;

            TrimSpan(ref span);

            //special case no selection, try and uncomment the current line.
            if (span.IsEmpty)
            {
                VirtualSnapshotPoint start = new VirtualSnapshotPoint(span.Start.Position.GetContainingLine().Start + ScanToNonWhitespaceChar(span.Start.Position.GetContainingLine()));
                VirtualSnapshotPoint end = span.IsInVirtualSpace ? span.End : new VirtualSnapshotPoint(span.End.Position.GetContainingLine().End);
                span = new VirtualSnapshotSpan(start, end);
            }

            // Check that comment start and end blocks are possible.
            if ((span.Start.Position - span.Start.Position.GetContainingLine().Start) + blockStart.Length <= startLen && (span.End.Position - span.End.Position.GetContainingLine().Start) - blockStart.Length >= 0)
            {
                string startText = span.Snapshot.GetText(span.Start.Position, blockStart.Length);

                if (startText.Equals(blockStart, StringComparison.Ordinal))
                {
                    SnapshotSpan linespan = span.SnapshotSpan;
                    linespan = new SnapshotSpan(span.End.Position - blockEnd.Length, span.End.Position);
                    string endText = linespan.GetText();
                    if (endText.Equals(blockEnd, StringComparison.Ordinal))
                    {
                        //yes, block comment selected; remove it
                        edit.Delete(linespan);
                        edit.Delete(span.Start.Position, blockStart.Length);
                        result = new VirtualSnapshotSpan(span.SnapshotSpan);
                        return true;
                    }
                }
            }

            result = default(VirtualSnapshotSpan);
            return false;
        }

        /// <summary>
        /// Update the specified <paramref name="span"/> to not include any leading or trailing whitespace characters.
        /// </summary>
        /// <param name="span">The span to trim.</param>
        protected static void TrimSpan(ref VirtualSnapshotSpan span)
        {
            string text = span.GetText();
            int length = text.Trim().Length;

            int offset = 0;
            while (offset < text.Length && char.IsWhiteSpace(text[offset]))
                offset++;

            if (offset > 0 || length != text.Length)
            {
                VirtualSnapshotPoint start = offset > 0 ? new VirtualSnapshotPoint(span.Start.Position + offset) : span.Start;

                bool removedSpacesFromEnd = length < text.Length - offset;
                VirtualSnapshotPoint end = removedSpacesFromEnd ? new VirtualSnapshotPoint(start.Position + length) : span.End;

                span = new VirtualSnapshotSpan(start, end);
            }
        }

        /// <summary>
        /// Gets the index of the first non-whitespace character on a line, or the length of the line if the line is
        /// empty or only contains whitespace.
        /// </summary>
        /// <param name="line">The line to examine.</param>
        /// <returns>
        /// <para>The index of the first non-whitespace character on a line.</para>
        /// <para>-or-</para>
        /// <para>The length of the line if the line is empty or only contains whitespace.</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="line"/> is <see langword="null"/>.</exception>
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
