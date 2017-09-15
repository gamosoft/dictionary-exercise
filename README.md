# Build a dictionary service using C#.

There are three methods to be implemented in the `LanguageDictionary` class:
  - ##### `public bool Check(string language, string word)`
    Determines if `word` is in the dictionary for `language`. If it is, it returns `true`, if it's not, it will return `false`.

  - ##### `public boolean Add(string language, string word)`
    Adds `word` to the dictionary for `language`. It returns `true` if it was successfully added. If it was not, it returns `false`.
  
  - ##### `public IEnumerable<string> Search(string word)`
    Finds words in all languages that start with the `word`.

## Notes
- The provided solution has been created and tested using `Visual Studio Community 2017`.
- There's no mention of whether this should be a singleton type of object/one instance service, so for the sake of simplicity I'll implement a regular class with the default scope.
- According to the provided method signatures, currently languages are specified as regular strings, so no strongly typed checks can be done to check for typos and consistency (englis, english, edglish, ...). For code simplicity this will not be added to the solution, but it could be avoided using enumerations or other types of checks.
- The HashSet already returns true/false when attempting to add a word to the current dictionary so we'll use this as return value.
- The Search method signature only specifies that the words should be returned, without information to which dictionary they were found into.