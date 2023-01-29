using Common;
using System.Diagnostics;
using static Common.DInjectInit_ext;

namespace lib01;

public partial class Class1
{
    // 支持公有/私有,实例/静态,字段/属性注入, 甚至支持readonly和lazy
    
    [rg.DInject] readonly IConfiguration _config;

    [rg.DInject] static IServiceProvider _sp1;

    [rg.DInject("log01", IsLazy = true)] 
    ILogger<IConfiguration> log1 => this.GetLazyValueByrg<ILogger<IConfiguration>>();

    [rg.DInject("log02", IsLazy = true)] 
    public ILogger<Class1> log2 => this.GetLazyValueByrg<ILogger<Class1>>();

    [rg.DInject(IsLazy = true)] 
    public static IServiceProvider _sp2 => GetStaticLazyValueByrg<IServiceProvider>();

    [rg.DInject(IsLazy = true)] 
    public Class4 Class4 => this.GetLazyValueByrg<Class4>();

    // 该方法算是分部的构造函数..
    internal void DInject_init_ThisNameCanbeScribblable()
    {
        Console.WriteLine($"{this.GetType().FullName} di-inject init");
        Debug.WriteLine($"{this.GetType().FullName} di-inject init");
    }
}

public partial class Class4
{
    [rg.DInject(IsLazy = true)] public Class1 Class1 => this.GetLazyValueByrg<Class1>();

    void DInject_init_444444444444444444444444444444444444444()
    {
        Console.WriteLine($"{this.GetType().FullName} di-inject init");
        Debug.WriteLine($"{this.GetType().FullName} di-inject init");
    }
}
