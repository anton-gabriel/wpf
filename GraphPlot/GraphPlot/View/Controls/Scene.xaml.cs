using System.Windows.Controls;
using System.Windows.Input;

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

        private void ModelUIElement3D_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Console.WriteLine("ModelUIElement3D_MouseDown");
        }
    }
}
