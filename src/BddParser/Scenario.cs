using System.Collections.Generic;

namespace BddParser
{
    public class Scenario
    {
        public string Others { get; }

        public string Given { get; }

        public string When { get; }

        public string Then { get; }
        public IEnumerable<string> AndAfterGiven { get; }

        public IEnumerable<string> AndAfterThen { get; }

        public Scenario(string given, IEnumerable<string> andAfterGiven, string when, string then, IEnumerable<string> andAfterThen)
        {
            Given = given;
            AndAfterGiven = andAfterGiven;
            When = when;
            Then = then;
            AndAfterThen = andAfterThen;
        }
    }
}