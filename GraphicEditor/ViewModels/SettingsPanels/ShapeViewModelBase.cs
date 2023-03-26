using GraphicEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.ViewModels.SettingsPanels
{
    public abstract class ShapeViewModelBase : ViewModelBase
    {
        public abstract PaintShape? GetShape();
        public abstract void ClearShape();
    }
}
