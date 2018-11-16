using System.Windows;
using System.Windows.Controls;

namespace RemoteCommander.Shared.Utils
{
    public class AvailableHostsItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var listView = VisualTreeTraverseHelper.FindParent<ListView>(container);
            if (listView != null)
            {
                int indexOfItem = listView.Items.IndexOf(item);
                if (indexOfItem == 0)
                {
                    return listView.FindResource("FirstItemStyle") as DataTemplate;
                }

                return listView.FindResource("DefaultItemStyle") as DataTemplate;
            }

            return null;
        }
    }
}
