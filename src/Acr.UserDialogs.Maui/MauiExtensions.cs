namespace Acr.UserDialogs;


public static class MauiExtensions
{
    public static MauiAppBuilder UseUserDialogs(this MauiAppBuilder builder)
    {
        #if ANDROID
        UserDialogs.Init(() => Platform.CurrentActivity);
        builder.Services.AddSingleton(UserDialogs.Instance);
        
        #elif IOS || MACCATALYST
        builder.Services.AddSingleton(UserDialogs.Instance);
        
        #else
        throw new ApplicationException("This plugin only works with .NET 8.0 for Android, iOS, and Mac Catalyst.  You are calling this, but it isn't from one of those targets!");
        
        #endif
        
        return builder;
    }
}
