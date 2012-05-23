using System.Linq.Expressions;

namespace Should.Fluent.Model
{
    public static class BeMethodCallExpressionExtensions
    {
        public static MethodCallExpression Equal(this IBe<MethodCallExpression> be, MethodCallExpression expectedCall)
        {
            return be.Should.Apply(
                (t, a) =>
                {
                    if (GetMethodsAreUnEqual(expectedCall, t))
                    {
                        a.Fail("Expected method calls to be equal, but they were not.");
                    }
                },
                (t, a) =>
                {
                    if (GetMethodsAreUnEqual(expectedCall, t) == false)
                    {
                        a.Fail("Expected method calls to be equal, but they were not.");
                    }
                });
        }

        private static bool GetMethodsAreUnEqual(MethodCallExpression expectedCall, MethodCallExpression target)
        {
            var bothNull = target == null && expectedCall == null;
            return !bothNull &&
                   (target == null || expectedCall == null || !target.Method.Equals(expectedCall.Method) || !AllArgsAreEqual(expectedCall, target));
        }

        private static bool AllArgsAreEqual(MethodCallExpression expectedCall, MethodCallExpression target)
        {
            for (var i = 0; i < target.Arguments.Count; i++)
            {
                var targetArgValue = Expression.Lambda(target.Arguments[i]).Compile().DynamicInvoke();
                var expectedArgValue = Expression.Lambda(expectedCall.Arguments[i]).Compile().DynamicInvoke();
                var bothNull = targetArgValue == null && expectedArgValue == null;
                if (!bothNull && (targetArgValue == null ||  expectedArgValue == null || !targetArgValue.Equals(expectedArgValue)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}