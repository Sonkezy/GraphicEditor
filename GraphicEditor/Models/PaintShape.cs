using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GraphicEditor.Models
{
    [Serializable]
    [XmlInclude(typeof(PaintStraightLine))]
    [XmlInclude(typeof(PaintPolyline))]
    [XmlInclude(typeof(PaintPolygon))]
    [XmlInclude(typeof(PaintRectangle))]
    [XmlInclude(typeof(PaintEllipse))]
    [XmlInclude(typeof(PaintPath))]
    public class PaintShape
    {
        string name;
        int strokeThickness;
        Color strokeColor;
        public PaintShape()
        {
            name = "";
            strokeThickness = 1;
            strokeColor = Colors.Black;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int StrokeThickness
        {
            get => strokeThickness;
            set => strokeThickness = value;
        }
        [XmlIgnore]
        public Color StrokeColor
        {
            get => strokeColor;
            set => strokeColor = value;
        }
        public byte colorA;
        public byte colorR;
        public byte colorG;
        public byte colorB;
        public virtual void Serialize()
        {
            colorA = StrokeColor.A;
            colorR = StrokeColor.R;
            colorG = StrokeColor.G;
            colorB = StrokeColor.B;
        }
        public virtual void Deserialize()
        {
            StrokeColor = Color.FromArgb(colorA, colorR, colorG, colorB);
        }
    }
}
