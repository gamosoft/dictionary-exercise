using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NIIT.Utilities.Tests
{
    [TestClass()]
    public class LanguageDictionaryTests
    {
        private LanguageDictionary _ld = new LanguageDictionary();

        /// <summary>
        /// Add a deterministic set of values for all tests to run with
        /// </summary>
        [TestInitialize]
        public void InitValues()
        {
            _ld = new LanguageDictionary();
            _ld.Add("english", "house");
            _ld.Add("english", "HOT");
            _ld.Add("english", "horse");
            _ld.Add("english", "glass");

            _ld.Add("spanish", "hombre");
            _ld.Add("spanish", "casa");
            _ld.Add("spanish", "horario");

            _ld.Add("french", "horripiler");
            _ld.Add("french", "croissant");
        }

        /// <summary>
        /// Checks that a word is found in a dictionary
        /// </summary>
        [TestMethod()]
        public void CheckTestExists()
        {
            bool expected = true;
            bool actual = _ld.Check("spanish", "hombre");
            Assert.AreEqual(expected, actual, "The word wasn't found in the dictionary!");
        }

        /// <summary>
        /// Checks that a word not added is not found
        /// </summary>
        [TestMethod()]
        public void CheckTestDoesntExists()
        {
            bool expected = false;
            bool actual = _ld.Check("english", "hombre");
            Assert.AreEqual(expected, actual, "The word was found in the dictionary!");
        }

        /// <summary>
        /// Testing successful addition of a word
        /// </summary>
        [TestMethod()]
        public void AddTestSucceed()
        {
            bool expected = true;
            bool actual = _ld.Add("english", "pumpkin");
            Assert.AreEqual(expected, actual, "Word could not be added to the dictionary!");
        }

        /// <summary>
        /// Testing failed addition of a word
        /// </summary>
        [TestMethod()]
        public void AddTestFailed()
        {
            bool expected = false;
            bool actual = _ld.Add("english", "horse");
            Assert.AreEqual(expected, actual, "Word was added because it didn't exist!");
        }

        /// <summary>
        /// Tests the search for a specific prefix in all dictionaries
        /// </summary>
        [TestMethod()]
        public void SearchTest()
        {
            int expected = 6;
            int actual = _ld.Search("ho").Count();
            Assert.AreEqual(expected, actual, "The returned amount of data doesn't match the expected results");
        }
    }
}