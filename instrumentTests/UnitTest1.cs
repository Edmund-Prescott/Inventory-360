using System;
using Xunit;
using instrumentRentals2.Models;


namespace instrumentTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            instrument testInstrument = new instrument();
            Assert.True(testInstrument.name.Equals(""));
        }

        [Theory]
        [InlineData("")]
        [InlineData("Panda")]
        [InlineData("testing")]
        public void Test2(string name)
        {
            var testString = name;
            instrument testInstrument2 = new instrument();
            Assert.True(testInstrument2.name.Equals(name));
        }

    }
}

