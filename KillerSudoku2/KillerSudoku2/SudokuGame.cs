using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku2
{
    class SudokuGame
    {
        public int[,] Numbers { get; private set; }

        public SudokuGame()
        {
            Generate();
            Update(10);
        }

        private void Generate()
        {
            Numbers = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Numbers[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }
        }

        private void ChangeCells(int v1, int v2)
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            for (int i = 0; i < 9; i += 3)
            {
                for (int k = 0; k < 9; k +=3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            if (Numbers[i + j, k + z] == v1)
                            {
                                x1 = i + j;
                                y1 = k + z;
                            }
                            if (Numbers[i + j, k + z] == v2)
                            {
                                x2 = i + j;
                                y2 = k + z;
                            }
                        }
                    }
                    Numbers[x1, y1] = v2;
                    Numbers[x2, y2] = v1;
                }
            }
        }

        private void Update(int cuadricula)
        {
            for (int i = 0; i < cuadricula; i++)
            {
                var rand1 = new Random(Guid.NewGuid().GetHashCode());
                var rand2 = new Random(Guid.NewGuid().GetHashCode());
                ChangeCells(rand1.Next(1, 9), rand2.Next(1, 9));
            }
        }

        public override string ToString()
        {
            var SB = new StringBuilder();
            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                for(int i2 = 0; i2 < Numbers.GetLength(1); i2++)
                {
                    SB.Append(Numbers[i, i2]);
                }
            }
            return base.ToString();
        }


    }
}
