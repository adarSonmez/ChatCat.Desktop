using ChatCat.Core.Constants.Enums;
using ChatCat.Core.ViewModels.Base;
using ChatCat.Desktop.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.Pages
{
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        private VM _viewModel = new();

        public BasePage()
        {
            Loaded += BasePage_Loaded;
            Unloaded += BasePage_Unloaded;

            DataContext = _viewModel;
        }

        public VM ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;

                DataContext = _viewModel;
            }
        }

        protected virtual float SlideSeconds { get; set; } = 0.8f;
        protected virtual PageAnimation PageLoadAnimation { get; set; } = PageAnimation.None;
        protected virtual PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.None;

        private async Task BeginAnimationAsync(PageAnimation animation, float seconds)
        {
            switch (animation)
            {
                case PageAnimation.None:
                    break;

                case PageAnimation.FadeIn:
                    await this.FadeInAsync(seconds);
                    break;

                case PageAnimation.FadeOut:
                    await this.FadeOutAsync(seconds);
                    break;

                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(seconds);
                    break;

                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(seconds);
                    break;

                case PageAnimation.SlideAndFadeInFromLeft:
                    await this.SlideAndFadeInFromLeftAsync(seconds);
                    break;

                default:
                    break;
            }
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
                await BeginAnimationAsync(PageLoadAnimation, SlideSeconds);
            }
        }

        private async void BasePage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (PageUnloadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Visible;
                await BeginAnimationAsync(PageUnloadAnimation, SlideSeconds);
            }
        }
    }
}