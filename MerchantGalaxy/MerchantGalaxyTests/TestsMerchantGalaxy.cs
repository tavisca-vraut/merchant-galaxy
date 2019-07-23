using System;
using Xunit;
using MerchantGalaxyDriver;

namespace MerchantGalaxyTests
{
    public class TestsMerchantGalaxy
    {
        private AppDriver merchantGalaxy;
        public TestsMerchantGalaxy()
        {
            merchantGalaxy = new AppDriver();
            merchantGalaxy.LineFeed("glob is I");
            merchantGalaxy.LineFeed("prok is V");
            merchantGalaxy.LineFeed("pish is X");
            merchantGalaxy.LineFeed("tegj is L");

            merchantGalaxy.LineFeed("glob glob Silver is 34 Credits");
            merchantGalaxy.LineFeed("glob prok Gold is 57800 Credits");
            merchantGalaxy.LineFeed("pish pish Iron is 3910 Credits");
        }

        //[Fact]
        //public void CheckIfCorrectRomanNumeralFormation()
        //{
        //    string result1 = merchantGalaxy.LineFeed("glob glob Silver is 34 Credits");
        //    string result2 = merchantGalaxy.LineFeed("glob prok Gold is 57800 Credits");
        //    string result3 = merchantGalaxy.LineFeed("pish pish Iron is 3910 Credits");

        //    Assert.Equal("Silver is 2 Credits.", result1);
        //    Assert.Equal("Gold is 4 Credits.", result2);
        //    Assert.Equal("Iron is 20 Credits.", result3);
        //}

        [Fact]
        public void CheckForCorrectRomanTranslation()
        {
            string result1 = merchantGalaxy.LineFeed("how much is pish tegj glob glob ?");

            Assert.Equal("pish tegj glob glob is 42", result1);
        }

        [Fact]
        public void CheckForCorrectRomanTranslationToCredits()
        {
            string result1 = merchantGalaxy.LineFeed("how many Credits is glob prok Silver ?");
            string result2 = merchantGalaxy.LineFeed("how many Credits is glob prok Gold ?");
            string result3 = merchantGalaxy.LineFeed("how many Credits is glob prok Iron ?");

            Assert.Equal("glob prok Silver is 68 Credits", result1);
            Assert.Equal("glob prok Gold is 57800 Credits", result2);
            Assert.Equal("glob prok Iron is 782 Credits", result3);
        }

        [Fact]
        public void CheckForUnrecognizedInput()
        {
            string result1 = merchantGalaxy.LineFeed("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");

            Assert.Equal(AppDriver.NoIdeaWhatYouAreTalkingAbout, result1);
        }
    }
}
