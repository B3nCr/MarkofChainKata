using Xunit;
using System.Collections.Generic;

namespace Kata4Tests
{
    public class Tests
    {
        [Theory]
        [InlineData("Alice was beginning to get very tired of sitting by her sister's cat")]
        [InlineData("Alice was beginning to get\r\nvery tired of sitting by her sister's cat")]
        public void ReadTokensFromString(string input)
        {
            var tokenizer = new Tokenizer();
            var result = tokenizer.Tokenize(input);

            Assert.Equal(new[] { "Alice", "was", "beginning", "to", "get", "very", "tired", "of", "sitting", "by", "her", "sister's", "cat" }, result);
        }

        [Theory]
        [InlineData("Alice was", "Alice", "Alice was.")]
        [InlineData("Alice was beginning", "Alice", "Alice was beginning.")]
        public void BuildStory(string input, string seed, string expected)
        {
            var storyBuilder = new StoryBuilder(input);

            var story = storyBuilder.TellStory(seed);

            Assert.Equal(expected, story);
        }

        [Theory]
        [InlineData("Alice", "was", 0.5)]
        [InlineData("Alice", "is", 0.5)]
        [InlineData("was", "Alice", 1)]
        [InlineData("is", "Alice", 0)]
        public void GetNextStatesProbability(string currentState, string nextState, double probablilityOfNextState)
        {
            var prob = new StateSpace(new string[] { "Alice", "was", "Alice", "is" });

            var p = prob.NextStates(currentState);

            Assert.Equal(probablilityOfNextState, p.ProbabilityOf(nextState));
        }
    }

    
}

