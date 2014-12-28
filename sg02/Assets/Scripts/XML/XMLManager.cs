using UnityEngine;
using System.Collections;

public static class XMLManager
{
    public static XMLLoader<XMLDataBattle> Battle;
    public static XMLLoader<XMLDataCity> City;
    public static XMLLoader<XMLDataForce> Force;
    public static XMLLoader<XMLDataGenerals> Generals;
    public static XMLLoader<XMLDataKings> Kings;
    public static XMLLoader<XMLDataLanguage> Language;
    public static XMLLoader<XMLDataMagic> Magic;
    public static XMLLoader<XMLDataMenuItem> MenuItem;
    public static XMLLoader<XMLDataThings> Things;
    public static XMLLoader<XMLDataTimes> Times;
    public static XMLLoader<XMLDataWiseSkill> WiseSkill;

    public static XMLLoader<XMLDataAnimations> Animations;

    public static XMLLoader<XMLDataPathInfo> PathInfo;
    public static XMLLoader<XMLDataCityPoints> CityPoints;

    public static XMLLoader<XMLDataLuaControlView> LuaControlView;
    public static XMLLoader<XMLDataLuaScripts> LuaScripts;

    public static XMLLoader<XMLDataResourcePath> ResourcePath;

    public static void LoadConfigs()
	{
        Battle = new XMLLoader<XMLDataBattle>(XMLConfigPath.Battle);
        City = new XMLLoader<XMLDataCity>(XMLConfigPath.City);
        Force = new XMLLoader<XMLDataForce>(XMLConfigPath.Force);
        Generals = new XMLLoader<XMLDataGenerals>(XMLConfigPath.Generals);
        Kings = new XMLLoader<XMLDataKings>(XMLConfigPath.Kings);
        Language = new XMLLoader<XMLDataLanguage>(XMLConfigPath.Language, "Name");
        Magic = new XMLLoader<XMLDataMagic>(XMLConfigPath.Magic);
        MenuItem = new XMLLoader<XMLDataMenuItem>(XMLConfigPath.MenuItem);
        Things = new XMLLoader<XMLDataThings>(XMLConfigPath.Things);
        Times = new XMLLoader<XMLDataTimes>(XMLConfigPath.Times);
        WiseSkill = new XMLLoader<XMLDataWiseSkill>(XMLConfigPath.WiseSkill);

        Animations = new XMLLoader<XMLDataAnimations>(XMLConfigPath.Animations);

        PathInfo = new XMLLoader<XMLDataPathInfo>(XMLConfigPath.PathInfo);
        CityPoints = new XMLLoader<XMLDataCityPoints>(XMLConfigPath.CityPoints);

        LuaControlView = new XMLLoader<XMLDataLuaControlView>(XMLConfigPath.LuaControlView, "Name");
        LuaScripts = new XMLLoader<XMLDataLuaScripts>(XMLConfigPath.LuaScripts, "Path");

        ResourcePath = new XMLLoader<XMLDataResourcePath>(XMLConfigPath.ResourcePath, "Name");
	}
}
