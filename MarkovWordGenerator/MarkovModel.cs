using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovWordGenerator
{
    class MarkovModel
    {
        CharacterFunction[] firstCharacters;
        CharacterFunction[] middleCharacters;
        CharacterFunction[] finalCharacters;

        public MarkovModel()
        {
            firstCharacters = InitCharacterFunctions();
            middleCharacters = InitCharacterFunctions();
            finalCharacters = InitCharacterFunctions();
        }

        public void AddWords(string[] words)
        {
            foreach (var word in words)
            {
                this.AddWord(word);
            }
        }

        public void AddWord(string word)
        {
            if (word.Length > 3)
            {
                var lWord = word.ToLower();

                AddFirstCharacter(lWord);
                AddMiddleCharacters(lWord);
                AddEndCharacter(lWord);
            }
        }

        private void AddFirstCharacter(string word)
        {
            if (word.Length >= 2)
            {
                char curr = word[0];
                char next = word[1];

                if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                {
                    firstCharacters[curr - 'a'].nextChars[next - 'a'].occurrences += 1;
                    firstCharacters[curr - 'a'].totalNexts += 1;
                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddFirstCharacter");
                }
            }
        }

        private void AddMiddleCharacters(string word)
        {
            if (word.Length >= 2)
            {

                for (int i = 1; i < word.Length - 2; ++i)
                {
                    char curr = word[i];
                    char next = word[i + 1];

                    if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                    {
                        middleCharacters[curr - 'a'].nextChars[next - 'a'].occurrences += 1;
                        middleCharacters[curr - 'a'].totalNexts += 1;
                    }
                    else
                    {
                        throw new ArgumentException("Non-lowercase character in AddMiddleCharacters");
                    }
                }
            }
        }

        private void AddEndCharacter(string word)
        {
            if (word.Length >= 2)
            {
                var lastIndex = word.Length - 1;

                char curr = word[lastIndex - 1];
                char next = word[lastIndex];

                if (curr >= 'a' && curr <= 'z' && next >= 'a' && next <= 'z')
                {
                    finalCharacters[curr - 'a'].nextChars[next - 'a'].occurrences += 1;
                    finalCharacters[curr - 'a'].totalNexts += 1;
                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddEndCharacter");
                }
            }
        }

        struct CharInstance
        {
            public char character;

            public int occurrences;
        }

        struct CharacterFunction
        {
            public CharacterFunction(char current)
            {
                this.current = current;
                this.totalNexts = 0;

                nextChars = new CharInstance[26];

                for (char c = 'a'; c <= 'z'; ++c)
                {
                    nextChars[c - 'a'] = new CharInstance() { character = c, occurrences = 0 };
                }
            }

            public char current;
            public int totalNexts;

            public CharInstance[] nextChars;
        }

        private CharacterFunction[] InitCharacterFunctions()
        {
            var characterFunctions = new CharacterFunction[26];

            for (char c = 'a'; c <= 'z'; ++c)
            {
                characterFunctions[c - 'a'] = new CharacterFunction(c);
            }

            return characterFunctions;
        }
    }
}
