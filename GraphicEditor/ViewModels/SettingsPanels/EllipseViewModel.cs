﻿using Avalonia;
using Avalonia.Media;
using GraphicEditor.Models;
using ReactiveUI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.ViewModels.SettingsPanels
{
    public class EllipseViewModel : ShapeViewModelBase
    {
        public string ViewName => "Эллипс";
        string name;
        Point startPoint;
        int width, height;
        ISolidColorBrush fillColor;
        ISolidColorBrush strokeColor;
        ushort strokeThickness;
        ObservableCollection<ISolidColorBrush> colors;

        public EllipseViewModel()
        {
            var brushes = typeof(Brushes).GetProperties().Select(brush => (ISolidColorBrush)brush.GetValue(brush));
            Colors = new ObservableCollection<ISolidColorBrush>(brushes);
            Name = "";
            StartPoint = new Point(0, 0);
            Width = 0;
            Height = 0;
            StrokeThickness = 1;
            StrokeColor = Colors[0];
            FillColor = Colors[0];

        }
        public override PaintShape? GetShape()
        {
            if (Name != "")
            {
                if (StartPoint.Y != 0 && StartPoint.X != 0 && Width != 0 && Height !=0)
                {
                    return new PaintEllipse
                    {
                        Name = Name,
                        StartPoint = StartPoint,
                        Width = Width,
                        Height = Height,
                        FillColor = FillColor.Color,
                        StrokeColor = StrokeColor.Color,
                        StrokeThickness = StrokeThickness
                    };
                }
            }
            return null;
        }
        public override void ClearShape()
        {
            Name = "";
            StartPoint = new Point(0, 0);
            StrokeThickness = 1;
            StrokeColor = Colors[0];
            FillColor = Colors[0];
        }
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public Point StartPoint
        {
            get => startPoint;
            set => this.RaiseAndSetIfChanged(ref startPoint, value);
        }
        public int Width
        {
            get => width;
            set => this.RaiseAndSetIfChanged(ref width, value);
        }
        public int Height
        {
            get => height;
            set => this.RaiseAndSetIfChanged(ref height, value);
        }
        public ISolidColorBrush StrokeColor
        {
            get => strokeColor;
            set
            {
                this.RaiseAndSetIfChanged(ref strokeColor, value);
            }
        }
        public ISolidColorBrush FillColor
        {
            get => fillColor;
            set
            {
                this.RaiseAndSetIfChanged(ref fillColor, value);
            }
        }
        public ushort StrokeThickness
        {
            get => strokeThickness;
            set => this.RaiseAndSetIfChanged(ref strokeThickness, value);
        }
        public ObservableCollection<ISolidColorBrush> Colors
        {
            get => colors;
            set
            {
                this.RaiseAndSetIfChanged(ref colors, value);
            }
        }
    }
}