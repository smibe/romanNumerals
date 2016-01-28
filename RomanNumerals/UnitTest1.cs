using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingDojo
{
    class RomanNumerals
    {
        public struct RomanLiteral
        {
            public RomanLiteral(int arabic, string roman)
            {
                this.arabic = arabic;
                this.roman = roman;
            }
            public int arabic;
            public string roman;
        }
        static List<RomanLiteral> romanLiterals = new List<RomanLiteral>
        {
            new RomanLiteral (1000, "M"),
            new RomanLiteral (900, "CM"),
            new RomanLiteral (500, "D"),
            new RomanLiteral (400, "CD"), 
            new RomanLiteral (100, "C"),
            new RomanLiteral (90, "XC"),
            new RomanLiteral (50, "L"),
            new RomanLiteral (40, "XL"), 
            new RomanLiteral (10, "X"),
            new RomanLiteral (9, "IX"),
            new RomanLiteral (5, "V"),
            new RomanLiteral (4, "IV"),
            new RomanLiteral (1, "I"),
        };

        public static string FromNumber(int number)
        {
            foreach (var literal in romanLiterals)
            {
                if (number >= literal.arabic)
                {
                    return literal.roman + FromNumber(number - literal.arabic);
                }
            }

            return "";
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void  FromNumberTests()
        {
            Assert.AreEqual("I", RomanNumerals.FromNumber(1));
            Assert.AreEqual("II", RomanNumerals.FromNumber(2));
            Assert.AreEqual("IV", RomanNumerals.FromNumber(4));
            Assert.AreEqual("V", RomanNumerals.FromNumber(5));
            Assert.AreEqual("IX", RomanNumerals.FromNumber(9));
            Assert.AreEqual("X", RomanNumerals.FromNumber(10));
            Assert.AreEqual("XV", RomanNumerals.FromNumber(15));
        }
        [TestMethod]
        public void  FromNumberAcceptanceTests()
        {
            Assert.AreEqual("MCMLIV", RomanNumerals.FromNumber(1954));
            Assert.AreEqual("MCMXC", RomanNumerals.FromNumber(1990));
            Assert.AreEqual("MMXIV", RomanNumerals.FromNumber(2014));
        }
    }
}
