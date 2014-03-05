namespace Tvl.VisualStudio.Text.Commenter
{
    using System;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// This class defines the basic structure of a "line comment" in a language.
    /// </summary>
    /// <remarks>
    /// For the purpose of this implementation, a line comment is a comment that
    /// extends from a predefined prefix to the end of the current line.
    /// </remarks>
    /// <threadsafety/>
    /// <preliminary/>
    public class LineCommentFormat : CommentFormat
    {
        /// <summary>
        /// This is the backing field for the <see cref="StartText"/> property.
        /// </summary>
        private readonly string _startText;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineCommentFormat"/> class
        /// with the specified start text.
        /// </summary>
        /// <param name="startText">The prefix for a line comment in the language.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="startText"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">If <paramref name="startText"/> is empty.</exception>
        public LineCommentFormat(string startText)
        {
            Contract.Requires<ArgumentNullException>(startText != null, "startText");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(startText));

            _startText = startText;
        }

        /// <summary>
        /// Gets the prefix for a line comment in this format.
        /// </summary>
        public string StartText
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));

                return _startText;
            }
        }
    }
}
