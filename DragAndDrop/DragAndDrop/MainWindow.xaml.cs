using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lblFrom = e.Source as Label;

            if (e.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(lblFrom, lblFrom.Content, DragDropEffects.Copy);
        }

        private void Label1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Label lblFrom = e.Source as Label;

            if (!e.KeyStates.HasFlag(DragDropKeyStates.LeftMouseButton))
                lblFrom.Content = "...";
        }

        private void Label2_Drop(object sender, DragEventArgs e)
        {
            string draggedText = (string)e.Data.GetData(DataFormats.StringFormat);

            Label toLabel = e.Source as Label;
            toLabel.Content = draggedText;
        }
    }
}
