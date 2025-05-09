using System.Reflection;
using System.Runtime.Loader;
using MstestStaticScope.Shared;

namespace MstestStaticScope.Isolated.Tests;

[TestClass]
[DoNotParallelize]
public sealed class OneIsolatedTests
{
    private static AssemblyLoadContext assemblyLoadContext = null;
    private static Assembly isolatedAssembly = null;
    private static PropertyInfo staticStateProperty = null;
    private static string State 
    {
        get
        {
            return staticStateProperty.GetValue(null) as string;
        }
        set
        {
            staticStateProperty.SetValue(null, value);
        }
    }
    
    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        // make sure the assembly load context is collectable
        assemblyLoadContext = new AssemblyLoadContext(nameof(StaticClass), true);

        // Load the assembly into the isolated context
        isolatedAssembly = assemblyLoadContext.LoadFromAssemblyPath(typeof(StaticClass).Assembly.Location);

        // create the method info for the static state
        var staticClassType = isolatedAssembly.GetType(typeof(StaticClass).FullName);
        staticStateProperty = staticClassType
            .GetProperty(nameof(StaticClass.State), BindingFlags.Public | BindingFlags.Static);
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // unload the assembly load context to free up resources
        assemblyLoadContext.Unload();
    }

    [TestMethod]
    public void TestOneIsolatedA()
    {
        var methodName = nameof(TestOneIsolatedA);
        Console.WriteLine($"{DateTime.UtcNow} - Before {typeof(OneIsolatedTests).FullName}.{methodName}: {OneIsolatedTests.State}");
        OneIsolatedTests.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {typeof(OneIsolatedTests).FullName}.{methodName}: {OneIsolatedTests.State}");
    }

    [TestMethod]
    public void TestOneIsolatedB()
    {
        var methodName = nameof(TestOneIsolatedB);
        Console.WriteLine($"{DateTime.UtcNow} - Before {typeof(OneIsolatedTests).FullName}.{methodName}: {OneIsolatedTests.State}");
        OneIsolatedTests.State = methodName;
        Console.WriteLine($"{DateTime.UtcNow} - After {typeof(OneIsolatedTests).FullName}.{methodName}: {OneIsolatedTests.State}");
    }
}