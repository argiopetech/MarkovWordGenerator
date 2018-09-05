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
                AddFirstCharacter();
                AddMiddleCharacters();
                AddEndCharacter();
            }
        }

        private void AddFirstCharacter()
        {
            throw new NotImplementedException();
        }

        private void AddMiddleCharacters()
        {
            throw new NotImplementedException();
        }

        private void AddEndCharacter()
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
                this.total = 0;

                nextChars = new CharInstance[26];

                for (char c = 'a'; c <= 'z'; ++c)
                {
                    nextChars[c - 'a'] = new CharInstance() { character = c, occurrences = 0 };
                }
            }

            public char current;
            public int total;

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
