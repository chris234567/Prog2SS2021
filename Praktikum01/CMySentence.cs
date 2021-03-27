using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum01
{
    class CMySentence
    {
        CMyWord[] myWords;
        public CMyWord[] MyWords
        {
            get { return myWords; }
            set { myWords = value; }
        }
        // constructs a sentence with individual word objects by splittig a string
        public CMySentence(string s)
        {
            var myStrings = s.Split(' ');
            myWords = new CMyWord[myStrings.Length];

            for (int i = 0; i < myStrings.Length; i++)
            {
                myWords[i] = new CMyWord(myStrings[i]);
            }
        }
        // relayes external indexing to internal array
        public CMyWord this[int index] => myWords[index];
        public static explicit operator int(CMySentence s) => s.MyWords.Length;
    }
}