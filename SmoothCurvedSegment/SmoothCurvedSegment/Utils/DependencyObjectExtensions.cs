using System.Windows;
using System.Windows.Media;

namespace SmoothCurvedSegment.Utils
{
    static class DependencyObjectExtensions
    {
        public static T FindParent<T>(this DependencyObject child)
            where T : DependencyObject
        {
            switch (VisualTreeHelper.GetParent(child))
            {
                case null:
                    return null;
                case T parent:
                    return parent;
                default:
                    return FindParent<T>(VisualTreeHelper.GetParent(child));
            };
        }
    }
}
