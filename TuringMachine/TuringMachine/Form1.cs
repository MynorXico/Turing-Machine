using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class Form1 : Form
    {
        int Contador = 0;
        Graphics drawArea;
        TuringMachine um;
        bool FirstMultiplier = true;
        bool valide = false;

        public Form1()
        {
            InitializeComponent();
            drawArea = DrawingArea.CreateGraphics();
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FirstMultiplier)
            {
                valide = false;
                SelectMachine();
                for (int i = 0; i < um.TapeAlphabet.Count; i++)
                {
                    DataGridViewColumn dgvc = new DataGridViewColumn();
                    dgvc.CellTemplate = new DataGridViewTextBoxCell();
                    dgvc.Name = um.TapeAlphabet[i];
                    dataGridView1.Columns.Add(dgvc);
                }
                for (int i = 0; i < um.Q.Count; i++)
                {
                    dataGridView1.Rows.Add(("q" + i), "q" + i);
                    dataGridView1.Rows[i].HeaderCell.Value = "q" + i;
                    dataGridView1.RowHeadersWidth = 50; 
                }

                for(int i = 0; i < um.Q.Count; i++)
                {
                    for(int j = 0; j < um.TapeAlphabet.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = um.Q[i].getTransition(um.TapeAlphabet[j]);
                    }
                }

                Contador = 0;
                DrawMachine(um);
                Contador++;
                button1.Text = "Next Step";
                FirstMultiplier = false;
                this.textBox1.Text = "State q"+um.CurrentStateNumber+": "+um.CurrentState.Descripción;
                this.textBox2.Text = "Number of steps: " +Contador.ToString();

            }
            else
            {
                Contador++;
                this.ModifyTape();
                
                um.Next();
                this.textBox1.Text = "State q" + um.CurrentStateNumber + ": " + um.CurrentState.Descripción;
                this.textBox2.Text = "Number of steps: " +Contador.ToString();

                dataGridView1.ClearSelection();
                try
                {
                    dataGridView1.Rows[um.CurrentStateNumber].Cells[um.TapeAlphabet.IndexOf(um.CurrentSymbol)].Selected = true;
                }
                catch
                {
                    if (!um.AcceptingStates.Contains(um.CurrentStateNumber))
                    {
                        timer1.Stop();
                        if(!this.valide)
                        MessageBox.Show(String.Format("La entrada es inválida", Contador.ToString()));
                        valide = true;
                        SelectMachine();
                        return;
                    }
                    
                }
            }

        }

        public void DrawArrow(float startX, float starY, float endX, float endY, Color color)
        {
            Pen pen = new Pen(color, 8);
            pen.StartCap = LineCap.ArrowAnchor;
            pen.EndCap = LineCap.RoundAnchor;
            drawArea.DrawLine(pen, endX, endY, startX, starY);
        }

        public void DrawString(String drawString, float x, float y, float size, Color color)
        {
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", size, GraphicsUnit.Pixel);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(color);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawArea.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            //drawFont.Dispose();
            //drawBrush.Dispose();
            //drawArea.Dispose();
        }

        public void DrawMachine(TuringMachine machine)
        {
            drawArea.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black);

            float NumberOfBoxes = machine.MachineTape.boxes.Count;
            int pointer = machine.Pointer;
            List<string> symbols = machine.MachineTape.boxes;

            float width = DrawingArea.Width - 10;

            float boxWidth = width / NumberOfBoxes;
            float boxHeight = boxWidth;

            float startX = 2;
            float startY = (DrawingArea.Height - boxHeight) / 2;
            float letterHeight = (boxHeight - 5);

            DrawArrow((startX + boxWidth / 2) + pointer * boxWidth, startY + boxHeight + 50, (startX + boxWidth / 2) + pointer * boxWidth, startY + boxHeight + 5, Color.FromArgb(255, 0, 0, 255));

            for (int i = 0; i < NumberOfBoxes; i++)
            {
                drawArea.DrawLine(blackPen, startX + boxWidth * i, startY, startX + boxWidth * i, startY + boxHeight);
                drawArea.DrawLine(blackPen, startX + boxWidth * (i + 1), startY, startX + boxWidth * (i + 1), startY + boxHeight);
                drawArea.DrawLine(blackPen, startX + boxWidth * i, startY, startX + boxWidth * (i + 1), startY);
                drawArea.DrawLine(blackPen, startX + boxWidth * i, startY + boxHeight, startX + boxWidth * (i + 1), startY + boxHeight);
                DrawString(symbols[i], startX + boxWidth * i, startY + (boxHeight - letterHeight) / 2, letterHeight, Color.Black);
            }
        }

        public void ModifyTape()
        {
            Transition t = um.getAdequateTransition(um.CurrentStateNumber, um.CurrentSymbol);
            
            int p = um.Pointer;

            //drawArea.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black);

            float NumberOfBoxes = um.MachineTape.boxes.Count;
            int pointer = um.Pointer;
            List<string> symbols = um.MachineTape.boxes;

            float width = DrawingArea.Width - 10;

            float boxWidth = width / NumberOfBoxes;
            float boxHeight = boxWidth;

            float startX = 2;
            float startY = (DrawingArea.Height - boxHeight) / 2;
            float letterHeight = (boxHeight - 5);

           

            if (um.AcceptingStates.Contains(um.CurrentStateNumber))
            {
                timer1.Stop();
                MessageBox.Show(String.Format("Operación terminada en {0} pasos", Contador.ToString()));
                this.valide = true;
                SelectMachine();
                return;
            }
            else if (t == null)
            {
                if (!um.AcceptingStates.Contains(um.CurrentStateNumber))
                {
                    timer1.Stop();
                    if(!valide)
                    MessageBox.Show(String.Format("La entrada es inválida", Contador.ToString()));
                    valide = true;
                    SelectMachine();
                    return;
                }
                
            }
            DrawArrow((startX + boxWidth / 2) + pointer * boxWidth, startY + boxHeight + 50, (startX + boxWidth / 2) + pointer * boxWidth, startY + boxHeight + 5, Color.White);

            DrawFilledRectangle(Convert.ToInt32(startX + boxWidth * (pointer)) + 3, Convert.ToInt32(startY) + 3, Convert.ToInt32(boxWidth) - 6, Convert.ToInt32(boxHeight) - 6, Color.White);
            DrawString(t.replacingSymbol, startX + boxWidth * (pointer), startY + (boxHeight - letterHeight) / 2, letterHeight, Color.Black);

            DrawString(symbols[pointer], startX + boxWidth * pointer, startY + (boxHeight - letterHeight) / 2, letterHeight, Color.White);


            DrawFilledRectangle(Convert.ToInt32(startX + boxWidth * pointer)+3, Convert.ToInt32(startY)+3, Convert.ToInt32(boxWidth)-6, Convert.ToInt32(boxHeight)-6, Color.White);
            
            DrawString(t.replacingSymbol, startX + boxWidth * pointer, startY + (boxHeight - letterHeight) / 2, letterHeight, Color.Black);
            if (t.right)
            {
                DrawArrow((startX + boxWidth / 2) + (pointer + 1) * boxWidth, startY + boxHeight + 50, (startX + boxWidth / 2) + (pointer + 1) * boxWidth, startY + boxHeight + 5, Color.FromArgb(255, 0, 0, 255));
                try
                {
                    DrawString(symbols[pointer + 1], startX + boxWidth * (pointer + 1), startY + (boxHeight - letterHeight) / 2, letterHeight, Color.Red);
                }
                catch
                {
                    MessageBox.Show("Cadena no válida");
                }
            }
            else
            {
                DrawArrow((startX + boxWidth / 2) + (pointer - 1) * boxWidth, startY + boxHeight + 50, (startX + boxWidth / 2) + (pointer - 1) * boxWidth, startY + boxHeight + 5, Color.FromArgb(255, 0, 0, 255));
                DrawString(symbols[pointer-1], startX + boxWidth * (pointer - 1), startY + (boxHeight - letterHeight) / 2, letterHeight, Color.Red);
            }
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }


        private void DrawFilledRectangle(int startX, int startY, int endX, int endY, Color color)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            drawArea.FillRectangle(myBrush, new Rectangle(startX, startY, endX, endY));
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        public void DrawState()
        {
            DrawFilledRectangle(9, 9, 900, 40, Color.White);
            DrawString(um.CurrentState.Descripción, 10, 10, 30, Color.Black);
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void DrawingArea_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void Speed_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1001-Speed.Value;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            FirstMultiplier = true;
            textBox3.Text = "Ejemplo de entrada:\n {111+11=} Caracteres válidos: 1+=";
 
        }

        private void SelectMachine()
        {
            FirstMultiplier = true;
            drawArea.Clear(Color.White);
            while(dataGridView1.Columns.Count >=1)
            {
                dataGridView1.Columns.RemoveAt(0);
            }
            if (radioButton1.Checked)
            {
                um = new Subtractor("", "♭"+MultiplierTxtEntry.Text);
            }else if (radioButton2.Checked)
            {
                um = new Adder("", MultiplierTxtEntry.Text);
            }else if (radioButton3.Checked)
            {
                um = new UnaryMultiplier("", MultiplierTxtEntry.Text);
            }else if (radioButton4.Checked)
            {
                um = new Duplicador("", "♭" + MultiplierTxtEntry.Text);
            }else if (radioButton5.Checked)
            {
                um = new PalindromeValidator("", MultiplierTxtEntry.Text+ "♭♭");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FirstMultiplier = true;
            textBox3.Text = "Ejemplo de entrada:\n {111-11=} Caracteres válidos: 1,-,=";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FirstMultiplier = true;
            textBox3.Text = "Ejemplo de entrada:\n {111*11=} Caracteres válidos: 1,*,=";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            FirstMultiplier = true;
            textBox3.Text = "Ejemplo de entrada:\n {abc} Caracteres válidos: a,b,c";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            FirstMultiplier = true;
            textBox3.Text = "Ejemplo de entrada:\n {abcba} Caracteres válidos: a,b,c";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
