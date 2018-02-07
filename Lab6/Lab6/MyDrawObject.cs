using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab6
{
    class MyDrawObject
    {
        protected Color PenColor;
        protected int PenWidth;

        public MyDrawObject(int inPenCol, int inPenWid)
        {
            PenColor = PCconvert(inPenCol);
            PenWidth = inPenWid;
        }

        public virtual void Drawself(Graphics g)
        {
            return;
        }

        protected Color PCconvert(int inputidx)
        {
            Color mycolor;
            switch (inputidx)
            {
                case 1:
                    mycolor = Color.FromName("Red");
                    break;
                case 2:
                    mycolor = Color.FromName("Blue");
                    break;
                case 3:
                    mycolor = Color.FromName("Green");
                    break;
                default:
                    mycolor = Color.FromName("Black");
                    break;
            }
            return mycolor;
        }

        protected Color FCconvert(int inputidx)
        {
            Color mycolor;
            switch (inputidx)
            {
                case 1:
                    mycolor = Color.FromName("Black");
                    break;
                case 2:
                    mycolor = Color.FromName("Red");
                    break;
                case 3:
                    mycolor = Color.FromName("Blue");
                    break;
                case 4:
                    mycolor = Color.FromName("Green");
                    break;
                default:
                    mycolor = Color.FromName("White");
                    break;
            }
            return mycolor;
        }
    }

    class MyLine : MyDrawObject
    {
        private Point p1, p2;

        public MyLine(Point inp1, Point inp2, int inPenCol, int inPenWid):base(inPenCol, inPenWid)
        {
            p1 = inp1;
            p2 = inp2;
        }

        public override void Drawself(Graphics g)
        {
            Pen mypen = new Pen(PenColor, PenWidth);
            g.DrawLine(mypen, p1, p2);
            return;
        } 
    }

    class MyRectangle : MyDrawObject
    {
        private int x, y, width, height;
        private Color FillColor;
        bool isFill, isOutline;

        public MyRectangle(Point inp1, Point inp2, int inPenCol, int inPenWid, int inFillCol, bool inIsFill, bool inIsOutline)
            : base(inPenCol, inPenWid)
        {
            if (inp1.X <= inp2.X) x = inp1.X;
            else x = inp2.X;
            if (inp1.Y <= inp2.Y) y = inp1.Y;
            else y = inp2.Y;
            width = Math.Abs(inp1.X - inp2.X);
            height = Math.Abs(inp1.Y - inp2.Y);
            FillColor = FCconvert(inFillCol);
            isFill = inIsFill;
            isOutline = inIsOutline;
        }

        public override void Drawself(Graphics g)
        {
            Pen myOutlinepen = new Pen(PenColor, PenWidth);
            Brush myFillbrush = new SolidBrush(FillColor);
            if (isFill) g.FillRectangle(myFillbrush, x, y, width, height);
            if (isOutline) g.DrawRectangle(myOutlinepen, x, y, width, height);
            return;
        }
    }

    class MyEllipse : MyDrawObject
    {
        private int x, y, width, height;
        private Color FillColor;
        bool isFill, isOutline;

        public MyEllipse(Point inp1, Point inp2, int inPenCol, int inPenWid, int inFillCol, bool inIsFill, bool inIsOutline)
            : base(inPenCol, inPenWid)
        {
            if (inp1.X <= inp2.X) x = inp1.X;
            else x = inp2.X;
            if (inp1.Y <= inp2.Y) y = inp1.Y;
            else y = inp2.Y;
            width = Math.Abs(inp1.X - inp2.X);
            height = Math.Abs(inp1.Y - inp2.Y);
            FillColor = FCconvert(inFillCol);
            isFill = inIsFill;
            isOutline = inIsOutline;
        }

        public override void Drawself(Graphics g)
        {
            Pen myOutlinepen = new Pen(PenColor, PenWidth);
            Brush myFillbrush = new SolidBrush(FillColor);
            if (isFill) g.FillEllipse(myFillbrush, x, y, width, height);
            if (isOutline) g.DrawEllipse(myOutlinepen, x, y, width, height);
            return;
        }
    }

}
