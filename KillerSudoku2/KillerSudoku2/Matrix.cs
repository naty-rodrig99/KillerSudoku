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
        public static int tam;
        public char[,] operation;
        public int[,] number;
        public int[,] sudoku;

        public Matrix(int tamano)
        {
            this.matrix = new char[tamano, tamano];
            tam = tamano;
            this.operation = new char[tamano, tamano];
            this.number = new int[tamano, tamano];
            this.sudoku = new int[tamano, tamano];
        }

        public void InitializePuzzle()
        {
            for (int r = 0; r < tam; r++)
            {
                for (int c = 0; c < tam; c++)
                {
                    sudoku[r, c] = 0;
                }
            }
        }

        public Boolean isSafe(int row, int col, int num)
        {
            for (int d = 0; d < tam; d++)
            {
                if (sudoku[row, d] == num)
                {
                    return false;
                }
            }
            for (int r = 0; r < tam; r++)
            {
                if (sudoku[r, col] == num)
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean SolveSudoku()
        {
            int row = -1;
            int col = -1;
            Boolean isEmpty = true;
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (sudoku[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }
            if (isEmpty)
            {
                return true;
            }
            for (int num = 1; num <= tam; num++)
            {
                if (isSafe(row, col, num))
                {
                    sudoku[row, col] = num;
                    if (SolveSudoku())
                    {
                        return true;
                    }
                    else
                    {
                        sudoku[row, col] = 0; 
                    }
                }
            }
            return false;
        }

        public void createMatrix()
        {
            int bound0 = matrix.GetUpperBound(0);
            int bound1 = matrix.GetUpperBound(1);

            for (int i = 0; i <= bound1; i++)
            {
                for (int j = 0; j <= bound1; j++)
                {
                    matrix[i, j] = 'n';
                }
            }
        }

        public void insert()
        {
            int bound0 = matrix.GetUpperBound(0);
            int bound1 = matrix.GetUpperBound(1);

            for (int i = 0; i <= bound1; i++)
            {
                for(int j = 0; j <= bound1; j++)
                {
                    matrix[i, j] = 'n';
                }
            }
            // Use for-loops to iterate over the array elements
            for (int variable1 = 0; variable1 <= bound0; variable1++)
            {
                for (int variable2 = 0; variable2 <= bound1; variable2++)
                {
                    char value = matrix[variable1, variable2];
                    Console.WriteLine(value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void generateMatrix()
        {
            List<int> numeros;
            numeros = new List<int>();
            Random rand = new Random();
            InitializePuzzle();
            SolveSudoku();
            mostrarSudoku();
            int v1 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    if (matrix[i, j] == 'n')
                    {
                        Boolean bandera = true;
                        while (bandera)
                        {
                            mostrar();
                            mostrarNumbers();
                            mostrarOperacion();
                            Console.WriteLine("bandera" + bandera);
                            int numRand = rand.Next(1, 7);
                            Console.WriteLine(numRand);
                            //Square root
                            if (numRand == 1)
                            {
                                if (ValidateSquare(i, j))
                                {
                                    bandera = false;
                                    Console.WriteLine("bandera1: " + bandera);
                                    break;
                                }
                            }
                            //Rashita de perico *sniffs*
                            else if (numRand == 2)
                            {
                                if (validateLine(i, j))
                                {
                                    bandera = false;
                                    Console.WriteLine("bandera2: " + bandera);
                                    break;
                                }
                            }
                            //La Z
                            else if (numRand == 3)
                            {
                                if (ValidateZ(i, j))
                                {
                                    bandera = false;
                                    Console.WriteLine("bandera3: " + bandera);
                                    break;
                                }
                            }
                            //Y la L
                            else if (numRand == 4)
                            {
                                if (validateL(i, j))
                                {
                                    bandera = false;
                                    Console.WriteLine("bandera4: " + bandera);
                                    break;
                                }
                            }
                            //La T de Troy
                            else if (numRand == 5)
                            {
                                if (validateT(i, j))
                                {
                                    bandera = false;
                                    Console.WriteLine("bandera5: " + bandera);
                                    break;
                                }
                            }
                            //El punto guanacasteco
                            else if (numRand == 6)
                            {
                              if ((!ValidateSquare(i, j)) && (!validateLine(i, j)) && (!ValidateZ(i, j)) && (!validateL(i, j)) && (!validateT(i, j)))
                               {
                                if(matrix[i,j] == 'n')
                                 {
                                    matrix[i, j] = 'p';
                                 }
                                bandera = false;
                                Console.WriteLine("bandera6: " + bandera);
                                if(generateOperation() == 1)
                                    {
                                        try
                                        {
                                            operation[i, j] = '=';
                                            v1 = sudoku[i, j];
                                            number[i, j] = v1; ;
                                        }
                                        catch(IndexOutOfRangeException e)
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            operation[i, j] = '=';
                                            v1 = sudoku[i, j];
                                            number[i, j] = v1;
                                        }
                                        catch(IndexOutOfRangeException e)
                                        {
                                            continue;
                                        }
                                    }
                                break;
                               }
                            }
                        }
                    }
                }
            }
        }

        public Boolean ValidateSquare(int i, int j)
        {
            Boolean banderaC = false;
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int v4 = 0;
            try
            {
                if ((matrix[i, j] == 'n') && (matrix[i, j + 1] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 1, j + 1] == 'n'))
                {
                    matrix[i, j] = 'c';
                    matrix[i, j + 1] = 'c';
                    matrix[i + 1, j] = 'c';
                    matrix[i + 1, j + 1] = 'c';
                    banderaC = true;
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i, j + 1] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 1, j + 1] = '+';
                        //Suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 1, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i, j + 1] = suma;
                        number[i + 1, j] = suma;
                        number[i + 1, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i, j + 1] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 1, j + 1] = '*';
                        //Multiplicacion
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 1, j + 1];
                        int mult = v1 * v2 * v3* v4;
                        number[i, j] = mult; 
                        number[i, j + 1] = mult; 
                        number[i + 1, j] = mult; 
                        number[i + 1, j + 1] = mult; 
                    }
                }
                return banderaC;
            }
            catch(IndexOutOfRangeException e)
            {

                return banderaC;
            }
        }

        public Boolean validateLine(int i, int j)
        {
            //NOTA: R de rashita, porque L de line ya existe en La L
            Boolean banderaR = false;
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int v4 = 0;
            try
            {
                if ((matrix[i, j] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 2, j] == 'n') && (matrix[i + 3, j] == 'n'))
                {
                    matrix[i, j] = 'r';
                    matrix[i + 1, j] = 'r';
                    matrix[i + 2, j] = 'r';
                    matrix[i + 3, j] = 'r';
                    banderaR = true;
                    Console.WriteLine("Line1");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 2, j] = '+';
                        operation[i + 3, j] = '+';
                        //Suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 3, j];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 2, j] = suma;
                        number[i + 3, j] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 2, j] = '*';
                        operation[i + 3, j] = '*';
                        //Multiplicacion
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 3, j];
                        int num = v1 * v2 * v3 * v4;
                        number[i, j] = num;
                        number[i + 1, j] = num;
                        number[i + 2, j] = num;
                        number[i + 3, j] = num;
                    }
                    return banderaR;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i, j + 1] == 'n') && (matrix[i, j + 2] == 'n') && (matrix[i, j + 3] == 'n'))
                {
                    matrix[i, j] = 'r';
                    matrix[i, j + 1] = 'r';
                    matrix[i, j + 2] = 'r';
                    matrix[i, j + 3] = 'r';
                    banderaR = true;
                    Console.WriteLine("Line2");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i, j + 1] = '+';
                        operation[i, j + 2] = '+';
                        operation[i, j + 3] = '+';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i, j + 2];
                        v4 = sudoku[i, j + 3];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i, j + 1] = suma;
                        number[i, j + 2] = suma;
                        number[i, j + 3] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i, j + 1] = '*';
                        operation[i, j + 2] = '*';
                        operation[i, j + 3] = '*';
                        //Multi
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i, j + 2];
                        v4 = sudoku[i, j + 3];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i, j + 1] = mult;
                        number[i, j + 2] = mult;
                        number[i, j + 3] = mult;
                    }
                    return banderaR;
                }
                return banderaR;
            }
            catch (IndexOutOfRangeException e)
            {
                return banderaR;
            }
        }

        public Boolean ValidateZ(int i, int j)
        {
            Boolean banderaZ = false;
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int v4 = 0;
            try
            {
                if ((matrix[i, j] == 'n') && (matrix[i, j + 1] == 'n') && (matrix[i + 1, j - 1] == 'n') && (matrix[i + 1, j] == 'n'))
                {
                    matrix[i, j] = 'z';
                    matrix[i, j + 1] = 'z';
                    matrix[i + 1, j - 1] = 'z';
                    matrix[i + 1, j] = 'z';
                    banderaZ = true;
                    Console.WriteLine("Z1");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i, j + 1] = '+';
                        operation[i + 1, j - 1] = '+';
                        operation[i + 1, j] = '+';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i + 1, j - 1];
                        v4 = sudoku[i + 1, j];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i, j + 1] = suma;
                        number[i + 1, j - 1] = suma;
                        number[i + 1, j] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i, j + 1] = '*';
                        operation[i + 1, j - 1] = '*';
                        operation[i + 1, j] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i + 1, j - 1];
                        v4 = sudoku[i + 1, j];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i, j + 1] = mult;
                        number[i + 1, j - 1] = mult;
                        number[i + 1, j] = mult;
                    }
                    return banderaZ;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i, j + 1] == 'n') && (matrix[i + 1, j + 1] == 'n') && (matrix[i + 1, j + 2] == 'n'))
                {
                    matrix[i, j] = 'z';
                    matrix[i, j + 1] = 'z';
                    matrix[i + 1, j + 1] = 'z';
                    matrix[i + 1, j + 2] = 'z';
                    banderaZ = true;
                    Console.WriteLine("Z2");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i, j + 1] = '+';
                        operation[i + 1, j + 1] = '+';
                        operation[i + 1, j + 2] = '+';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i + 1, j + 1];
                        v4 = sudoku[i + 1, j + 2];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i, j + 1] = suma;
                        number[i + 1, j + 1] = suma;
                        number[i + 1, j + 2] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i, j + 1] = '*';
                        operation[i + 1, j + 1] = '*';
                        operation[i + 1, j + 2] = '*';
                        //multi
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i + 1, j + 1];
                        v4 = sudoku[i + 1, j + 2];
                        int multi = v1 * v2 * v3 * v4;
                        number[i, j] = multi;
                        number[i, j + 1] = multi;
                        number[i + 1, j + 1] = multi;
                        number[i + 1, j + 2] = multi;
                    }
                    return banderaZ;
                }
                else if ((matrix[i, j] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 1, j + 1] == ' ') && (matrix[i + 2, j + 1] == ' '))
                {
                    matrix[i, j] = 'z';
                    matrix[i + 1, j] = 'z';
                    matrix[i + 1, j + 1] = 'z';
                    matrix[i + 2, j + 1] = 'z';
                    banderaZ = true;
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 1, j + 1] = '+';
                        operation[i + 2, j + 1] = '+';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 1, j + 1];
                        v4 = sudoku[i + 2, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 1, j + 1] = suma;
                        number[i + 2, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 1, j + 1] = '*';
                        operation[i + 2, j + 1] = '*';
                        //multiplicacion
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 1, j + 1];
                        v4 = sudoku[i + 2, j + 1];
                        int multi = v1 * v2 * v3 * v4;
                        number[i, j] = multi;
                        number[i + 1, j] = multi;
                        number[i + 1, j + 1] = multi;
                        number[i + 2, j + 1] = multi;
                    }
                    return banderaZ;
                }
                else if ((matrix[i, j] == ' ') && (matrix[i + 1, j - 1] == ' ') && (matrix[i + 1, j] == ' ') && (matrix[i + 2, j - 1] == ' '))
                {
                    matrix[i, j] = 'z';
                    matrix[i + 1, j - 1] = 'z';
                    matrix[i + 1, j] = 'z';
                    matrix[i + 2, j - 1] = 'z';
                    banderaZ = true;
                    Console.WriteLine("Z4");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j - 1] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 2, j - 1] = '+';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j - 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 2, j - 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j - 1] = suma;
                        number[i + 1, j] = suma;
                        number[i + 2, j - 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j - 1] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 2, j - 1] = '*';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j - 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 2, j - 1];
                        int multi = v1 * v2 * v3 * v4;
                        number[i, j] = multi;
                        number[i + 1, j - 1] = multi;
                        number[i + 1, j] = multi;
                        number[i + 2, j - 1] = multi;
                    }
                    return banderaZ;
                }
                return banderaZ;
            }
            catch (IndexOutOfRangeException e)
            {
                return banderaZ;
            }
        }

        public Boolean validateT(int i, int j)
        {
            Boolean banderaT = false;
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int v4 = 0;
            try
            {
                if ((matrix[i, j] == 'n') && (matrix[i, j + 1] == 'n') && (matrix[i, j + 2] == 'n') && (matrix[i + 1, j + 1] == 'n'))
                {
                    matrix[i, j] = 't';
                    matrix[i, j + 1] = 't';
                    matrix[i, j + 2] = 't';
                    matrix[i + 1, j + 1] = 't';
                    banderaT = true;
                    Console.WriteLine("T1");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i, j + 1] = '+';
                        operation[i, j + 2] = '+';
                        operation[i + 1, j + 1] = '+';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i, j + 2];
                        v4 = sudoku[i + 1, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i, j + 1] = suma;
                        number[i, j + 2] = suma;
                        number[i + 1, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i, j + 1] = '*';
                        operation[i, j + 2] = '*';
                        operation[i + 1, j + 1] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i, j + 1];
                        v3 = sudoku[i, j + 2];
                        v4 = sudoku[i + 1, j + 1];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i, j + 1] = mult;
                        number[i, j + 2] = mult;
                        number[i + 1, j + 1] = mult;
                    }
                    return banderaT;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 2, j] == 'n') && (matrix[i + 1, j + 1] == 'n'))
                {
                    matrix[i, j] = 't';
                    matrix[i + 1, j] = 't';
                    matrix[i + 2, j] = 't';
                    matrix[i + 1, j + 1] = 't';
                    banderaT = true;
                    Console.WriteLine("T2");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 2, j] = '+';
                        operation[i + 1, j + 1] = '+';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 1, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 2, j] = suma;
                        number[i + 1, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 2, j] = '*';
                        operation[i + 1, j + 1] = '*';
                        //suma
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 1, j + 1];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i + 1, j] = mult;
                        number[i + 2, j] = mult;
                        number[i + 1, j + 1] = mult;
                    }
                    return banderaT;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i + 1, j - 1] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 1, j + 1] == 'n'))
                {
                    matrix[i, j] = 't';
                    matrix[i + 1, j - 1] = 't';
                    matrix[i + 1, j] = 't';
                    matrix[i + 1, j + 1] = 't';
                    banderaT = true;
                    Console.WriteLine("T3");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j - 1] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 1, j + 1] = '+';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j - 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 1, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j - 1] = suma;
                        number[i + 1, j] = suma;
                        number[i + 1, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j - 1] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 1, j + 1] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j - 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 1, j + 1];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i + 1, j - 1] = mult;
                        number[i + 1, j] = mult;
                        number[i + 1, j + 1] = mult;
                    }
                    return banderaT;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i + 1, j - 1] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 2, j] == 'n'))
                {
                    matrix[i, j] = 't';
                    matrix[i + 1, j - 1] = 't';
                    matrix[i + 1, j] = 't';
                    matrix[i + 2, j + 1] = 't';
                    banderaT = true;
                    Console.WriteLine("T4");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j - 1] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 2, j + 1] = '+';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j - 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 2, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j - 1] = suma;
                        number[i + 1, j] = suma;
                        number[i + 2, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j - 1] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 2, j + 1] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j - 1];
                        v3 = sudoku[i + 1, j];
                        v4 = sudoku[i + 2, j + 1];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i + 1, j - 1] = mult;
                        number[i + 1, j] = mult;
                        number[i + 2, j + 1] = mult;
                    }
                    return banderaT;
                }
                return banderaT;
            }
            catch(IndexOutOfRangeException e)
            {
                return banderaT;
            }
        }

        public Boolean validateL(int i, int j)
        {
            Boolean banderaL = false;
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int v4 = 0;
            try
            {
                if ((matrix[i, j] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 2, j] == 'n') && (matrix[i + 2, j + 1] == 'n'))
                {
                    matrix[i, j] = 'l';
                    matrix[i + 1, j] = 'l';
                    matrix[i + 2, j] = 'l';
                    matrix[i + 2, j + 1] = 'l';
                    banderaL = true;
                    Console.WriteLine("L1");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 2, j] = '+';
                        operation[i + 2, j + 1] = '+';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 2, j + 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 2, j] = suma;
                        number[i + 2, j + 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 2, j] = '*';
                        operation[i + 2, j + 1] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 2, j + 1];
                        int mutl = v1 * v2 * v3 * v4;
                        number[i, j] = mutl;
                        number[i + 1, j] = mutl;
                        number[i + 2, j] = mutl;
                        number[i + 2, j + 1] = mutl;
                    }
                    return banderaL;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 2, j] == 'n') && (matrix[i + 2, j - 1] == 'n'))
                {
                    matrix[i, j] = 'l';
                    matrix[i + 1, j] = 'l';
                    matrix[i + 2, j] = 'l';
                    matrix[i + 2, j - 1] = 'l';
                    banderaL = true;
                    Console.WriteLine("L2");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 2, j] = '+';
                        operation[i + 2, j - 1] = '+';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 2, j - 1];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 2, j] = suma;
                        number[i + 2, j - 1] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 2, j] = '*';
                        operation[i + 2, j - 1] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 2, j];
                        v4 = sudoku[i + 2, j - 1];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i + 1, j] = mult;
                        number[i + 2, j] = mult;
                        number[i + 2, j - 1] = mult;
                    }
                    return banderaL;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 1, j + 1] == 'n') && (matrix[i + 1, j + 2] == 'n'))
                {
                    matrix[i, j] = 'l';
                    matrix[i + 1, j] = 'l';
                    matrix[i + 1, j + 1] = 'l';
                    matrix[i + 1, j + 2] = 'l';
                    banderaL = true;
                    Console.WriteLine("L3");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 1, j + 1] = '+';
                        operation[i + 1, j + 2] = '+';
                        v1  = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 1, j + 1];
                        v4 = sudoku[i + 1, j + 2];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 1, j + 1] = suma;
                        number[i + 1, j + 2] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 1, j + 1] = '*';
                        operation[i + 1, j + 2] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 1, j + 1];
                        v4 = sudoku[i + 1, j + 2];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i + 1, j] = mult;
                        number[i + 1, j + 1] = mult;
                        number[i + 1, j + 2] = mult;
                    }
                    return banderaL;
                }
                else if ((matrix[i, j] == 'n') && (matrix[i + 1, j] == 'n') && (matrix[i + 1, j - 1] == 'n') && (matrix[i + 1, j - 2] == 'n'))
                {
                    matrix[i, j] = 'l';
                    matrix[i + 1, j] = 'l';
                    matrix[i + 1, j - 1] = 'l';
                    matrix[i + 1, j - 2] = 'l';
                    banderaL = true;
                    Console.WriteLine("L4");
                    if(generateOperation() == 1)
                    {
                        operation[i, j] = '+';
                        operation[i + 1, j] = '+';
                        operation[i + 1, j - 1] = '+';
                        operation[i + 1, j - 2] = '+';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 1, j - 1];
                        v4 = sudoku[i + 1, j - 2];
                        int suma = v1 + v2 + v3 + v4;
                        number[i, j] = suma;
                        number[i + 1, j] = suma;
                        number[i + 1, j - 1] = suma;
                        number[i + 1, j - 2] = suma;
                    }
                    else
                    {
                        operation[i, j] = '*';
                        operation[i + 1, j] = '*';
                        operation[i + 1, j - 1] = '*';
                        operation[i + 1, j - 2] = '*';
                        v1 = sudoku[i, j];
                        v2 = sudoku[i + 1, j];
                        v3 = sudoku[i + 1, j - 1];
                        v4 = sudoku[i + 1, j - 2];
                        int mult = v1 * v2 * v3 * v4;
                        number[i, j] = mult;
                        number[i + 1, j] = mult;
                        number[i + 1, j - 1] = mult;
                        number[i + 1, j - 2] = mult;
                    }
                    return banderaL;
                }
                return banderaL;
            }
            catch (IndexOutOfRangeException e)
            {
                return banderaL;
            }
        }

        public char buscar(int i, int j)
        {
            char valor = ' ';
            for (int fila = 0; fila < matrix.GetLength(0); fila++)
            {


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (fila == i & col == j)
                    {
                        valor = matrix[fila, col];
                    }
                }

            }
            return valor;

        }
        public int buscarNumber(int i, int j)
        {
            int valor = 0;
            for (int fila = 0; fila < number.GetLength(0); fila++)
            {


                for (int col = 0; col < number.GetLength(1); col++)
                {
                    if (fila == i & col == j)
                    {
                        valor = number[fila, col];
                    }
                }

            }
            return valor;

        }
        public char buscarOperation(int i, int j)
        {
            char valor = ' ';
            for (int fila = 0; fila < operation.GetLength(0); fila++)
            {


                for (int col = 0; col < operation.GetLength(1); col++)
                {
                    if (fila == i & col == j)
                    {
                        valor =operation[fila, col];
                    }
                }

            }
            return valor;

        }
        public int buscarSudoku(int i, int j)
        {
           int valor = 0;
            for (int fila = 0; fila < sudoku.GetLength(0); fila++)
            {


                for (int col = 0; col < sudoku.GetLength(1); col++)
                {
                    if (fila == i & col == j)
                    {
                        valor = sudoku[fila, col];
                    }
                }

            }
            return valor;

        }

        public void mostrar()
        {
            for (int fila = 0; fila < matrix.GetLength(0); fila++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[fila, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void mostrarOperacion()
        {
            for (int fila = 0; fila < operation.GetLength(0); fila++)
            {
                for (int col = 0; col < operation.GetLength(1); col++)
                {
                    Console.Write(operation[fila, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void mostrarNumbers()
        {
            for (int fila = 0; fila < number.GetLength(0); fila++)
            {
                for (int col = 0; col < number.GetLength(1); col++)
                {
                    Console.Write(number[fila, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void mostrarSudoku()
        {
            for (int fila = 0; fila < sudoku.GetLength(0); fila++)
            {
                for (int col = 0; col < sudoku.GetLength(1); col++)
                {
                    Console.Write(sudoku[fila, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public int generateOperation()
        {
            Random rand1 = new Random();
            int numOp = rand1.Next(1, 3);
            return numOp;
        }

        public int generateSuma(int first)
        {
            Random rand1 = new Random();
            int num = tam + tam;
            int numSuma = rand1.Next(first, num + 1);
            return numSuma;
        }

        public int generateMult(int first)
        {
            Random rand2 = new Random();
            int num = tam * tam;
            Console.WriteLine("first: ", first);
            Console.WriteLine("num: ", num);
            int numMult = rand2.Next(first, num + 1);
            return numMult;
        }


    }
}
