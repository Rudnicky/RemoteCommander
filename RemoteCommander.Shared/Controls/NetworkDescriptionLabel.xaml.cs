using System.Windows;
using System.Windows.Controls;

namespace RemoteCommander.Shared.Controls
{
    /// <summary>
    /// Interaction logic for NetworkDescriptionLabel.xaml
    /// </summary>
    public partial class NetworkDescriptionLabel : UserControl
    {
        #region Dependency Properties
        public string LeftText
        {
            get { return (string)GetValue(LeftTextProperty); }
            set { SetValue(LeftTextProperty, value); }
        }
        public static readonly DependencyProperty LeftTextProperty =
            DependencyProperty.Register("LeftText", typeof(string), typeof(NetworkDescriptionLabel), new PropertyMetadata(string.Empty));

        public string RightText
        {
            get { return (string)GetValue(RightTextProperty); }
            set { SetValue(RightTextProperty, value); }
        }
        public static readonly DependencyProperty RightTextProperty =
            DependencyProperty.Register("RightText", typeof(string), typeof(NetworkDescriptionLabel), new PropertyMetadata(string.Empty));
        #endregion

        #region Constructor
        public NetworkDescriptionLabel()
        {
            InitializeComponent();
        }
        #endregion
    }
}
