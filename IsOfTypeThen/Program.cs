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
}



