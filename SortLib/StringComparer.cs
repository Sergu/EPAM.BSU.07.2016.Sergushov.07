using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y);
        }
    }
    public class Rectangle
    {
        private readonly int sideA;
        private readonly int sideB;
        public Rectangle(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException("Длины сторон меньше нуля");
            }
            sideA = a;
            sideB = b;
        }
        public int Area { get { return sideA * sideB; } }
    }
    public class RectangleComparer : IComparer<Rectangle>
    {
        public int Compare(Rectangle x, Rectangle y)
        {
            if (ReferenceEquals(x, null))
                throw new NullReferenceException();
            if (ReferenceEquals(y, null))
                throw new NullReferenceException();
            return x.Area - y.Area;           
        }
    }
}
