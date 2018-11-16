using System.Windows;
using System.Windows.Controls;

namespace RemoteCommander.Shared.Controls
{
    /// <summary>
    /// Interaction logic for DoubleLabel.xaml
    /// </summary>
    public partial class DoubleLabel : UserControl
    {
        #region Dependency Properties
        public string LeftText
        {
            get { return (string)GetValue(LeftTextProperty); }
            set { SetValue(LeftTextProperty, value); }
        }
        public static readonly DependencyProperty LeftTextProperty =
            DependencyProperty.Register("LeftText", typeof(string), typeof(DoubleLabel), new PropertyMetadata(string.Empty));

        public string RightText
        {
            get { return (string)GetValue(RightTextProperty); }
            set { SetValue(RightTextProperty, value); }
        }
        public static readonly DependencyProperty RightTextProperty =
            DependencyProperty.Register("RightText", typeof(string), typeof(DoubleLabel), new PropertyMetadata(string.Empty));
        #endregion

        #region Constructor
        public DoubleLabel()
        {
            InitializeComponent();
        }
        #endregion
    }
}
