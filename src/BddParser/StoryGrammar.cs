using Sprache;
using System.Linq;

namespace BddParser
{
    public static class StoryGrammar
    {
        static readonly Parser<char> _lHook = Parse.Char('[');
        static readonly Parser<char> _rHook = Parse.Char(']');
        static readonly Parser<char> _lParenthesis = Parse.Char('(');
        static readonly Parser<char> _rParenthesis = Parse.Char(')');
        private static readonly Parser<char> _punctuationChars
            = Parse.Chars(new char[] { '.', '!', '?', ';', '-', '_', '&' });

        static readonly Parser<char> _equalSeparator = Parse.Char('=');
        static readonly Parser<char> _spaceSeparator = Parse.Char(' ');
        static readonly Parser<char> _commaSeparator = Parse.Char(',');
        static readonly Parser<char> _doubleQuoteSeparator = Parse.Char('\"');

        public static Story ParseStory(string story)
        {
            return Story.End().Parse(story);
        }

        public static Parser<string> Id =
        (
            from key in Parse.String("Id").Token()
            from equalDelimiter in _equalSeparator
            from value in Parse.Digit
                .Or(_spaceSeparator)
                .Many().Text()
            select value.Trim()
        )
       .Text().Token();

        public static Parser<string> Title =
        (
            from content in Parse.String("Title").Token()
            from equalDelimiter in _equalSeparator
            from spaceDelimiter in _spaceSeparator.Optional()
            from ldoubleQuote in _doubleQuoteSeparator
            from value in Parse.LetterOrDigit
                .Or(_spaceSeparator)
                .Or(_commaSeparator)
                .Or(_punctuationChars)
                .Many().Text()
            from rdoubleQuote in _doubleQuoteSeparator
            select value.Trim()
        )
        .Text().Token();

        public static Parser<Story> Story =
            from lHook in _lHook
            from content in Parse.String("Story").Token()
            from ldelimiter in _lParenthesis.Optional()
            from id in Id.Optional()
            from paramDelimiter in _commaSeparator.Optional()
            from title in Title.Optional()
            from rdelimiter in _rParenthesis.Optional()
            from spaceDelimiter in Parse.WhiteSpace.Optional()
            from rHook in _rHook
            select new Story(id.GetOrDefault(), title.GetOrDefault());
    }
}