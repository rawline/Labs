using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.TestProgram
{

    public class SecondPartTest
    {
        [Fact]
        public void GetAmountOfRowsFewerThanValueTest()
        {
            double[,] matrix = { {7, 5, 6, 9},
                                 {5, 5, 8, 2},
                                 {1, 4, 6, 9}};

            var secondPart = new SecondPart(matrix, 3, 4);
            Assert.Equal(2, secondPart.GetAmountOfRowsFewerThanValue(6));

        }
    }
}

