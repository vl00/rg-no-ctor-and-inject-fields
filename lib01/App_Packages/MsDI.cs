namespace Common;

public static class MsDIExtension
{        
    public static T GetService<T>(this IServiceProvider services, string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        var ax = services.GetService<T>();
        return ax;
    }        
}