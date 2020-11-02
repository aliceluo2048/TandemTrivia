using System;
using Xunit;

namespace TandemTrivia.Tests
{
    public class UtilTests
    {
        [Fact]
        public void TestIsValidAnswer()
        {
            Assert.False(Util.IsValidAnswer("", 1));
            Assert.False(Util.IsValidAnswer("xyz", 1));
            Assert.False(Util.IsValidAnswer("-1", 1));
            Assert.False(Util.IsValidAnswer("0", 1));
            Assert.True(Util.IsValidAnswer("1", 1));
            Assert.False(Util.IsValidAnswer("2", 1));
            Assert.True(Util.IsValidAnswer("1", 3));
            Assert.True(Util.IsValidAnswer("2", 3));
            Assert.True(Util.IsValidAnswer("3", 3));
            Assert.False(Util.IsValidAnswer("4", 3));
        }

        [Fact]
        public void TestGetProgressBarText()
        {
            Assert.Equal("[]", Util.GetProgressBarText(0, 0));
            Assert.Equal("[      ]", Util.GetProgressBarText(0, 1));
            Assert.Equal("[######]", Util.GetProgressBarText(1, 1));
            Assert.Throws<ArgumentException>(() => Util.GetProgressBarText(1, 0));
            Assert.Equal("[                  ]", Util.GetProgressBarText(0, 3));
            Assert.Equal("[######            ]", Util.GetProgressBarText(1, 3));
            Assert.Equal("[##################]", Util.GetProgressBarText(3, 3));
            Assert.Throws<ArgumentException>(() => Util.GetProgressBarText(4, 3));
        }
    }
}
