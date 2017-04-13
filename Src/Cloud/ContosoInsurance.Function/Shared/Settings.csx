using Microsoft.Azure;

public static class Settings
{
    public static readonly string ApplicationInsightsInstrumentationKey = CloudConfigurationManager.GetSetting("MS_ApplicationInsightsInstrumentationKey");
    public static readonly string FunctionsExtensionVersion = CloudConfigurationManager.GetSetting("FUNCTIONS_EXTENSION_VERSION");
    public static readonly string NotificationHubName = CloudConfigurationManager.GetSetting("MS_NotificationHubName");
    public static readonly string NotificationHubConnection = CloudConfigurationManager.GetSetting("MS_NotificationHubConnectionString");
}