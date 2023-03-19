using Avalonia.Controls.Shapes;
using Avalonia.Media;
using DynamicData;
using GraphicEditor.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.ViewModels.SettingsPanels
{
    public class StraightLineViewModel : ViewModelBase 
    {
        public string ViewName => "Прямая линия";
        string name;
        Avalonia.Point startPoint;
        Avalonia.Point endPoint;
        ColorItem strokeColor;
        ushort strokeThickness;

        ObservableCollection<ColorItem> colors;
        public StraightLineViewModel() 
        {
            colors = new ObservableCollection<ColorItem>();
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            KnownColor[] allColors = new KnownColor[colorsArray.Length];
            Array.Copy(colorsArray, allColors, colorsArray.Length);
            for(int i = 0; i < allColors.Length; i++)
            {
                System.Drawing.Color Color = System.Drawing.Color.FromName(allColors[i].ToString());
                SolidColorBrush solidColorBrush = new SolidColorBrush(new Avalonia.Media.Color(Color.A, Color.R, Color.G, Color.B));
                Colors.Add(new ColorItem { Color = solidColorBrush });
            }
            Name = "";
            StartPoint = new Avalonia.Point(0, 0);
            EndPoint = new Avalonia.Point(0, 0);
            StrokeThickness = 1;
            StrokeColor = Colors[32];

        }
        public Shape? GetShape()
        {
            if(Name != "" && StrokeThickness > 0)
            {
                if (StartPoint.Y != 0 || StartPoint.X != 0 || EndPoint.X != 0 || EndPoint.Y != 0)
                {
                    return new Line { Name = Name, StartPoint = StartPoint, EndPoint = EndPoint, Stroke = StrokeColor.Color, StrokeThickness = StrokeThickness };
                }
            }
            return null;
        }
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public Avalonia.Point StartPoint
        {
            get => startPoint;
            set => this.RaiseAndSetIfChanged(ref startPoint, value);
        }
        public Avalonia.Point EndPoint
        {
            get => endPoint;
            set => this.RaiseAndSetIfChanged(ref endPoint, value);
        }
        public ColorItem StrokeColor
        {
            get => strokeColor;
            set
            {
                this.RaiseAndSetIfChanged(ref strokeColor, value);
            }
        }
        public ushort StrokeThickness
        {
            get => strokeThickness;
            set => this.RaiseAndSetIfChanged(ref strokeThickness, value);
        }
        public ObservableCollection<ColorItem> Colors
        {
            get => colors;
            set
            {
                this.RaiseAndSetIfChanged(ref colors, value);
            }
        }
    }
}
