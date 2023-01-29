using Common;
using Microsoft.Extensions.Options;
using static Common.DInjectInit_ext;

namespace lib02;

public partial class Class2 : lib01.Class1
{

}

public partial class Class3 : Class2
{
    [rg.DInject(IsLazy = true)] public static IHostApplicationLifetime applicationLifetime => GetStaticLazyValueByrg<IHostApplicationLifetime>();

    [rg.DInject(IsLazy = true)] public IOptions<object> options => this.GetLazyValueByrg<IOptions<object>>();
}
