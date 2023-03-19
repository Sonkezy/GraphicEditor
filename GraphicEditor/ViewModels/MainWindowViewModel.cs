using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Media;
using GraphicEditor.Models;
using GraphicEditor.ViewModels.SettingsPanels;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace GraphicEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ushort selectedShapeType = 0;
        bool isStraightLine = true;
        ObservableCollection<Shape> shapes= new ObservableCollection<Shape>();
        object content;
        ObservableCollection<ViewModelBase> vmbaseCollection;
        ObservableCollection<string> shapesName = new ObservableCollection<string>();
        public MainWindowViewModel() 
        {
            IBrush stroke = Brushes.Red;
            Line line = new Line {Name="line01", StartPoint = new Point(0, 0), EndPoint = new Point(100, 100), Stroke = stroke, StrokeThickness = 5 };
            Shapes.Add(line);
            ShapesName.Add(line.Name);
            line = new Line { Name = "line02", StartPoint = new Point(10, 50), EndPoint = new Point(200, 200), Stroke = Brushes.Green, StrokeThickness = 5 };
            Shapes.Add(line);
            ShapesName.Add(line.Name);
            vmbaseCollection = new ObservableCollection<ViewModelBase>();
            vmbaseCollection.Add(new StraightLineViewModel());
            Content = vmbaseCollection[0];

            buttonAdd = ReactiveCommand.Create(() =>
            {
            StraightLineViewModel viewModels = new StraightLineViewModel();
                if (Object.ReferenceEquals(Content.GetType(), viewModels.GetType()))
                {
                    StraightLineViewModel viewModel = (StraightLineViewModel)Content;
                    Shape? figure = viewModel.GetShape();
                    if (figure != null)
                    {
                        Shapes.Add(figure);
                        ShapesName.Add(figure.Name);
                    }
                }
            });
            

        }
        public ObservableCollection<Shape> Shapes
        {
            get => shapes;
            set => this.RaiseAndSetIfChanged(ref shapes, value);
        }
        public ObservableCollection<string> ShapesName
        {
            get => shapesName;
            set => this.RaiseAndSetIfChanged(ref shapesName, value);
        }
        public bool IsStraightLine
        {
            get => isStraightLine;
            set => this.RaiseAndSetIfChanged(ref isStraightLine, value);
        }
        public ushort SelectedShapeType
        {
            get => selectedShapeType;
            set => this.RaiseAndSetIfChanged(ref selectedShapeType, value); 
        }
        public void ShapeTypeChanged(object sender, EventArgs e)
        {
            if(SelectedShapeType != 0)
            {
                IsStraightLine = false;
            }
            else
            {
                IsStraightLine = true;
            }
        }
        public object Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }

        public ObservableCollection<ViewModelBase> VmbaseCollection
        {
            get => vmbaseCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref vmbaseCollection, value);
            }
        }
        public ReactiveCommand<Unit, Unit> buttonAdd { get; }
        //public ReactiveCommand<Shape, Unit> buttonRemove { get; }
    }
}