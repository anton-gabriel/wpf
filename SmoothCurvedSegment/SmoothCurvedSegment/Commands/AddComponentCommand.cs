using SmoothCurvedSegment.Utils;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class AddComponentCommand
        : RelayCommand<FrameworkElement>
    {
        #region Constructors
        public AddComponentCommand(CanvasScaleViewModel canvasScaleViewModel)
        {
            CanvasScaleViewModel = canvasScaleViewModel ?? throw new ArgumentNullException(nameof(canvasScaleViewModel));
            ExecuteDelegate = ChangePosition;
        }
        #endregion

        #region Properties
        private CanvasScaleViewModel CanvasScaleViewModel { get; }
        #endregion

        #region Private methods
        private void ChangePosition(FrameworkElement args)
        {
            args.GetType().ToString().Dump();
            CanvasScaleViewModel.Components.Add(new ComponentViewModel(new Model.Component()
            {
                Margin = new Thickness(1000, 10, 0, 0),
                Width = 10,
                Height = 10,
            })
            { Color = Brushes.Orange });
        }
        #endregion
    }
}
