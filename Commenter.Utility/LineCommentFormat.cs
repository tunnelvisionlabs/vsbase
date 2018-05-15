namespace Tvl.VisualStudio.Text.Commenter
{
    using System;
    using Tvl.VisualStudio.Text.Commenter.Interfaces;

    /// <summary>
    /// This class defines the basic structure of a "line comment" in a language.
    /// </summary>
    /// <remarks>
    /// <para>For the purpose of this implementation, a line comment is a comment that extends from a predefined prefix
    /// to the end of the current line.</para>
    /// <note type="note">
    /// <para>The exact semantics of a line comment are not dictated by this data structure. The implementation of
    /// <see cref="ICommenter"/> provided by an extension for a particular content type is responsible for the behavior
    /// of comments.</para>
    /// </note>
    /// </remarks>
    /// <threadsafety/>
    public class LineCommentFormat : CommentFormat
    {
        /// <summary>
        /// This is the backing field for the <see cref="StartText"/> property.
        /// </summary>
        private readonly string _startText;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineCommentFormat"/> class with the specified start text.
        /// </summary>
        /// <param name="startText">The prefix for a line comment in the language.</param>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="startText"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">If <paramref name="startText"/> is empty.</exception>
        public LineCommentFormat(string startText)
        {
            if (startText == null)
                throw new ArgumentNullException(nameof(startText));
            if (string.IsNullOrEmpty(startText))
                throw new ArgumentException($"{nameof(startText)} cannot be empty", nameof(startText));

            _startText = startText;
        }

        /// <summary>
        /// Gets the prefix for a line comment in this format.
        /// </summary>
        public string StartText
        {
            get
            {
                return _startText;
            }
        }
    }
}
