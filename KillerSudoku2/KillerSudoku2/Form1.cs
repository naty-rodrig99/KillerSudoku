using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace KillerSudoku2
{
    public partial class Form1 : Form
    {
        Matrix su;
        public Form1()
        {
            InitializeComponent();
            CreateTextBoxes19x19();
            table19x19.Visible = false;
            CreateTextBoxes18x18();
            table18x18.Visible = false;
            CreateTextBoxes17x17();
            table17x17.Visible = false;
            CreateTextBoxes16x16();
            table16x16.Visible = false;
            CreateTextBoxes15x15();
            table15x15.Visible = false;
            CreateTextBoxes14x14();
            table14x14.Visible = false;
            CreateTextBoxes13x13();
            table13x13.Visible = false;
            CreateTextBoxes12x12();
            table12x12.Visible = false;
            CreateTextBoxes11x11();
            table11x11.Visible = false;
            CreateTextBoxes10x10();
            table10x10.Visible = false;
            CreateTextBoxes9x9();
            table9x9.Visible = false;
            CreateTextBoxes8x8();
            table8x8.Visible = false;
            CreateTextBoxes7x7();
            table7x7.Visible = false;
            CreateTextBoxes6x6();
            table6x6.Visible = false;
            CreateTextBoxes5x5();
            table5x5.Visible = false;
        }
        private void Resolver(int n)
        {
            int sudoku = 0;
            for (int row = 0; row < n; row++)
            {
                for (int clm = 0; clm < n; clm++)
                {
                    sudoku = su.buscarSudoku(row, clm);
                    TextBox box = GetTextBoxAt(n, clm, row);
                    box.Multiline = true;
                    box.Text += Environment.NewLine;
                    box.Text += Convert.ToString(sudoku);
                }
            }


        }
        private void ShowGame(int n)
        {

            Matrix matriz = new Matrix(n);
            matriz.createMatrix();
            matriz.generateMatrix();
            matriz.mostrar();
            char valor = ' ';
            int numero = 0;
            char operacion = ' ';
            su = matriz;
            
            
            for (int row = 0; row < n; row++)
            {
                for (int clm = 0; clm < n; clm++)
                {
                    TextBox box = GetTextBoxAt(n, clm, row);

                            valor = matriz.buscar(row, clm);
                            numero = matriz.buscarNumber(row, clm);
                            operacion = matriz.buscarOperation(row, clm);
                            box.Text = Convert.ToString(numero)+ Convert.ToString(operacion);
                           
                            if (valor == 'c')
                            {
                                box.BackColor = Color.YellowGreen;
                                 box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                
                            }
                            else if (valor == 'l')
                            {
                                box.BackColor = Color.Gold;
                                 box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                            }
                            else if (valor == 'r')
                            {
                                box.BackColor = Color.Tomato;
                                box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            }   
                            else if (valor == 'p')
                            {
                                 box.BackColor = Color.MediumPurple;
                                box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            }
                            else if (valor == 'z')
                            {
                                box.BackColor = Color.Pink;
                                box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            }
                            else if (valor == 't')
                            {
                                box.BackColor = Color.DarkTurquoise;
                                box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                            }
                }
            }
            
        }

        private TextBox GetTextBoxAt(int n,int row, int clm)
        {
            if (n == 5)
            {
                return (TextBox)table5x5.GetControlFromPosition(row, clm);
            }
            else if(n== 6)
            {
                return (TextBox)table6x6.GetControlFromPosition(row, clm);
            }
            else if (n == 7)
            {
                return (TextBox)table7x7.GetControlFromPosition(row, clm);
            }
            else if (n == 8)
            {
                return (TextBox)table8x8.GetControlFromPosition(row, clm);
            }
            else if (n == 9)
            {
                return (TextBox)table9x9.GetControlFromPosition(row, clm);
            }
            else if (n == 10)
            {
                return (TextBox)table10x10.GetControlFromPosition(row, clm);
            }
            else if (n == 11)
            {
                return (TextBox)table11x11.GetControlFromPosition(row, clm);
            }
            else if (n == 12)
            {
                return (TextBox)table12x12.GetControlFromPosition(row, clm);
            }
            else if (n == 13)
            {
                return (TextBox)table13x13.GetControlFromPosition(row, clm);
            }
            else if (n == 14)
            {
                return (TextBox)table14x14.GetControlFromPosition(row, clm);
            }
            else if (n == 15)
            {
                return (TextBox)table15x15.GetControlFromPosition(row, clm);
            }
            else if (n == 16)
            {
                return (TextBox)table16x16.GetControlFromPosition(row, clm);
            }
            else if (n == 17)
            {
                return (TextBox)table17x17.GetControlFromPosition(row, clm);
            }
            else if (n == 18)
            {
                return (TextBox)table18x18.GetControlFromPosition(row, clm);
            }
            
            return (TextBox)table19x19.GetControlFromPosition(row, clm);

        }

        //Table 19x19
        private void CreateTextBoxes19x19()
        {
            for (int row = 0; row < table19x19.RowCount; row++)
            {
                for (int clm = 0; clm < table19x19.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                        
                    };
                    
                    textBox.KeyPress += textBox_KeyPress;
                    table19x19.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 18x18
        private void CreateTextBoxes18x18()
        {
            for (int row = 0; row < table18x18.RowCount; row++)
            {
                for (int clm = 0; clm < table18x18.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table18x18.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 17x17
        private void CreateTextBoxes17x17()
        {
            for (int row = 0; row < table17x17.RowCount; row++)
            {
                for (int clm = 0; clm < table17x17.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table17x17.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 16x16
        private void CreateTextBoxes16x16()
        {
            for (int row = 0; row < table16x16.RowCount; row++)
            {
                for (int clm = 0; clm < table16x16.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table16x16.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 15x15
        private void CreateTextBoxes15x15()
        {
            for (int row = 0; row < table15x15.RowCount; row++)
            {
                for (int clm = 0; clm < table15x15.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table15x15.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 14x14
        private void CreateTextBoxes14x14()
        {
            for (int row = 0; row < table14x14.RowCount; row++)
            {
                for (int clm = 0; clm < table14x14.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table14x14.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 13x13
        private void CreateTextBoxes13x13()
        {
            for (int row = 0; row < table13x13.RowCount; row++)
            {
                for (int clm = 0; clm < table13x13.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table13x13.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 12x12
        private void CreateTextBoxes12x12()
        {
            for (int row = 0; row < table12x12.RowCount; row++)
            {
                for (int clm = 0; clm < table12x12.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 5f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table12x12.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 11x11
        private void CreateTextBoxes11x11()
        {
            for (int row = 0; row < table11x11.RowCount; row++)
            {
                for (int clm = 0; clm < table11x11.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table11x11.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 10x10
        private void CreateTextBoxes10x10()
        {
            for (int row = 0; row < table10x10.RowCount; row++)
            {
                for (int clm = 0; clm < table10x10.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table10x10.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 9x9
        private void CreateTextBoxes9x9()
        {
            for (int row = 0; row < table9x9.RowCount; row++)
            {
                for (int clm = 0; clm < table9x9.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table9x9.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 8x8
        private void CreateTextBoxes8x8()
        {
            for (int row = 0; row < table8x8.RowCount; row++)
            {
                for (int clm = 0; clm < table8x8.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table8x8.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 7x7
        private void CreateTextBoxes7x7()
        {
            for (int row = 0; row < table7x7.RowCount; row++)
            {
                for (int clm = 0; clm < table7x7.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table7x7.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 6x6
        private void CreateTextBoxes6x6()
        {
            for (int row = 0; row < table6x6.RowCount; row++)
            {
                for (int clm = 0; clm < table6x6.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table6x6.Controls.Add(textBox, row, clm);
                }
            }
        }

        //Table 5x5
        private void CreateTextBoxes5x5()
        {
            for (int row = 0; row < table5x5.RowCount; row++)
            {
                for (int clm = 0; clm < table5x5.ColumnCount; clm++)
                {
                    var textBox = new TextBox
                    {
                        TextAlign = HorizontalAlignment.Center,
                        Font = new Font("Arial", 10f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        MaxLength = 1,
                        BackColor = Color.WhiteSmoke
                    };
                    textBox.KeyPress += textBox_KeyPress;
                    table5x5.Controls.Add(textBox, row, clm);
                    
                }
            }
        }

        static void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                switch (e.KeyChar)
                {
                    case ' ':
                        e.Handled = false;
                        break;
                    case (char)Keys.Back:
                        e.Handled = false;
                        break;
                    default:
                        e.Handled = true;
                        break;
                }
            else
            {
                e.Handled = false;
            }
            if (!(e.KeyChar == ' ' | e.KeyChar == '0')) return;
            e.KeyChar = (char)Keys.Back;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowGame(Convert.ToInt32(numericUpDown1.Value));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            table5x5.Visible = false;
            table6x6.Visible = false;
            table7x7.Visible = false;
            table8x8.Visible = false;
            table9x9.Visible = false;
            table10x10.Visible = false;
            table11x11.Visible = false;
            table12x12.Visible = false;
            table13x13.Visible = false;
            table14x14.Visible = false;
            table15x15.Visible = false;
            table16x16.Visible = false;
            table17x17.Visible = false;
            table18x18.Visible = false;
            table19x19.Visible = false;
        }

        private void table18x18_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table17x17_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table16x16_Paint(object sender, PaintEventArgs e)
        {
        }

        private void table15x15_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table14x14_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table13x13_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table12x12_Paint(object sender, PaintEventArgs e)
        {
        }

        private void table11x11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table10x10_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void table9x9_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void table8x8_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void table7x7_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table6x6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void table5x5_Paint(object sender, PaintEventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int caseSwitch = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            switch (caseSwitch)
            {
                case 5:
                    table5x5.Visible = true;
                    break;
                case 6:
                    table6x6.Visible = true;
                    break;
                case 7:
                    table7x7.Visible = true;
                    break;
                case 8:
                    table8x8.Visible = true;
                    break;
                case 9:
                    table9x9.Visible = true;
                    break;
                case 10:
                    table10x10.Visible = true;
                    break;
                case 11:
                    table11x11.Visible = true;
                    break;
                case 12:
                    table12x12.Visible = true;
                    break;
                case 13:
                    table13x13.Visible = true;
                    break;
                case 14:
                    table14x14.Visible = true;
                    break;
                case 15:
                    table15x15.Visible = true;
                    break;
                case 16:
                    table16x16.Visible = true;
                    break;
                case 17:
                    table17x17.Visible = true;
                    break;
                case 18:
                    table18x18.Visible = true;
                    break;
                default:
                    table19x19.Visible = true;
                    break;
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Matrix matriz = new Matrix(9);
            matriz.createMatrix();
            matriz.generateMatrix();
            matriz.mostrar();
            Console.WriteLine("\t");
            matriz.mostrarNumbers();
            Console.WriteLine("\t");
            matriz.mostrarOperacion();
        }

        private void draw(int tamano, char[,] matriz)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Resolver(Convert.ToInt32(numericUpDown1.Value));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hilos(int numOfThreads)
        {
            WaitHandle[] waitHandles = new WaitHandle[numOfThreads];

            for (int i = 0; i < numOfThreads; i++)
            {
                var j = i;
                var handle = new EventWaitHandle(false, EventResetMode.ManualReset);
                var thread = new Thread(() =>
                {
                    Thread.Sleep(j * 1000);
                    handle.Set();
                });
                waitHandles[j] = handle;
                thread.Start();
            }
            WaitHandle.WaitAll(waitHandles);
        }
    }
}
