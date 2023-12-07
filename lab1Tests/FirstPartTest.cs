using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Task01.TestProgram
{
    public class FirstPartTests
    {
        [Fact]
        public void MinAbsElementTest()
        {
            int[] arr = { -5, 5, 6, 0, 5, -9 };
            var firstPart = new FirstPart(arr);

            Assert.Equal(0, firstPart.MinAbsElement());
        }

        [Fact]
        public void AbsSumTest()
        {
            int[] arr = { -5, 5, 6, 0, 5, -9 };
            var firstPart = new FirstPart(arr);

            Assert.Equal(25, firstPart.AbsSum());
        }

        [Fact]
        public void ArrayZipTest()
        {
            int[] arr = { -9, 5, 6, 7, 4, -9 };
            var firstPart = new FirstPart(arr);
            int[] arr1 = { -9, 4, -9, 0 ,0 ,0};
            List<int> list = arr1.ToList();

            firstPart.ArrayZip(5, 8);


            Assert.Equal(list, (List<int>)firstPart.List);
        }
    }
}