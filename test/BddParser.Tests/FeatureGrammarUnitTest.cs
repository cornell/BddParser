using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace BddParser.Tests
{
    public class FeatureGrammarUnitTest
    {

        [Fact]
        public void Given_one_story()
        {
            string input = "[Story(Id = 12, Title=\"coucou\")]";

            Feature feature = FeatureGrammar.ParseFeature(input);

            feature.Stories.ShouldBeEquivalentTo(new List<Story>
            {
                new Story("12", "coucou")
            });
        }

        [Fact]
        public void Given_many_stories()
        {
            string input = "[Story(Id=12, Title=\"coucou\")][Story(Id = 13, Title=\"toto\")]";

            Feature feature = FeatureGrammar.ParseFeature(input);

            feature.Stories.ShouldBeEquivalentTo(new List<Story>
            {
                new Story("12", "coucou"),
                new Story("13", "toto")
            });
        }
    }
}