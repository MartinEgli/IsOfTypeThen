using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new ClassA();
            var r1 = x.IsOfTypeThen<ClassA, ClassB>((a) => a.Value == string.Empty);
            var r2 = x.IsOfTypeThen((ClassB a) => a.Value == string.Empty);
            var r3 = x.OfTypeThen<ClassB, string>((a) => a.Value);
            var r4 = x.OfTypeThen((ClassB a) => a.Value);
            var r5 = x.TryOfTypeThen<ClassB, string>((a) => a.Value, out var s1);
            var r6 = x.TryOfTypeThen((ClassB a) => a.Value, out var s2);
            var r7 = x.TryOfTypeThen<ClassB, string>((a) => a.Value, out var s3, "");
            var r8 = x.TryOfTypeThen((ClassB a) => a.Value, out var s4, "");
        }
    }

    public class ClassA
    {

    }

    public class ClassB
    {
        public string Value { get; set; }

    }


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



