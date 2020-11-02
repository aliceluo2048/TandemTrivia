using System.Collections.Generic;
using Xunit;

namespace TandemTrivia.Tests
{
    public class TriviaQuestionTests
    {
        [Fact]
        public void TestCountUniqueAnswers()
        {
            Assert.Equal(1, new TriviaQuestion().CountUniqueAnswers());
            Assert.Equal(1, new TriviaQuestion { Correct = "foo" }.CountUniqueAnswers());
            Assert.Equal(3, new TriviaQuestion
            {
                Incorrect = new List<string> { "blah", "foo" },
                Correct = "bar"
            }.CountUniqueAnswers());
            Assert.Equal(1, new TriviaQuestion
            {
                Incorrect = new List<string> { "bar", "bar" },
                Correct = "bar"
            }.CountUniqueAnswers());
            Assert.Equal(2, new TriviaQuestion
            {
                Incorrect = new List<string> { "bar", "foo" },
                Correct = "bar"
            }.CountUniqueAnswers());
            Assert.Equal(3, new TriviaQuestion
            {
                Incorrect = new List<string> { "bar", "BAR" },
                Correct = "baR"
            }.CountUniqueAnswers());
        }
    }
}
