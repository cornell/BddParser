using Sprache;
using System.Linq;

namespace BddParser
{
    public static class ScenarioGrammar
    {
        private static readonly Parser<char> SeparatorChar =
            Parse.Chars("/");

        //private static readonly Parser<char> ControlChar =
        //       Parse.Char(Char.IsControl, "Control character");

        //private static readonly Parser<char> SeparatorChar =
        //    Parse.Chars("()<>@,;:\\\"/[]?={} \t");

        //private static readonly Parser<char> TokenChar =
        //    Parse.LetterOrDigit;//.Or(SeparatorChar);
        //                        //.Except(SeparatorChar)
        //                        //.Except(ControlChar);

        //private static readonly Parser<string> Token =
        //    TokenChar.AtLeastOnce().Text();

        public static Scenario ParseScenario(string story)
        {
            return Scenario.End().Parse(story);
        }

        public static Parser<string> GivenText =
            (from lquot in Parse.Char('"')
             from given in Parse.String("Given ").Text()
             from content in Parse.CharExcept('"').Many().Text()
             from rquot in Parse.Char('"')
             select given + content).Token();

        internal static Parser<string> WhenText =
            (from lquot in Parse.Char('"')
             from when in Parse.String("When ").Text()
             from content in Parse.CharExcept('"').Many().Text()
             from rquot in Parse.Char('"')
             select when + content).Token();

        internal static Parser<string> ThenText =
            (from lquot in Parse.Char('"')
             from then in Parse.String("Then ").Text()
             from content in Parse.CharExcept('"').Many().Text()
             from rquot in Parse.Char('"')
             select then + content).Token();

        internal static Parser<string> AndText =
        (from lquot in Parse.Char('"')
         from and in Parse.String("And ").Text()
         from content in Parse.CharExcept('"').Many().Text()
         from rquot in Parse.Char('"')
         select and + content).Token();

        public static Parser<Scenario> Scenario =
            from given in GivenText
            from andAfterGiven in AndText.Many().Optional()
            from others in Parse.AnyChar.Except(Parse.Chars("\"")).Many().Text()
            from when in WhenText
            from others1 in Parse.AnyChar.Except(Parse.Chars("\"")).Many().Text()
            from then in ThenText
            from others2 in Parse.AnyChar.Except(Parse.Chars("\"")).Many().Text()
            from andAfterThen in AndText.Many().Optional()
            select new Scenario(given, andAfterGiven.GetOrDefault(), when, then, andAfterThen.GetOrDefault());
    }
}