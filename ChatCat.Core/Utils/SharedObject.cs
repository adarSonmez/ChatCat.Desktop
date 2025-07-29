namespace ChatCat.Core.Utils;

/// <summary>
/// Provides shared constants and properties used across the application.
/// </summary>
public static class SharedObject
{
    /// <summary>
    /// Gets or sets a value indicating whether the application is running in design mode.
    /// </summary>
    /// <remarks>
    /// This property is typically used to differentiate runtime behavior from design-time behavior
    /// in tools like Visual Studio or Blend.
    /// </remarks>
    public static bool InDesignMode { get; set; } = true;
}