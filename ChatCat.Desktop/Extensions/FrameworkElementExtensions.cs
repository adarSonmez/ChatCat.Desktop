using ChatCat.Core.Constants.Enums;
using System.Windows;
using System.Windows.Media.Animation;

namespace ChatCat.Desktop.Extensions;

/// <summary>
/// Provides extension methods for animating FrameworkElements in the application.
/// </summary>
public static class FrameworkElementExtensions
{
    #region FrameworkElement Animation Definitions

    /// <summary>
    /// Fades the element in, making it visible.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the fade-in animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task FadeInAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();

        sb.AddFadeIn(seconds);
        sb.Begin(element);

        element.Visibility = Visibility.Visible;

        await Task.Delay((int)(seconds * 1000));
    }

    /// <summary>
    /// Fades the element out, making it invisible.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the fade-out animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task FadeOutAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();

        sb.AddFadeOut(seconds);
        sb.Begin(element);

        // Wait for the animation to complete before changing visibility
        await Task.Delay((int)(seconds * 1000));
        element.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    /// Animates the element by sliding in from the right while fading in.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();

        sb.AddSlideFromRight(seconds, element.ActualWidth);
        sb.AddFadeIn(seconds);
        sb.Begin(element);

        element.Visibility = Visibility.Visible;

        await Task.Delay((int)(seconds * 1000));
    }

    /// <summary>
    /// Animates the element by sliding out to the left while fading out.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();

        sb.AddSlideToLeft(seconds, element.ActualWidth);
        sb.AddFadeOut(seconds);
        sb.Begin(element);

        // Wait for the animation to complete before changing visibility
        await Task.Delay((int)(seconds * 1000));
        element.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    /// Animates the element by sliding in from the left while fading in.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();

        sb.AddSlideFromLeft(seconds, element.ActualWidth);
        sb.AddFadeIn(seconds);
        sb.Begin(element);

        element.Visibility = Visibility.Visible;

        await Task.Delay((int)(seconds * 1000));
    }

    /// <summary>
    /// Animates the element by sliding out to the right while fading out.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();

        sb.AddSlideToRight(seconds, element.ActualWidth);
        sb.AddFadeOut(seconds);
        sb.Begin(element);

        // Wait for the animation to complete before changing visibility
        await Task.Delay((int)(seconds * 1000));
        element.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    /// Animates the element by sliding in from the bottom while fading in.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task SlideAndFadeInFromBottomAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();
        sb.AddSlideFromBottom(seconds, element.ActualHeight);
        sb.AddFadeIn(seconds);
        sb.Begin(element);
        element.Visibility = Visibility.Visible;
        await Task.Delay((int)(seconds * 1000));
    }

    /// <summary>
    /// Animates the element by sliding out to the bottom while fading out.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task SlideAndFadeOutToBottomAsync(this FrameworkElement element, float seconds)
    {
        var sb = new Storyboard();
        sb.AddSlideToBottom(seconds, element.ActualHeight);
        sb.AddFadeOut(seconds);
        sb.Begin(element);
        await Task.Delay((int)(seconds * 1000));
        element.Visibility = Visibility.Collapsed;
    }

    #endregion FrameworkElement Animation Definitions

    #region FrameworkElement Animation Execution

    /// <summary>
    /// Begins the specified animation on the FrameworkElement.
    /// </summary>
    /// <param name="element">The FrameworkElement to animate.</param>
    /// <param name="animation">The animation to perform.</param>
    /// <param name="seconds">The duration of the animation in seconds.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task BeginAnimationAsync(this FrameworkElement element, FrameworkAnimationType animation, float seconds)
    {
        switch (animation)
        {
            case FrameworkAnimationType.None:
                break;

            case FrameworkAnimationType.FadeIn:
                await element.FadeInAsync(seconds);
                break;

            case FrameworkAnimationType.FadeOut:
                await element.FadeOutAsync(seconds);
                break;

            case FrameworkAnimationType.SlideAndFadeInFromRight:
                await element.SlideAndFadeInFromRightAsync(seconds);
                break;

            case FrameworkAnimationType.SlideAndFadeOutToLeft:
                await element.SlideAndFadeOutToLeftAsync(seconds);
                break;

            case FrameworkAnimationType.SlideAndFadeInFromLeft:
                await element.SlideAndFadeInFromLeftAsync(seconds);
                break;

            case FrameworkAnimationType.SlideAndFadeOutToRight:
                await element.SlideAndFadeOutToRightAsync(seconds);
                break;

            case FrameworkAnimationType.SlideAndFadeInFromBottom:
                await element.SlideAndFadeInFromBottomAsync(seconds);
                break;

            case FrameworkAnimationType.SlideAndFadeOutToBottom:
                await element.SlideAndFadeOutToBottomAsync(seconds);
                break;

            default:
                break;
        }
    }

    #endregion FrameworkElement Animation Execution
}