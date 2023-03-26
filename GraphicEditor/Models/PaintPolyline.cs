using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GraphicEditor.Models
{
    [Serializable]
    public class PaintPolyline : PaintShape
    {

        List<Point> points;
        public PaintPolyline()
        {
            points= new List<Point>();
            pointsX = new List<double>();
            pointsY = new List<double>();
        }
        [XmlIgnore]
        public List<Point> Points
        {
            get => points;
            set => points = value;
        }
        public List<double> pointsX;
        public List<double> pointsY;
        public override void Serialize()
        {
            colorA = StrokeColor.A;
            colorR = StrokeColor.R;
            colorG = StrokeColor.G;
            colorB = StrokeColor.B;
            foreach(var point in points)
            {
                pointsX.Add(point.X);
                pointsY.Add(point.Y);
            }
        }
        public override void Deserialize()
        {
            StrokeColor = Color.FromArgb(colorA, colorR, colorG, colorB);
            points.Clear();
            for (int i=0;i<pointsX.Count;i++)
            {
                points.Add(new Point(pointsX[i], pointsY[i]));
            }
        }
    }
}
