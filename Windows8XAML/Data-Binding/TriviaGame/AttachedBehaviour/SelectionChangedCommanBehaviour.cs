using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TriviaGame.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TriviaGame.AttachedBehaviour
{
    public static class SelectionChangedCommanBehaviour
    {
        public static bool GetCategory(DependencyObject obj)
        {
            return (bool)obj.GetValue(CategoryProperty);
        }

        public static void SetCategory(DependencyObject obj, bool value)
        {
            obj.SetValue(CategoryProperty, value);
        }

        // Using a DependencyProperty as the backing store for Category.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.RegisterAttached("Category", typeof(bool), typeof(SelectionChangedCommanBehaviour), new PropertyMetadata(false, OnCategotySelected));

        private static void OnCategotySelected(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listItem = d as ListBoxItem;

            if (listItem != null)
            {
                if ((bool)e.NewValue)
                {
                
                    listItem.Tapped += ListBoxItem_Tapped;
                }
                else
                {
                    listItem.Tapped -= ListBoxItem_Tapped;
                }
            }
        }

        private static void ListBoxItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var selected = sender as ListBoxItem;
            selected.Parent.SetValue(ListBox.NameProperty, selected.Content);
            selected.Parent.SetValue(ListBox.VisibilityProperty, Visibility.Collapsed);
            string categoryName = selected.Content as string;
          
        }
    }
}
