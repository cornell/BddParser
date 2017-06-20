using Sprache;

namespace BddParser
{
    public static class FeatureGrammar
    {
        public static Feature ParseFeature(string story)
        {
            return Feature.End().Parse(story);
        }

        public static Parser<Feature> Feature =
                    from stories in StoryGrammar.Story.Many()
                    select new Feature(stories);
    }
}

