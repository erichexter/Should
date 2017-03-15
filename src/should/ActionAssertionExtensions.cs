using System;
using Should.Core.Assertions;

namespace Should
{
    public static class ActionAssertionExtensions
    {
        /// <summary>Verifies that the <paramref name="action"/> throws the specified exception type.</summary>
        /// <typeparam name="T">The type of exception expected to be thrown.</typeparam>
        /// <param name="action">The action which should throw the exception.</param>
        public static void ShouldThrow<T>(this Action action) where T : Exception
        {
            ShouldThrow<T>(new Assert.ThrowsDelegate(action));
        }

        /// <summary>
        /// Verifies that the <paramref name="@delegate"/> throws an <see cref="ArgumentException"/> with a <paramref name="paramName"/> that matches <see cref="ArgumentException.ParamName"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ArgumentException"/> expected to be thrown.</typeparam>
        /// <param name="action">The action which should throw the exception.</param>
        /// <param name="paramName">The name of the parameter that is invalid.</param>
        public static void ShouldThrow<T>(this Action action, string paramName) where T: ArgumentException
        {
            ShouldThrow<T>(new Assert.ThrowsDelegate(action), paramName);
        }


        /// <summary>Verifies that the <paramref name="@delegate"/> throws the specified exception type.</summary>
        /// <typeparam name="T">The type of exception expected to be thrown.</typeparam>
        /// <param name="delegate">A <see cref="Assert.ThrowsDelegate"/> which represents the action which should throw the exception.</param>
        public static void ShouldThrow<T>(this Assert.ThrowsDelegate @delegate) where T : Exception
        {
            Assert.Throws<T>(@delegate);
        }

        /// <summary>
        /// Verifies that the <paramref name="@delegate"/> throws an <see cref="ArgumentException"/> with a <paramref name="paramName"/> that matches <see cref="ArgumentException.ParamName"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="ArgumentException"/> expected to be thrown.</typeparam>
        /// <param name="delegate">A <see cref="Assert.ThrowsDelegate"/> which represents the action which should throw the exception.</param>
        /// <param name="paramName">The name of the parameter that is invalid.</param>
        public static void ShouldThrow<T>(this Assert.ThrowsDelegate @delegate, string paramName) where T : ArgumentException
        {
            var argumentException = Assert.Throws<T>(@delegate);
            Assert.Equal(paramName, argumentException.ParamName);
        }
    }
}