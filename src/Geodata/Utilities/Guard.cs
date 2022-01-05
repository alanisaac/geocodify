using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Geodata.Utilities
{
    /// <summary>
    /// Provides a set of helper methods for precondition checks.
    /// </summary>
    internal static class Guard
    {
        /// <summary>
        /// Throws an exception if the specified value is not between the lower value and higher value inclusive.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="lowerValue">The lower value.</param>
        /// <param name="higherValue">The higher value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentOutOfRangeException">Value must be between {lowerValue} and {higherValue} inclusive.</exception>
        [DebuggerHidden]
        public static void ArgumentIsBetween<T>(T argumentValue, T lowerValue, T higherValue, [InvokerParameterName] string argumentName) where T : struct, IComparable
        {
            if (argumentValue.CompareTo(lowerValue) < 0 || argumentValue.CompareTo(higherValue) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, $"Value must be between {lowerValue} and {higherValue} inclusive.");
            }
        }

        /// <summary>
        /// Throws an exception if the specified value is not a number (NaN).
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentException">Value cannot be null or empty.</exception>
        [DebuggerHidden]
        public static void ArgumentNotNaN(double argumentValue, [InvokerParameterName] string argumentName)
        {
            if (double.IsNaN(argumentValue))
            {
                throw new ArgumentException("Value must be a valid number.", argumentName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified value is null or whitespace.
        /// </summary>
        /// <param name="argumentValue">The argument value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace.</exception>
        [DebuggerHidden]
        public static void ArgumentNotNullOrWhitespace(string argumentValue, [InvokerParameterName] string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", argumentName);
            }
        }
    }
}
