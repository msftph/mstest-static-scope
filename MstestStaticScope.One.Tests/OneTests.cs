using MstestStaticScope.Shared;

namespace MstestStaticScope.One.Tests;

[TestClass]
[DoNotParallelize]
public sealed class OneTests
{
    [TestMethod]
    public void TestOneA()
    {
        var methodName = nameof(TestOneA);
        Console.WriteLine($"{DateTime.UtcNow} - Before {methodName}: {StaticClass.State}");
        StaticClass.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {methodName}: {StaticClass.State}");
    }

    [TestMethod]
    public void TestOneB()
    {
        var methodName = nameof(TestOneB);
        Console.WriteLine($"{DateTime.UtcNow} - Before {methodName}: {StaticClass.State}");
        StaticClass.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {methodName}: {StaticClass.State}");
    }
}
