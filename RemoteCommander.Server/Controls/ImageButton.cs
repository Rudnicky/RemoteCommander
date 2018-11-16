using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RemoteCommander.Server.Controls
{
    public class ImageButton : Button
    {
        #region Dependency Properties
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));

        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth", typeof(double), typeof(ImageButton), new PropertyMetadata(double.NaN));

        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(ImageButton), new PropertyMetadata(double.NaN));
        #endregion

        #region Constructor
        public ImageButton()
        {

        }
        #endregion
    }
}
