// Created by BladeMight in 02.12.2016-0:28
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
namespace ScreenShotter
{
public class Configs
{
	public static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShotter.ini");
	public Configs()//Initializes settings, if some of elements or settinhs file, not exists it creates them with default value
	{
		if (!File.Exists(filePath)) { //Create an UTF-16 configuration file
			File.WriteAllText(filePath, "!Unicode(✔), ScreenShotter settings file", Encoding.Unicode);
		}
		int it = 0;      //int temp
		bool bt = false; //bool temp
		//Main section
		if (String.IsNullOrEmpty(this.Read("Main", "Path")))
			this.Write("Main", "Path", ".\\");
		if (String.IsNullOrEmpty(this.Read("Main", "Format")))
		{
			this.Write("Main", "Format", "png");
			Console.WriteLine(this.Read("Main", "Format"));
		}
		if (!Int32.TryParse(this.Read("Main", "jpgQuality"), out it))
			this.Write("Main", "jpgQuality", "90"); 
		if (String.IsNullOrEmpty(this.Read("Main", "LastPath")))
			this.Write("Main", "LastPath", "");
		if (!Boolean.TryParse(this.Read("Main", "TrayShow"), out bt))
			this.Write("Main", "TrayShow", "True");
		if (!Boolean.TryParse(this.Read("Main", "Tooltips"), out bt))
			this.Write("Main", "Tooltips", "True");
		if (!Boolean.TryParse(this.Read("Main", "TrayButton"), out bt))
			this.Write("Main", "TrayButton", "True");
		if (!Boolean.TryParse(this.Read("Main", "ConsoleButton"), out bt))
			this.Write("Main", "ConsoleButton", "False");
		if (!Boolean.TryParse(this.Read("Main", "ExitOnX"), out bt))
			this.Write("Main", "ExitOnX", "True");
		if (String.IsNullOrEmpty(this.Read("Main", "lang")))
			this.Write("Main", "lang", "en");
	}
	public void Write(string section, string key, string value) //Writes "value" to "key" in "section"
	{
		WritePrivateProfileString(section, key, value, filePath);
	}
	public string Read(string section, string key) //Returns "key" value in "section" as string
	{
		var SB = new StringBuilder(255);
		int i = GetPrivateProfileString(section, key, "", SB, 255, filePath);
		return SB.ToString();
	}
	public int ReadInt(string section, string key) //Returns "key" value in "section" as int
	{
		var SB = new StringBuilder(255);
		int i = GetPrivateProfileString(section, key, "", SB, 255, filePath);
		return Int32.Parse(SB.ToString());
	}
	public bool ReadBool(string section, string key) //Returns "key" value in "section" as bool
	{
		var SB = new StringBuilder(255);
		int i = GetPrivateProfileString(section, key, "", SB, 255, filePath);
		return Boolean.Parse(SB.ToString().ToLower());
	}
	#region Dll imports
	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	static extern long WritePrivateProfileString(string section,
		string key, string val, string filePath);

	[DllImport("kernel32", CharSet = CharSet.Unicode)]
	static extern int GetPrivateProfileString(string section,
		string key, string def, StringBuilder retVal, int size, string filePath);
	#endregion
}
}