using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace GraphPlot.View.Controls
{
    /// <summary>
    /// Interaction logic for Scene.xaml
    /// </summary>
    public partial class Scene
        : UserControl
    {
        public Scene()
        {
            InitializeComponent();
            Focusable = true;
            Loaded += (_, __) => Keyboard.Focus(this);
        }

        Random r = new Random();
        private void ModelUIElement3D_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Console.WriteLine("Mouse down on ModelUIElement3D");
            (Geometry.Material as DiffuseMaterial).Brush = new SolidColorBrush(Color.FromArgb(255, (byte)r.Next(0,255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
            PerspectiveCameraKey.BeginAnimation(ProjectionCamera.PositionProperty, new Point3DAnimation()
            {
                By = new Point3D(0, 0, 1),
                SpeedRatio = 2
            });
        }
    }
}
