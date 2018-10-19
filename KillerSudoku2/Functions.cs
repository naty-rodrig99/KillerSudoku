using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku2
{
    class Functions
    {
        int[,] cuadricula = new int[9, 9];
        public static string str1, result;

        public static void Initializer(ref int[,] cuadricula)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    cuadricula[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }
        }

        public static void CreateCuadricula(ref int[,] cuadricula, out string str2)
        {
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    str1 += cuadricula[x, y].ToString() + " ";
                }
                str1 += Environment.NewLine;
            }
            int[] xx = str1.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string yy = "-----------" + Environment.NewLine + "| ";
            for (int m = 0; m < xx.Length; m++)
            {
                yy += xx[m] + " ";
                if(m % 3 == 2)
                {
                    yy += "| ";
                }
                if(m % 9 == 8 && m < xx.Length - 1 && m != 26 && m!= 53)
                {
                    yy += Environment.NewLine + "| ";
                }
                else if (m == 26 | m == 53)
                {
                    yy += Environment.NewLine + "-------------" + Environment.NewLine + "| ";
                }
                else if(m == xx.Length - 1)
                {
                    yy += Environment.NewLine + "-------------" + Environment.NewLine;
                }
            }
            result = yy;
            str2 = yy;
            str1 = string.Empty;
        }
        public static void ChangeTwoCells(ref int[,] cuadricula, int value1, int value2)
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            for (int i = 0; i < 9; i+= 3)
            {
                for (int k = 0; k < 0; k+=3)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            if(cuadricula[i + j, k + z] == value1)
                            {
                                x1 = i + j;
                                y1 = k + z;
                            }
                            if (cuadricula[i + j, k + z] == value2)
                            {
                                x2 = i + j;
                                y2 = k + z;
                            }
                        }
                    }
                    cuadricula[x1, y1] = value2;
                    cuadricula[x2, y2] = value1;
                }
            }
        }

        public static void Actualizar(ref int[,] cuadricula, int generarCuadricula)
        {
            for(int cont = 0; cont < generarCuadricula; cont ++)
            {
                var rnd1 = new Random(Guid.NewGuid().GetHashCode());
                var rnd2 = new Random(Guid.NewGuid().GetHashCode());
                ChangeTwoCells(ref cuadricula, rnd1.Next(1,9), rnd2.Next(1,9));
            }
        }
    }
}
