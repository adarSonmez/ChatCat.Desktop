using System.Windows;
using System.Windows.Media.Animation;

namespace ChatCat.Desktop.Extensions
{
    /// <summary>
    /// Provides extension methods for creating and managing storyboards for animations.
    /// </summary>
    public static class StoryboardExtensions
    {
        #region Slide Animations

        /// <summary>
        /// Adds a slide-in animation from the right to the storyboard.
        /// </summary>
        /// <param name="storyboard">The storyboard to which the animation will be added.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="windowWidth">The width of the window for calculating the slide distance.</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float duration, double windowWidth)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(windowWidth, 0, -windowWidth, 0),
                To = new Thickness(0)
            };

            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// Adds a slide-out animation to the left to the storyboard.
        /// </summary>
        /// <param name="storyboard">The storyboard to which the animation will be added.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="windowWidth">The width of the window for calculating the slide distance.</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float duration, double windowWidth)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(-windowWidth, 0, windowWidth, 0)
            };

            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// Adds a slide-in animation from the bottom to the storyboard.
        /// </summary>
        /// <param name="storyboard">The storyboard to which the animation will be added.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="windowHeight">The height of the window for calculating the slide distance.</param>
        public static void AddSlideFromBottom(this Storyboard storyboard, float duration, double windowHeight)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0, windowHeight, 0, -windowHeight),
                To = new Thickness(0)
            };

            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        /// <summary>
        /// Adds a slide-out animation to the top to the storyboard.
        /// </summary>
        /// <param name="storyboard">The storyboard to which the animation will be added.</param>
        /// <param name="duration">The duration of the animation.</param>
        /// <param name="windowHeight">The height of the window for calculating the slide distance.</param>
        public static void AddSlideToTop(this Storyboard storyboard, float duration, double windowHeight)
        {
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(0, -windowHeight, 0, windowHeight)
            };

            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(slideAnimation);
        }

        #endregion Slide Animations

        #region Fade Animations

        /// <summary>
        /// Adds a fade-in animation to the storyboard.
        /// </summary>
        /// <param name="storyboard">The storyboard to which the animation will be added.</param>
        /// <param name="duration">The duration of the fade-in animation.</param>
        public static void AddFadeIn(this Storyboard storyboard, float duration)
        {
            var fadeAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = 0,
                To = 1
            };

            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(fadeAnimation);
        }

        /// <summary>
        /// Adds a fade-out animation to the storyboard.
        /// </summary>
        /// <param name="storyboard">The storyboard to which the animation will be added.</param>
        /// <param name="duration">The duration of the fade-out animation.</param>
        public static void AddFadeOut(this Storyboard storyboard, float duration)
        {
            var fadeAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = 1,
                To = 0
            };

            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath("Opacity"));
            storyboard.Children.Add(fadeAnimation);
        }

        #endregion Fade Animations
    }
}