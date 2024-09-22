using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChatCat.Desktop.Extensions
{
    /// <summary>
    /// Provides extension methods for animating pages in the application.
    /// </summary>
    public static class PageExtensions
    {
        #region Page Animations

        /// <summary>
        /// Animates the page by sliding in from the right while fading in.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The duration of the animation in seconds.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, page.WindowWidth);
            sb.AddFadeIn(seconds);
            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Animates the page by sliding out to the left while fading out.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The duration of the animation in seconds.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideToLeft(seconds, page.WindowWidth);
            sb.AddFadeOut(seconds);
            sb.Begin(page);

            // Wait for the animation to complete before changing visibility
            await Task.Delay((int)(seconds * 1000));
            page.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Fades the page in, making it visible.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The duration of the fade-in animation in seconds.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task FadeInAsync(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeIn(seconds);
            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Fades the page out, making it invisible.
        /// </summary>
        /// <param name="page">The page to animate.</param>
        /// <param name="seconds">The duration of the fade-out animation in seconds.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task FadeOutAsync(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddFadeOut(seconds);
            sb.Begin(page);

            // Wait for the animation to complete before changing visibility
            await Task.Delay((int)(seconds * 1000));
            page.Visibility = Visibility.Collapsed;
        }

        #endregion Page Animations
    }
}