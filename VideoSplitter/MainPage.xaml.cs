using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace VideoSplitter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TitleBar _titleBar;
        private string? _ffmpegPath;
        private readonly EventHandler<string> _fileDropped;
        private readonly EventHandler<string> _ffmpegSet;
        public readonly string[] supportedTypes = [".mkv", ".mp4", ".mov", ".avi", ".mp3", ".m4a", ".wav"];

        public MainPage()
        {
            _fileDropped = (sender, path) => GoToSplitter(path);
            _ffmpegSet = (sender, path) => _ffmpegPath = path;
            InitializeComponent();
        }

        private void GoToSplitter(string videoPath)
        {
            if (_ffmpegPath == null) return;
            Frame.Navigate(typeof(VideoSplitterPage), new SplitterProps { FfmpegPath = _ffmpegPath, VideoPath = videoPath, TypeToNavigateTo = typeof(MainPage).FullName });
            _titleBar.IsBackButtonVisible = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is TitleBar titleBar)
            {
                _titleBar = titleBar;
                return;
            }
            _titleBar.IsBackButtonVisible = false;

            if (e.Parameter is List<string> splitFolders)
            {
                Console.WriteLine($"{splitFolders.Count} folders were generated");
            }
        }
    }
}
