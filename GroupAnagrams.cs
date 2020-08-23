//https://leetcode.com/problems/group-anagrams/


public IList<IList<string>> GroupAnagrams(string[] strs) {

      var groupedAnagrams = new List<IList<string>>();
            var dict = new Dictionary<string, List<string>>();

            //lets make the key the sorted word and the value - list of words (in it's original order)

            foreach (string word in strs)
            {
                char[] characters = word.ToCharArray();
                Array.Sort(characters);
                var sortedWord = new string(characters);
                if (!dict.ContainsKey(sortedWord))
                {
                    dict.Add(sortedWord, new List<string>());
                }
                dict[sortedWord].Add(word);
            }

            groupedAnagrams.AddRange(dict.Values);
            return groupedAnagrams;
    }