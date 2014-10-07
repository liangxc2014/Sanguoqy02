using UnityEngine;
using System.Collections;

public static class XMLManager
{
    public static XMLLoader<XMLDataArms> Arms;
    public static XMLLoader<XMLDataBuff> Buff;
    public static XMLLoader<XMLDataCity> City;
    public static XMLLoader<XMLDataFormations> Formations;
    public static XMLLoader<XMLDataGenerals> Generals;
    public static XMLLoader<XMLDataMagic> Magic;
    public static XMLLoader<XMLDataObjects> Objects;

    public static void LoadConfigs()
	{
        Arms = new XMLLoader<XMLDataArms>(XMLConfigPath.Arms);
        Buff = new XMLLoader<XMLDataBuff>(XMLConfigPath.Buff);
        City = new XMLLoader<XMLDataCity>(XMLConfigPath.City);
        Formations = new XMLLoader<XMLDataFormations>(XMLConfigPath.Formations);
        Generals = new XMLLoader<XMLDataGenerals>(XMLConfigPath.Generals);
        Magic = new XMLLoader<XMLDataMagic>(XMLConfigPath.Magic);
        Objects = new XMLLoader<XMLDataObjects>(XMLConfigPath.Objects);
	}
}
