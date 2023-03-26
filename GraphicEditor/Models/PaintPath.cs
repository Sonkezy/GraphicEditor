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
    public class PaintPath : PaintShape
    {

        Geometry data;
        Color fillColor;
        public PaintPath()
        {
            data = Geometry.Parse("");
            fillColor = Colors.White;
        }
        [XmlIgnore]
        public Geometry Data
        {
            get => data;
            set => data = value;
        }
        [XmlIgnore]
        public Color FillColor
        {
            get => fillColor;
            set => fillColor = value;
        }

        public byte fillColorA;
        public byte fillColorR;
        public byte fillColorG;
        public byte fillColorB;
        string commands;
        public string Commands
        {
            get => commands;
            set => commands = value;
        }
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
            
        }
        public override void Deserialize()
        {
            StrokeColor = Color.FromArgb(colorA, colorR, colorG, colorB);
            FillColor = Color.FromArgb(fillColorA, fillColorR, fillColorG, fillColorB);
            Data = Geometry.Parse(Commands);
        }
    }
}
