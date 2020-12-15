using System;

namespace IsOfTypeThen
{
    public static class MyExtensions
    {
        public static bool IsOfTypeThen<TSource, TTarget>(this TSource source, Predicate<TTarget> predicate) where TTarget : class
        {
            if (!(source is TTarget s))
            {
                return false;
            }
           
            return predicate(s);
        }

        public static bool IsOfTypeThen<TTarget>(this object source, Predicate<TTarget> predicate, bool @default = false)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (!(source is TTarget s))
            {
                return @default;
            }

            return predicate(s);
        }

        public static void OfTypeThen<TTarget>(this object source, Action<TTarget> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            if (!(source is TTarget s))
            {
                return;
            }

            action(s);
        }

        public static TResult OfTypeThen<TTarget, TResult>(this object source, Func<TTarget, TResult> function, TResult @default = default)
        {
            if (function == null) throw new ArgumentNullException(nameof(function));
            if (!(source is TTarget s))
            {
                return @default;
            }

            return function(s);
        }

        public static bool TryOfTypeThen<TTarget, TResult>(this object source, Func<TTarget, TResult> function, out TResult value, TResult @default = default)
        {
            value = @default;
            if (function == null) throw new ArgumentNullException(nameof(function));
            if (!(source is TTarget s))
            {
                return false;
            }

            value = function(s);
            return true;
        }
    }
}