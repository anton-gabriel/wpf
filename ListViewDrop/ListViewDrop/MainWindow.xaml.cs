using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ListViewDrop
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


        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ListView source)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(source, new DataObject(format: typeof(IList), data: source.SelectedItems), DragDropEffects.Move);
                }
            }
        }

        private void ListView_Drop(object sender, DragEventArgs args)
        {
            if (args.Data.GetDataPresent(typeof(IList)))
            {
                var selection = args.Data.GetData(typeof(IList)) as IList;
                if (args.Source is ListView source)
                {
                    selection?.OfType<string>().ToList().ForEach(item => source.Items.Add(item));
                }
            }
        }

        private void GridViewColumn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
