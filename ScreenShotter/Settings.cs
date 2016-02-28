using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;

public class Settings : ApplicationSettingsBase
{
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("")]
    public string path
    {
        get { return (string)this["path"]; }
        set { this["path"] = (string)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("Png")]
    public ImageFormat siFormat
    {
        get { return (ImageFormat)this["siFormat"]; }
        set { this["siFormat"] = (ImageFormat)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("90")]
    public long jpgQuality
    {
        get { return (long)this["jpgQuality"]; }
        set { this["jpgQuality"] = (long)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("")]
    public string LastPath
    {
        get { return (string)this["LastPath"]; }
        set { this["LastPath"] = (string)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("True")]
    public bool TrayShow
    {
        get { return (bool)this["TrayShow"]; }
        set { this["TrayShow"] = (bool)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("True")]
    public bool Tooltips
    {
        get { return (bool)this["Tooltips"]; }
        set { this["Tooltips"] = (bool)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("False")]
    public bool ConsoleButton
    {
        get { return (bool)this["ConsoleButton"]; }
        set { this["ConsoleButton"] = (bool)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("True")]
    public bool TrayButton
    {
        get { return (bool)this["TrayButton"]; }
        set { this["TrayButton"] = (bool)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("True")]
    public bool ExitOnX
    {
        get { return (bool)this["ExitOnX"]; }
        set { this["ExitOnX"] = (bool)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("en")]
    public string lang
    {
        get { return (string)this["lang"]; }
        set { this["lang"] = (string)value; }
    }
    [UserScopedSetting()]
    [global::System.Configuration.SettingsProviderAttribute(typeof(PortableSettingsProvider))]
    [DefaultSettingValue("true")]
    public bool firstrun
    {
        get { return (bool)this["firstrun"]; }
        set { this["firstrun"] = (bool)value; }
    }
}