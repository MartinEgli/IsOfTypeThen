using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var x = new ClassA();
            x.IsOfTypeThen<ClassA, ClassB>((a) => a.Value);
            x.IsOfTypeThen<ClassB>((a) => a.Value);
        }
    }

    public class ClassA
    {

    }

    public class ClassB
    {
        public bool Value { get; set; }

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
    }

}



