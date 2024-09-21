using ChatCat.Desktop.Animations;
using ChatCat.Desktop.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace ChatCat.Desktop.Pages
{
    /// <summary>
    /// Base class for pages in the application, providing animation capabilities.
    /// </summary>
    public class BasePage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += BasePage_Loaded;
        }

        protected virtual float SlideSeconds { get; set; } = 0.8f;
        protected virtual PageAnimation PageLoadAnimation { get; set; } = PageAnimation.None;
        protected virtual PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.None;

        /// <summary>
        /// Begins the specified animation for the page.
        /// </summary>
        /// <param name="animation">The animation to perform.</param>
        /// <param name="seconds">The duration of the animation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
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

                default:
                    break;
            }
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                await BeginAnimationAsync(PageLoadAnimation, SlideSeconds);
            }
        }

        private async void BasePage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (PageUnloadAnimation != PageAnimation.None)
            {
                await BeginAnimationAsync(PageUnloadAnimation, SlideSeconds);
            }
        }
    }
}