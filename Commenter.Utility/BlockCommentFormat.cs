namespace Tvl.VisualStudio.Text.Commenter
{
    using System;
    using System.Diagnostics.Contracts;
    using Tvl.VisualStudio.Text.Commenter.Interfaces;

    /// <summary>
    /// This class defines the basic structure of a "block comment" in a language.
    /// </summary>
    /// <remarks>
    /// <para>For the purpose of this implementation, a block comment is a comment that extends from a predefined
    /// starting prefix to a predefined ending suffix. The <see cref="AllowNesting"/> property specifies whether the
    /// language allows block comments in this format to be nested.</para>
    /// <note type="note">
    /// <para>The exact semantics of a block comment are not dictated by this data structure. The implementation of
    /// <see cref="ICommenter"/> provided by an extension for a particular content type is responsible for the behavior
    /// of comments.</para>
    /// </note>
    /// </remarks>
    /// <threadsafety/>
    public class BlockCommentFormat : CommentFormat
    {
        /// <summary>
        /// This is the backing field for the <see cref="StartText"/> property.
        /// </summary>
        private readonly string _startText;

        /// <summary>
        /// This is the backing field for the <see cref="EndText"/> property.
        /// </summary>
        private readonly string _endText;

        /// <summary>
        /// This is the backing field for the <see cref="AllowNesting"/> property.
        /// </summary>
        private readonly bool _allowNesting;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockCommentFormat"/> class with the specified prefix and
        /// suffix. The <see cref="AllowNesting"/> property is initialized to <see langword="false"/>.
        /// </summary>
        /// <param name="startText">The prefix for a block comment in this format.</param>
        /// <param name="endText">The suffix for a block comment in this format.</param>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="startText"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endText"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <para>If <paramref name="startText"/> is empty.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endText"/> is empty.</para>
        /// </exception>
        public BlockCommentFormat(string startText, string endText)
            : this(startText, endText, false)
        {
            Contract.Requires<ArgumentNullException>(startText != null, "startText");
            Contract.Requires<ArgumentNullException>(endText != null, "endText");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(startText));
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(endText));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockCommentFormat"/> class with the specified prefix, suffix,
        /// and value indicating whether block comments in this format may appear nested in the source code.
        /// </summary>
        /// <param name="startText">The prefix for a block comment in this format.</param>
        /// <param name="endText">The suffix for a block comment in this format.</param>
        /// <param name="allowNesting"><see langword="true"/> if comments in this format may be nested; otherwise,
        /// <see langword="false"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <para>If <paramref name="startText"/> is <see langword="null"/>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endText"/> is <see langword="null"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <para>If <paramref name="startText"/> is empty.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="endText"/> is empty.</para>
        /// </exception>
        public BlockCommentFormat(string startText, string endText, bool allowNesting)
        {
            Contract.Requires<ArgumentNullException>(startText != null, "startText");
            Contract.Requires<ArgumentNullException>(endText != null, "endText");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(startText));
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(endText));

            _startText = startText;
            _endText = endText;
            _allowNesting = allowNesting;
        }

        /// <summary>
        /// Gets the prefix for a block comment in this format.
        /// </summary>
        public string StartText
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _startText;
            }
        }

        /// <summary>
        /// Gets the suffix for a block comment in this format.
        /// </summary>
        public string EndText
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _endText;
            }
        }

        /// <summary>
        /// Gets a value indicating whether block comments in this format may be nested.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if comments in this format may be nested; otherwise, <see langword="false"/>.
        /// </value>
        public bool AllowNesting
        {
            get
            {
                return _allowNesting;
            }
        }
    }
}
