using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;

            Assert.AreEqual(5, s1.Size);
            Assert.AreEqual(10, s2.Size);
            Assert.AreEqual(5, s3.Size);

            s3.Size = 15;

            Assert.AreEqual(15, s1.Size);

            s2.Colored = true;
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(5);
            Circle s2 = new Circle(10);
            Circle s3 = s1;

            Assert.AreEqual(5, s1.Radius);
            Assert.AreEqual(10, s2.Radius);
            Assert.AreEqual(5, s3.Radius);

            s3.Radius = 15;

            Assert.AreEqual(15, s1.Radius);

            s2.Colored = true;
        }
    }
}
