using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovWordGenerator
{
    struct FirstCharacter
    {

    }

    struct MiddleCharacter
    {

    }

    struct FinalCharacter
    {

    }

    class MarkovModel
    {
        FirstCharacter[] firstCharacters = new FirstCharacter[26];
        MiddleCharacter[] middleCharacters = new MiddleCharacter[26];
        FinalCharacter[] finalCharacters = new FinalCharacter[26];


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
    }
