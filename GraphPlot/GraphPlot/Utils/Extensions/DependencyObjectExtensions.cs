using System.Windows;
using System.Windows.Media;

namespace GraphPlot.Utils.Extensions
{
    internal static class DependencyObjectExtensions
    {
        public static T FindParent<T>(this DependencyObject child)
            where T : DependencyObject
        {
            return (VisualTreeHelper.GetParent(child)) switch
            {
                null => null,
                T parent => parent,
                _ => FindParent<T>(VisualTreeHelper.GetParent(child)),
            };
        }

        public static T FindChild<T>(this DependencyObject data)
            where T : DependencyObject
        {
            if (data != null)
            {
                for (int index = 0; index < VisualTreeHelper.GetChildrenCount(data); index++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(data, index);
                    return (child as T) ?? FindChild<T>(child);
                }
            }
            return null;
        }

        public static bool IsDataContextRoot(this DependencyObject data)
        {
            return DependencyPropertyHelper.GetValueSource(data, FrameworkElement.DataContextProperty).BaseValueSource == BaseValueSource.Local;
        }
    }
}
