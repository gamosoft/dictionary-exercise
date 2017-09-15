using System;
using System.Collections.Generic;
using System.Linq;

namespace NIIT.Utilities
{
    public class LanguageDictionary
    {
        #region "Variables"

        /// <summary>
        /// The first string (key) will be the dictionary name. For simplicity there will not be any check for correctness in languages' names
        /// </summary>
        private Dictionary<string, HashSet<string>> _allData = new Dictionary<string, HashSet<string>>();

        #endregion "Variables"

        #region "Methods"

        /// <summary>
        /// Determines if `word` is in the dictionary for `language`. If it is, it returns `true`, if it's not, it will return `false`.
        /// </summary>
        /// <param name="language">Language to check the word from</param>
        /// <param name="word">Word to check for</param>
        /// <returns>Returns true if the word exists in the specified dictionary; false otherwise and also if the language was not found either</returns>
        public bool Check(string language, string word)
        {
            return _allData.Keys.Contains(language) && _allData[language].Any(w => w.Equals(word, StringComparison.InvariantCultureIgnoreCase));
        }


        /// <summary>
        /// Adds `word` to the dictionary for `language`. It returns `true` if it was successfully added. If it was not, it returns `false`.
        /// </summary>
        /// <param name="language">Language to add the word to</param>
        /// <param name="word">Word to add</param>
        /// <returns>Returns true if the word was found, false otherwise</returns>
        public bool Add(string language, string word)
        {
            if (!_allData.Keys.Contains(language)) _allData.Add(language, new HashSet<string>());
            return _allData[language].Add(word);
        }

        /// <summary>
        /// Finds words in all languages that start with the `word`.
        /// </summary>
        /// <param name="word">Word prefix to search for</param>
        /// <returns>Enumerable collection of words</returns>
        public IEnumerable<string> Search(string word)
        {
            return _allData.SelectMany(ad => ad.Value.Where(w => w.StartsWith(word, StringComparison.InvariantCultureIgnoreCase)), (l, w) => w);
        }

        #endregion "Methods"
    }
}
