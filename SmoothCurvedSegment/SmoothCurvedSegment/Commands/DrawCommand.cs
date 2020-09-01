using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace SmoothCurvedSegment.Commands
{
    internal sealed class DrawCommand
        : RelayCommand<object>
    {
        public DrawCommand(SmoothCurveViewModel smoothCurveViewModel)
        {
            SmoothCurveViewModel = smoothCurveViewModel ?? throw new ArgumentNullException(nameof(smoothCurveViewModel));
            ExecuteDelegate = async param => await DrawAsync();
            CanExecuteDelegate = param => CanDraw();
        }

        #region Properties
        private SmoothCurveViewModel SmoothCurveViewModel { get; }
        private Random RandomGenerator { get; } = new Random();
        private CancellationTokenSource CancellationTokenSource { get; set; }
        private bool IsDrawing { get; set; }
        #endregion


        #region Private methods
        private bool CanDraw()
        {
            return true;
        }

        private async Task DrawAsync()
        {
            Trace.WriteLine($"Method called: {nameof(DrawAsync)}");
            CancellationTokenSource = new CancellationTokenSource();

            if (IsDrawing)
            {
                CancellationTokenSource.Cancel();
                IsDrawing = false;
                return;
            }
            await Task.Run(async () =>
            {
                try
                {
                    CancellationTokenSource.Token.ThrowIfCancellationRequested();
                    IsDrawing = true;
                    Trace.WriteLine($"Drawing started from method: {nameof(DrawAsync)}");
                    while (true)
                    {
                        CancellationTokenSource.Token.ThrowIfCancellationRequested();
                        Vector currentVector = new Vector(800, 500);
                        var points = Enumerable.Range(0, RandomGenerator.Next(0, 100)).Select(_ =>
                        {
                            var vector1 = currentVector;
                            var vector4 = currentVector + new Vector(RandomGenerator.Next(-1000, 1000), RandomGenerator.Next(-1000, 1000));
                            Vector middle = vector1.Lerp(vector4, factor: 0.5);
                            Vector vector2 = new Vector(middle.X, vector1.Y);
                            Vector vector3 = new Vector(middle.X, vector4.Y);
                            currentVector = vector1;
                            return new List<Point>() { (Point)vector1, (Point)vector2, (Point)vector3, (Point)vector4 };
                        }).SelectMany(list => list).ToList();

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            SmoothCurveViewModel.PointsCollection = points;
                            CalculateFps();
                        });
                        await Task.Delay(1);
                    }
                }
                catch (OperationCanceledException exception)
                {
                    Trace.WriteLine($"Exception occured [{exception.GetType()}]: {exception.Message}.");
                }
            }, CancellationTokenSource.Token);
        }

        private DateTime last;
        private int frames;
        void CalculateFps()
        {
            frames++;
            if ((DateTime.Now - last).TotalSeconds >= 1)
            {

                SmoothCurveViewModel.Fps = $"{frames}";
                frames = 0;
                last = DateTime.Now;
            }
        }
        #endregion
    }
}
