using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.TitleCase
{
    public class TitleCase
    {
        private readonly List<string> reserved = new List<string> { "a", "the", "to" };

        public string Format(string stringToTitleCase)
        {
            if (string.IsNullOrEmpty(stringToTitleCase))
            {
                return string.Empty;
            }

            var response = new List<string>();

            var words = stringToTitleCase.ToLower().Split(' ');

            for (var i = 0; i < words.Length; i++ )
            {
                var word = words[i];

                if (IsSpecialCase(i, words, word))
                {
                    response.Add(word);
                }
                else
                {
                    response.Add(Capitalise(word));
                }
            }

            return String.Join(" ", response);
        }

        private static string Capitalise(string lowerWord)
        {
            return lowerWord.Substring(0, 1).ToUpper() + lowerWord.Substring(1);
        }

        private bool IsSpecialCase(int i, string[] words, string lowerWord)
        {
            return i > 0 && i < words.Length - 1 && reserved.Contains(lowerWord);
        }
    }
}
