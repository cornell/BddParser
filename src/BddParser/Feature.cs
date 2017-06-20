using System.Collections.Generic;

namespace BddParser
{
    public class Feature
    {
        public IEnumerable<Story> Stories { get; }

        public Feature(IEnumerable<Story> stories)
        {
            Stories = stories;
        }

    }
}
