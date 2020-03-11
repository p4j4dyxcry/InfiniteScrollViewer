using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace InfiniteScrollViewer
{
    internal static class VisualTreeExtensions
    {
        internal static T FindChildWithName<T>(this FrameworkElement root, string name) 
            where T : FrameworkElement
        {
            return root.FindChild<T>(x => x.Name == name);
        }        
        
        internal static T FindChild<T>(this FrameworkElement root, Func<FrameworkElement, bool> compare) 
            where T : FrameworkElement
        {
            var children = Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(root)).Select(x => VisualTreeHelper.GetChild(root, x)).OfType<FrameworkElement>().ToArray();

            foreach (var child in children)
            {
                if (child is T t && compare(child))
                    return t;

                t = child.FindChild<T>(compare);
                if (t != null)
                    return t;
            }
            return null;
        }
    }
}