using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortLib;
using System.Collections.Generic;
using GenericSortLib;

namespace SortLibTests
{
    [TestClass]
    public class SorterTests
    {
        [TestMethod]
        public void ShakerSortTest_sortRectangleArray_usingRectangleComparer()
        {
            IComparer<Rectangle> rectComparer = new RectangleComparer();

            Rectangle rect1 = new Rectangle(1, 2);
            Rectangle rect2 = new Rectangle(1, 1);
            Rectangle rect3 = new Rectangle(45, 23);
            Rectangle rect4 = new Rectangle(12, 12);
            Rectangle[] arr = new Rectangle[4];
            arr[0] = rect1;
            arr[1] = rect2;
            arr[2] = rect3;
            arr[3] = rect4;
            Rectangle[] sortedArr = new Rectangle[4];
            arr[0] = rect2;
            arr[1] = rect1;
            arr[2] = rect4;
            arr[3] = rect3;

            Sorter.ShakerSort<Rectangle>(arr, rectComparer);

            Assert.AreEqual(arr, sortedArr);
        }
    }
}
