using System;

namespace Uebung08
{
    class Fraction :IComparable
    {
        public int den;
        public int num;
        public int CompareTo(object obj)
        {
            Fraction param = obj as Fraction;
            if (param is null) throw new Exception();

            var val = ((double)den / num) / ((double)param.den / param.num);

            return val < 1 ? -1 : val > 1 ? 1 : 0;
        }
        public override string ToString()
        {
            return $"{den} / {num}";
        }
    }
}
