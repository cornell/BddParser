using System.Collections.Generic;

namespace BddParser
{
    public class Story
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IList<Scenario> Scenarios { get; set; }

        public Story(string id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
