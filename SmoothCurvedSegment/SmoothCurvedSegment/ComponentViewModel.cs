using SmoothCurvedSegment.Commands;
using SmoothCurvedSegment.Model;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SmoothCurvedSegment
{
    internal sealed class ComponentViewModel
    {
        #region Constructors
        public ComponentViewModel(Component model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
        #endregion

        #region Properties
        public double ZIndex { get; set; }
        public Component Model { get; }
        public Point AnchorPoint { get; set; }
        public bool IsInDrag { get; set; }
        public Brush Color { get; set; }
        #endregion

        #region Commands
        private ICommand catchComponentCommand;
        public ICommand CatchComponentCommand => catchComponentCommand ?? (catchComponentCommand = new CatchComponentCommand(this));

        private ICommand moveComponentCommand;
        public ICommand MoveComponentCommand => moveComponentCommand ?? (moveComponentCommand = new MoveComponentCommand(this));

        private ICommand releaseComponentCommand;
        public ICommand ReleaseComponentCommand => releaseComponentCommand ?? (releaseComponentCommand = new ReleaseComponentCommand(this));
        #endregion
    }
}
