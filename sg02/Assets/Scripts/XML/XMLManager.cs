using UnityEngine;
using System.Collections;

public static class XMLManager
{
    public static XMLLoader<XMLDataArms> Arms;
    public static XMLLoader<XMLDataBuff> Buff;
    public static XMLLoader<XMLDataCity> City;
    public static XMLLoader<XMLDataFormations> Formations;
    public static XMLLoader<XMLDataGenerals> Generals;
    public static XMLLoader<XMLDataKings> Kings;
    public static XMLLoader<XMLDataMagic> Magic;
    public static XMLLoader<XMLDataObjects> Objects;
    public static XMLLoader<XMLDataPeriod> Period;

    public static XMLLoader<XMLDataPathInfo> PathInfo;
    public static XMLLoader<XMLDataCityPoints> CityPoints;

    public static XMLLoader<XMLDataLuaControlView> LuaControlView;
    public static XMLLoader<XMLDataLuaScripts> LuaScripts;

    public static void LoadConfigs()
	{
        Kings = new XMLLoader<XMLDataKings>(XMLConfigPath.Kings);
        Arms = new XMLLoader<XMLDataArms>(XMLConfigPath.Arms);
        Buff = new XMLLoader<XMLDataBuff>(XMLConfigPath.Buff);
        City = new XMLLoader<XMLDataCity>(XMLConfigPath.City);
        Formations = new XMLLoader<XMLDataFormations>(XMLConfigPath.Formations);
        Generals = new XMLLoader<XMLDataGenerals>(XMLConfigPath.Generals);
        Magic = new XMLLoader<XMLDataMagic>(XMLConfigPath.Magic);
        Objects = new XMLLoader<XMLDataObjects>(XMLConfigPath.Objects);
        Period = new XMLLoader<XMLDataPeriod>(XMLConfigPath.Period);

        PathInfo = new XMLLoader<XMLDataPathInfo>(XMLConfigPath.PathInfo);
        CityPoints = new XMLLoader<XMLDataCityPoints>(XMLConfigPath.CityPoints);

        LuaControlView = new XMLLoader<XMLDataLuaControlView>(XMLConfigPath.LuaControlView, "Name");
        LuaScripts = new XMLLoader<XMLDataLuaScripts>(XMLConfigPath.LuaScripts, "Path");
	}
}
