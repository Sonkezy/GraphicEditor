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
    [Serializable]
    public class PaintStraightLine : PaintShape
    {

        Point endPoint;
        Point startPoint;
        public PaintStraightLine()
        {
            startPoint = new Point(0, 0);
            endPoint = new Point(0, 0);
        }
        [XmlIgnore]
        public Point StartPoint
        {
            get => startPoint;
            set => startPoint = value;
        }
        [XmlIgnore]
        public Point EndPoint
        {
            get => endPoint;
            set => endPoint = value;
        }

        public double startPointX;
        public double startPointY;
        public double endPointX;
        public double endPointY;
        public override void Serialize()
        {
            colorA = StrokeColor.A;
            colorR = StrokeColor.R;
            colorG = StrokeColor.G;
            colorB = StrokeColor.B;
            startPointX = startPoint.X;
            startPointY = startPoint.Y;
            endPointX= endPoint.X;
            endPointY = endPoint.Y;
        }
        public override void Deserialize()
        {
            StrokeColor = Color.FromArgb(colorA, colorR, colorG, colorB);
            StartPoint = new Point(startPointX, startPointY);
            EndPoint = new Point(endPointX, endPointY);
        }
    }
}
