using System.Linq.Expressions;
using System.Reflection;

namespace ChatCat.Core.Extensions;

/// <summary>
/// Provides extension methods for working with expressions to get and set property values dynamically.
/// </summary>
public static class ExpressionExtensions
{
    #region Get Property Value

    /// <summary>
    /// Retrieves the value of a property using an expression that represents the property.
    /// </summary>
    /// <typeparam name="T">The type of the property to be retrieved.</typeparam>
    /// <param name="lambda">An expression representing the property.</param>
    /// <returns>The current value of the property.</returns>
    public static T? GetPropertyValue<T>(this Expression<Func<T?>> lambda)
    {
        return lambda.Compile().Invoke();
    }

    /// <summary>
    /// Retrieves the value of a property from a specific input object using an expression.
    /// </summary>
    /// <typeparam name="In">The type of the input object containing the property.</typeparam>
    /// <typeparam name="T">The type of the property to be retrieved.</typeparam>
    /// <param name="lambda">An expression representing the property on the input object.</param>
    /// <param name="input">The object from which to retrieve the property value.</param>
    /// <returns>The current value of the property from the specified input object.</returns>
    public static T? GetPropertyValue<In, T>(this Expression<Func<In, T?>> lambda, In input)
    {
        return lambda.Compile().Invoke(input);
    }

    #endregion Get Property Value

    #region Set Property Value

    /// <summary>
    /// Sets the value of a property using an expression that represents the property.
    /// </summary>
    /// <typeparam name="T">The type of the property to be set.</typeparam>
    /// <param name="lambda">An expression representing the property.</param>
    /// <param name="value">The new value to be assigned to the property.</param>
    /// <exception cref="ArgumentNullException">Thrown if the expression is null.</exception>
    public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
    {
        var expression = lambda.Body as MemberExpression
            ?? throw new ArgumentNullException(nameof(lambda), "Expression body is null");

        var propertyInfo = (PropertyInfo)expression.Member;
        var target = Expression.Lambda(expression.Expression!).Compile().DynamicInvoke();

        propertyInfo.SetValue(target, value);
    }

    /// <summary>
    /// Sets the value of a property on a specific input object using an expression.
    /// </summary>
    /// <typeparam name="In">The type of the input object containing the property.</typeparam>
    /// <typeparam name="T">The type of the property to be set.</typeparam>
    /// <param name="lambda">An expression representing the property on the input object.</param>
    /// <param name="value">The new value to be assigned to the property.</param>
    /// <param name="input">The object on which to set the property value.</param>
    /// <exception cref="ArgumentNullException">Thrown if the expression is null.</exception>
    public static void SetPropertyValue<In, T>(this Expression<Func<In, T>> lambda, T value, In input)
    {
        var expression = lambda.Body as MemberExpression
            ?? throw new ArgumentNullException(nameof(lambda), "Expression body is null");

        var propertyInfo = (PropertyInfo)expression.Member;

        propertyInfo.SetValue(input, value);
    }

    #endregion Set Property Value
}