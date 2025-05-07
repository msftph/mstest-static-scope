using MstestStaticScope.Shared;

namespace MstestStaticScope.One.Tests;

[TestClass]
[DoNotParallelize]
public sealed class OneOtherTests
{
    [TestMethod]
    public void TestOneOtherA()
    {
        var methodName = nameof(TestOneOtherA);
        Console.WriteLine($"{DateTime.UtcNow} - Before {methodName}: {StaticClass.State}");
        StaticClass.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {methodName}: {StaticClass.State}");
    }

    [TestMethod]
    public void TestOneOtherB()
    {
        var methodName = nameof(TestOneOtherB);
        Console.WriteLine($"{DateTime.UtcNow} - Before {methodName}: {StaticClass.State}");
        StaticClass.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {methodName}: {StaticClass.State}");
    }
}
