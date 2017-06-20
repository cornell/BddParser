using FluentAssertions;
using Xunit;
using Sprache;

namespace BddParser.Tests
{
    public class ScenarioGrammarUnitTest
    {
        [Fact]
        public void Given_With_text_before()
        {
            // Given
            string input = @"""Given I have 100 shares of MSFT stock""";

            // When
            var given = ScenarioGrammar.GivenText.End().Parse(input);

            // Then
            given.Should().Be("Given I have 100 shares of MSFT stock");
        }

        [Fact]
        public void Given_When_Then()
        {
            // Given
            string input = @"""Given I have 100 shares of MSFT stock""
            .x(() => x = 1); 
            ""When I have 150 shares of APPL stock""
            .x(() => answer = calculator.Add(x, y));
            ""Then the time is before close of trading""
            .x(() => Xunit.Assert.Equal(3, answer));";

            // When
            Scenario scenario = ScenarioGrammar.Scenario.End().Parse(input);

            // Then
            scenario.Given.Should().Be("Given I have 100 shares of MSFT stock");
            scenario.When.Should().Be("When I have 150 shares of APPL stock");
            scenario.Then.Should().Be("Then the time is before close of trading");
        }
    }
}