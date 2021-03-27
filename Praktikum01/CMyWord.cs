using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikum01
{
    class CMyWord
    {
        public String Zeichenkette { get; set; }
        #region constructors
        public CMyWord()
        {
            Zeichenkette = "";
        }
        public CMyWord(String s)
        {
            Zeichenkette = s;
        }
        public CMyWord(CMySentence s)
        {
            var str = "";

            for (int i = 0; i < s.MyWords.Length; i++)
            {
                str += s.MyWords[i].Zeichenkette;

                if (i != s.MyWords.Length)
                {
                    str += " ";
                }
            }
            Zeichenkette = str;
        }
        public CMyWord(CMyWord s)
        {
            Zeichenkette = s.Zeichenkette;
        }
        #endregion
        public override string ToString()
        {
            return Zeichenkette;
        }
        #region binary operators
        public static string operator +(CMyWord c1, CMyWord c2) => c1.Zeichenkette + c2.Zeichenkette;
        public static CMyWord operator +(string s, CMyWord c) => new CMyWord(s += c.Zeichenkette);
        public static CMyWord operator +(CMyWord c, string s) => new CMyWord(c.Zeichenkette += s);
        public static string operator -(CMyWord word1, CMyWord word2)
        {
            var str = "";

            for (int i = 0; i < word1.Zeichenkette.Length; i++)
            {
                var str1 = "";
                var counter = 0;

                if (word1.Zeichenkette[i] == word2.Zeichenkette[0])
                {
                    str1 += word2.Zeichenkette[0];

                    for (int r = 1; r < word2.Zeichenkette.Length; r++)
                    {

                        if (word1.Zeichenkette[i + r] != word2.Zeichenkette[r])
                        {
                            str += str1;
                            counter++;
                            break;
                        }
                        str1 += word2.Zeichenkette[r];
                        counter++;
                    }
                }
                else
                    str += word1.Zeichenkette[i];

                if (counter == word2.Zeichenkette.Length - 1)
                    i += counter;
            }
            return str;
        }
        public static string operator |(CMyWord word1, string word2) => word1.Zeichenkette += "oder" + word2;
        public static CMyWord operator *(CMyWord c, int i)
        {
            var str = "";
            for (int r = 0; r < i; r++)
                str += c.Zeichenkette;
            c.Zeichenkette = str;
            return c;
        }
        public static bool operator ==(CMyWord a, CMyWord b) => true ? a.Zeichenkette == b.Zeichenkette : false;
        public static bool operator !=(CMyWord a, CMyWord b) => true ? a.Zeichenkette != b.Zeichenkette : false;
        #endregion
        #region unary operators
        public static string operator !(CMyWord word) => " nicht " + word.Zeichenkette;
        public static bool operator true(CMyWord c) => c.Zeichenkette.Length > 20;
        public static bool operator false(CMyWord c) => c.Zeichenkette.Length <= 20;
        #endregion
        public string this[string word]
        {
            get
            {
                var str = "";

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    str += word[i];
                }
                return str;
            }
        }
    }
}