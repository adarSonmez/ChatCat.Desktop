using System.Runtime.InteropServices;
using System.Security;

namespace ChatCat.Core.Extensions;

/// <summary>
/// Contains extension methods for the <see cref="SecureString"/> class.
/// </summary>
public static class SecureStringExtensions
{
    /// <summary>
    /// Converts a SecureString to an unsecure string.
    /// </summary>
    /// <param name="secureString">The SecureString to convert unsecurely.</param>
    /// <returns>The unsecure string representation of the SecureString.</returns>
    public static string? ToUnsecureString(this SecureString secureString)
    {
        if (secureString == null)
            return string.Empty;

        IntPtr unmanagedString = IntPtr.Zero;

        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }
}