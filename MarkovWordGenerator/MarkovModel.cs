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
                char fst = word[0];
                char snd = word[1];

                if (fst >= 'a' && fst <= 'z' && snd >= 'a' && snd <= 'z')
                {
                    firstCharacters[fst - 'a'].nextChars[snd - 'a'].occurrences += 1;
                    firstCharacters[fst - 'a'].totalNexts += 1;
                }
                else
                {
                    throw new ArgumentException("Non-lowercase character in AddFirstCharacter");
                }
            }
        }

        private void AddMiddleCharacters(string word)
        {
            throw new NotImplementedException();
        }

        private void AddEndCharacter(string word)
        {
            throw new NotImplementedException();
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
