using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GraphicEditor.Models
{
    public class PaintEllipse : PaintShape
    {
        Point startPoint;
        Color fillColor;
        int width;
        int height;
        public PaintEllipse()
        {
            startPoint = new Point(0, 0);
            width= 0;
            height= 0;
        }
        [XmlIgnore]
        public Point StartPoint
        {
            get => startPoint;
            set => startPoint = value;
        }
        [XmlIgnore]
        public Color FillColor
        {
            get => fillColor;
            set => fillColor = value;
        }
        public int Width
        {
            get => width;
            set => width = value;
        }
        public int Height
        {
            get => height;
            set => height = value;
        }
        public double startPointX;
        public double startPointY;
        public double endPointX;
        public double endPointY;
        public byte fillColorA;
        public byte fillColorR;
        public byte fillColorG;
        public byte fillColorB;
        public override void Serialize()
        {
            colorA = StrokeColor.A;
            colorR = StrokeColor.R;
            colorG = StrokeColor.G;
            colorB = StrokeColor.B;
            fillColorA = FillColor.A;
            fillColorR = FillColor.R;
            fillColorG = FillColor.G;
            fillColorB = FillColor.B;
            startPointX = startPoint.X;
            startPointY = startPoint.Y;
        }
        public override void Deserialize()
        {
            StrokeColor = Color.FromArgb(colorA, colorR, colorG, colorB);
            FillColor = Color.FromArgb(fillColorA, fillColorR, fillColorG, fillColorB);
            StartPoint = new Point(startPointX, startPointY);
        }
    }
}
