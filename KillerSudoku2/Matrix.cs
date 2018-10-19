using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerSudoku2
{
    class Matrix
    {
        public char[,] matrix;

        public Matrix(int tamano)
        {
            this.matrix = new char[tamano, tamano];
        }

        public void generateMatrix()
        {
            List<int> numeros;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    numeros = new List<int>();
                    if (matrix[i, j] == ' ')
                    {
                        Boolean bandera = true;
                        while(bandera)
                        {
                            Random rand = new Random();
                            int numRand = rand.Next(1, 7);
                            //Square root
                            if(numRand == 1)
                            {
                                if(validateSquare(i,j))
                                {
                                    bandera = false;
                                    break;
                                }
                            }
                            //Rashita de perico *sniffs*
                            else if(numRand == 2)
                            {
                                if(validateLine(i,j))
                                {
                                    bandera = false;
                                    break;
                                }
                            }
                            //La Z
                            else if(numRand == 3)
                            {
                                if(validateZ(i,j))
                                {
                                    bandera = false;
                                    break;
                                }
                            }
                            //Y la L
                            else if(numRand == 5)
                            {
                                if(validateL(i,j))
                                {
                                    bandera = false;
                                    break;
                                }
                            }
                            //La T de Troy
                            else if(numRand == 5)
                            {
                                if(validateT(i,j))
                                {
                                    bandera = false;
                                    break;
                                }
                            }
                            //El punto guanacasteco
                            else if(numRand == 6)
                            {
                                if((!validateSquare(i,j)) && (!validateLine(i,j)) && (!validateZ(i,j)) && (!validateL(i,j)) && (!validateT(i,j)))
                                {
                                    matrix[i, j] = 'p';
                                    bandera = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public Boolean validateSquare(int i, int j)
        {
            Boolean banderaC = false;
            if((matrix[i, j] == ' ') && (matrix[i, j + 1] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 1, j + 1] == ' '))
                                        {
                matrix[i, j] = 'c';
                matrix[i, j + 1] = 'c';
                matrix[i + 1, j] = 'c';
                matrix[i + 1, j + 1] = 'c';
                banderaC = true;
            }
            return banderaC;
        }

        public Boolean validateLine(int i, int j)
        {
            //NOTA: R de rashita, porque L de line ya existe en La L
            Boolean banderaR = false;
            if ((matrix[i, j] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 2, j] == ' ') && (matrix[i + 3, j] == ' '))
            {
                matrix[i, j] = 'r';
                matrix[i + 1, j] = 'r';
                matrix[i + 2, j] = 'r';
                matrix[i + 3, j] = 'r';
                banderaR = true;
                return banderaR;
            }
            else if ((matrix[i, j] == ' ') && (matrix[i, j + 1] == ' ') && (matrix[i, j + 2] == ' ') && (matrix[i, j + 3] == ' '))
            {
                matrix[i, j] = 'r';
                matrix[i, j + 1] = 'r';
                matrix[i, j + 2] = 'r';
                matrix[i, j + 3] = 'r';
                banderaR = true;
                return banderaR;
            }
            return banderaR;
        }

        public Boolean validateZ(int i, int j)
        {
            Boolean banderaZ = false;
            if ((matrix[i, j] == ' ') && (matrix[i, j + 1] == ' ') && (matrix[i+1,j-1] == ' ') && (matrix[i+1,j] == ' '))
            {
                matrix[i, j] = 'z';
                matrix[i, j + 1] = 'z';
                matrix[i + 1, j - 1] = 'z';
                matrix[i + 1, j] = 'z';
                banderaZ = true;
                return banderaZ;
            }
            else if((matrix[i, j] == ' ') && (matrix[i, j + 1] == ' ') && (matrix[i + 1, j + 1] == ' ') && (matrix[i + 1, j+2] == ' '))
            {
                matrix[i, j] = 'z';
                matrix[i, j + 1] = 'z';
                matrix[i + 1, j + 1] = 'z';
                matrix[i + 1, j+2] = 'z';
                banderaZ = true;
                return banderaZ;
            }
            else if((matrix[i, j] == ' ') && (matrix[i+1, j] == ' ') && (matrix[i + 1, j + 1] == ' ') && (matrix[i + 2, j + 1] == ' '))
            {
                matrix[i, j] = 'z';
                matrix[i+1, j] = 'z';
                matrix[i + 1, j + 1] = 'z';
                matrix[i + 2, j + 1] = 'z';
                banderaZ = true;
                return banderaZ;
            }
            else if((matrix[i, j] == ' ') && (matrix[i + 1, j-1] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 2, j - 1] == ' '))
            {
                matrix[i, j] = 'z';
                matrix[i + 1, j-1] = 'z';
                matrix[i + 1, j] = 'z';
                matrix[i + 2, j - 1] = 'z';
                banderaZ = true;
                return banderaZ;
            }
            return banderaZ;
        }

        public Boolean validateT(int i, int j)
        {
            Boolean banderaT = false;
            if((matrix[i,j] == ' ') && (matrix[i,j+1] == ' ') && (matrix[i,j+2] == ' ') && (matrix[i+1,j+1] == ' '))
            {
                matrix[i, j] = 't';
                matrix[i, j + 1] = 't';
                matrix[i, j+2] = 't';
                matrix[i + 1, j+1] = 't';
                banderaT = true;
                return banderaT;
            }
            else if((matrix[i, j] == ' ') && (matrix[i+1, j] == ' ') && (matrix[i+2, j] == ' ') && (matrix[i + 1, j + 1] == ' '))
            {
                matrix[i, j] = 't';
                matrix[i+1, j] = 't';
                matrix[i+2, j] = 't';
                matrix[i + 1, j + 1] = 't';
                banderaT = true;
                return banderaT;
            }
            else if((matrix[i, j] == ' ') && (matrix[i + 1, j-1] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 1, j + 1] == ' '))
            {
                matrix[i, j] = 't';
                matrix[i + 1, j-1] = 't';
                matrix[i + 1, j] = 't';
                matrix[i + 1, j + 1] = 't';
                banderaT = true;
                return banderaT;
            }
            else if((matrix[i, j] == ' ') && (matrix[i + 1, j - 1] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 2, j] == ' '))
            {
                matrix[i, j] = 't';
                matrix[i + 1, j - 1] = 't';
                matrix[i + 1, j] = 't';
                matrix[i + 2, j + 1] = 't';
                banderaT = true;
                return banderaT;
            }
            return banderaT;
        }

        public Boolean validateL(int i, int j)
        {
            Boolean banderaL = false;
            if((matrix[i,j] == ' ') && (matrix[i+1, j] == ' ') && (matrix[i+2, j] == ' ') && (matrix[i+2, j+1] == ' '))
            {
                matrix[i, j] = 'l';
                matrix[i+1, j] = 'l';
                matrix[i+2, j] = 'l';
                matrix[i+2, j+1] = 'l';
                banderaL = true;
                return banderaL;
            }
            else if((matrix[i, j] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 2, j] == ' ') && (matrix[i + 2, j - 1] == ' '))
            {
                matrix[i, j] = 'l';
                matrix[i + 1, j] = 'l';
                matrix[i + 2, j] = 'l';
                matrix[i + 2, j - 1] = 'l';
                banderaL = true;
                return banderaL;
            }
            else if((matrix[i, j] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 1, j + 1] == ' ') && (matrix[i + 1, j + 2] == ' '))
            {
                matrix[i, j] = 'l';
                matrix[i + 1, j] = 'l';
                matrix[i + 1, j + 1] = 'l';
                matrix[i + 1, j + 2] = 'l';
                banderaL = true;
                return banderaL;
            }
            else if((matrix[i, j] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 1, j - 1] == ' ') && (matrix[i + 1, j - 2] == ' '))
            {
                matrix[i, j] = 'l';
                matrix[i + 1, j] = 'l';
                matrix[i + 1, j - 1] = 'l';
                matrix[i + 1, j - 2] = 'l';
                banderaL = true;
                return banderaL;
            }
            return banderaL;
        }

    }
}
