using FluentAssertions;
using Xunit;
using Sprache;

namespace BddParser.Tests
{
    public class StoryGrammarUnitTest
    {
        [Fact]
        public void Given_a_id_without_space_between_delimiter()
        {
            string input = "Id=123";

            string id = StoryGrammar.Id.End().Parse(input);

            id.Should().Be("123");
        }

        [Fact]
        public void Given_a_id_with_space_before_delimiter()
        {
            string input = "Id =123";

            string id = StoryGrammar.Id.End().Parse(input);

            id.Should().Be("123");
        }

        [Fact]
        public void Given_a_id_with_space_after_delimiter()
        {
            string input = "Id= 123";

            string id = StoryGrammar.Id.End().Parse(input);

            id.Should().Be("123");
        }

        [Fact]
        public void Given_a_title_with_a_digit()
        {
            string input = "Title =\"contains 3 numbers\"";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("contains 3 numbers");
        }

        [Fact]
        public void Given_a_title_with_a_special_character()
        {
            string input = "Title =\"F2ake.&\"";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("F2ake.&");
        }

        [Fact]
        public void Given_a_title_with_space_at_start()
        {
            string input = "  Title=\"fake\"";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("fake");
        }

        [Fact]
        public void Given_a_title_without_space_between_delimiter()
        {
            string input = "Title=\"fake\" ";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("fake");
        }

        [Fact]
        public void Given_a_title_with_space_before_delimiter()
        {
            string input = "Title =\"fake\" ";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("fake");
        }

        [Fact]
        public void Given_a_title_with_space_after_delimiter()
        {
            string input = "Title= \"fake\"";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("fake");
        }

        [Fact]
        public void Given_a_title_with_space_around_delimiter()
        {
            string input = "Title = \"fake\"";

            string title = StoryGrammar.Title.End().Parse(input);

            title.Should().Be("fake");
        }

        [Fact]
        public void Given_a_story_without_parenthesis()
        {
            string input = "[Story]";

            Story story = StoryGrammar.ParseStory(input);

            story.Should().NotBeNull("Story");
        }

        [Fact]
        public void Given_a_story_with_parenthesis()
        {
            string input = "[Story()]";

            Story story = StoryGrammar.ParseStory(input);

            story.Should().NotBeNull("Story");
        }

        [Fact]
        public void Given_a_story_with_id_parameters()
        {
            string input = "[Story(Id = 12)]";

            Story story = StoryGrammar.ParseStory(input);

            story.Should().NotBeNull("Story");
        }


        [Fact]
        public void Given_a_story_with_all_parameters()
        {
            string input = "[Story(Id = 12, Title=\"coucou\") ]";

            Story story = StoryGrammar.Story.End().Parse(input);

            story.Id.Should().Be("12");
        }
    }
}