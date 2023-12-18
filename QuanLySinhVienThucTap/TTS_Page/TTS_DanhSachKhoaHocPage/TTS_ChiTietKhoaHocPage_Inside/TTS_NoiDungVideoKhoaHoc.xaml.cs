using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLySinhVienThucTap.TTS_Page.TTS_DanhSachKhoaHocPage.TTS_ChiTietKhoaHocPage_Inside
{
    /// <summary>
    /// Interaction logic for TTS_NoiDungVideoKhoaHoc.xaml
    /// </summary>
    public partial class TTS_NoiDungVideoKhoaHoc : Page
    {
        private bool isPlaying = true;

        public TTS_NoiDungVideoKhoaHoc(string MaKhoaDaoTao, int VideoNo)
        {
            InitializeComponent();
            string videoPath = "..\\..\\Static\\Videos\\KPMG OnDemand App Introduction.mp4";
            mediaElement.Source = new Uri(videoPath, UriKind.RelativeOrAbsolute);
            Loaded += TTS_NoiDungVideoKhoaHoc_Loaded;
            mediaElement.MouseLeftButtonDown += MediaElement_MouseLeftButtonDown;
        }

        private void TTS_NoiDungVideoKhoaHoc_Loaded(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

private void MediaElement_MouseLeftButtonDown(object sender, RoutedEventArgs e)
{
    // Kiểm tra xem video đang chạy hay không và thực hiện tương ứng
    if (isPlaying)
    {
        mediaElement.Pause();
    }
    else
    {
        mediaElement.Play();
    }


    // Đảo ngược trạng thái của biến isPlaying
    isPlaying = !isPlaying;

    // Thực hiện hiệu ứng mờ và nảy lên cho Border overlayBorder
    ToggleOverlayAnimation();
        }

private void ToggleOverlayAnimation()
{
    DoubleAnimation opacityAnimation = new DoubleAnimation();
    opacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
    opacityAnimation.From = overlayBorder.Opacity;
    opacityAnimation.To = isPlaying ? 0 : 0.4; // 0.7 is the desired opacity when video is paused

    Storyboard storyboard = new Storyboard();
    storyboard.Children.Add(opacityAnimation);

    Storyboard.SetTarget(opacityAnimation, overlayBorder);
    Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(OpacityProperty)); // Corrected line

    // Toggle the visibility of play/pause icons
    playIcon.Visibility = isPlaying ? Visibility.Visible : Visibility.Collapsed;
    pauseIcon.Visibility = isPlaying ? Visibility.Collapsed : Visibility.Visible;

    storyboard.Begin();
}

    }

}
