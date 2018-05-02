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
        Graphics drawArea;
        UnaryMultiplier um;
        bool FirstMultiplier = true;
        public Form1()
        {
            

            InitializeComponent();
            drawArea = DrawingArea.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (FirstMultiplier)
            {
                um = new UnaryMultiplier(MultiplierTxtEntry.Text);
                DrawMachine(um.Machine);
                button1.Text = "Next Step";
                FirstMultiplier = false;
            }
            else
            {
                this.ModifyTape();
                um.Machine.Next();
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
            //drawArea.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black);

            float NumberOfBoxes = machine.MachineTape.boxes.Count;
            int pointer = machine.Pointer;
            List<string> symbols = machine.MachineTape.boxes;

            float width = DrawingArea.Width - 4;

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
            Transition t = um.Machine.getAdequateTransition(um.Machine.CurrentStateNumber, um.Machine.CurrentSymbol);
            int p = um.Machine.Pointer;

            //drawArea.Clear(Color.White);
            Pen blackPen = new Pen(Color.Black);

            float NumberOfBoxes = um.Machine.MachineTape.boxes.Count;
            int pointer = um.Machine.Pointer;
            List<string> symbols = um.Machine.MachineTape.boxes;

            float width = DrawingArea.Width - 4;

            float boxWidth = width / NumberOfBoxes;
            float boxHeight = boxWidth;

            float startX = 2;
            float startY = (DrawingArea.Height - boxHeight) / 2;
            float letterHeight = (boxHeight - 5);

           

            if (um.Machine.AcceptingStates.Contains(um.Machine.CurrentStateNumber))
            {
                MessageBox.Show("Operación terminada");
                return;
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
                DrawString(symbols[pointer+1], startX + boxWidth * (pointer+1), startY + (boxHeight - letterHeight) / 2, letterHeight, Color.Red);
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
            do
            {
                if (FirstMultiplier)
                {
                    um = new UnaryMultiplier(MultiplierTxtEntry.Text);
                    DrawMachine(um.Machine);
                    button1.Text = "Next Step";
                    FirstMultiplier = false;
                }
                else
                {
                    this.ModifyTape();
                    um.Machine.Next();
                }
                Thread.Sleep(1000-Speed.Value);
                if (um.Machine.AcceptingStates.Contains(um.Machine.CurrentStateNumber))
                {
                    MessageBox.Show("Operación terminada");
                    return;
                }
            } while (!um.Machine.AcceptingStates.Contains(um.Machine.CurrentStateNumber));
        }
    }
}
