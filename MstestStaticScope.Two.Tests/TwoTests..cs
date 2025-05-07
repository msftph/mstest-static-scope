using MstestStaticScope.Shared;

namespace MstestStaticScope.Two.Tests;

[TestClass]
[DoNotParallelize]
public sealed class TwoTests
{
    [TestMethod]
    public void TestTwoA()
    {
        var methodName = nameof(TestTwoA);
        Console.WriteLine($"{DateTime.UtcNow} - Before {methodName}: {StaticClass.State}");
        StaticClass.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {methodName}: {StaticClass.State}");
    }

    [TestMethod]
    public void TestTwoB()
    {
        var methodName = nameof(TestTwoB);
        Console.WriteLine($"{DateTime.UtcNow} - Before {methodName}: {StaticClass.State}");
        StaticClass.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {methodName}: {StaticClass.State}");
    }
}
