using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{

    private Dictionary<int, KingInfo> m_listKings;
    public Dictionary<int, KingInfo> Kings { get { return m_listKings; } }

    private Dictionary<int, CityInfo> m_listCitys;
    public Dictionary<int, CityInfo> Citys { get { return m_listCitys; } }

    private Dictionary<int, GeneralInfo> m_listGenerals;
    public Dictionary<int, GeneralInfo> Generals { get { return m_listGenerals; } }


    public void InitDataManager()
    {
        InitKingsInfo();
        InitCitysInfo();
        InitGeneralsInfo();
    }

    public void InitKingsInfo()
    {
        m_listKings = new Dictionary<int, KingInfo>();

        IEnumerator enumerator = XMLManager.Kings.Data.Keys.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int ID = (int)enumerator.Current;
            KingInfo info = new KingInfo(ID);
            Kings.Add(ID, info);
        }
    }

    public KingInfo GetKingInfo(int id)
    {
        if (Kings.ContainsKey(id))
        {
            return Kings[id];
        }

        return null;
    }

    public void SetKingInfo(int id, KingInfo info)
    {
        if (Kings.ContainsKey(id))
        {
            Kings[id] = info;
        }
        else
        {
            Kings.Add(id, info);
        }
    }

    public void InitCitysInfo()
    {
        m_listCitys = new Dictionary<int, CityInfo>();

        IEnumerator enumerator = XMLManager.City.Data.Keys.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int id = (int)enumerator.Current;
            CityInfo info = new CityInfo(id);
            Citys.Add(id, info);
        }
    }

    public CityInfo GetCityInfo(int id)
    {
        if (Citys.ContainsKey(id))
        {
            return Citys[id];
        }

        return null;
    }

    public void SetCityInfo(int id, CityInfo info)
    {
        if (Citys.ContainsKey(id))
        {
            Citys[id] = info;
        }
        else
        {
            Citys.Add(id, info);
        }
    }

    public void InitGeneralsInfo()
    {
        m_listGenerals = new Dictionary<int, GeneralInfo>();

        IEnumerator enumerator = XMLManager.Generals.Data.Keys.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int id = (int)enumerator.Current;
            GeneralInfo info = new GeneralInfo(id);
            Generals.Add(id, info);
        }
    }

    public GeneralInfo GetGeneralInfo(int id)
    {
        if (Generals.ContainsKey(id))
        {
            return Generals[id];
        }

        return null;
    }

    public void SetGeneralInfo(int id, GeneralInfo info)
    {
        if (Generals.ContainsKey(id))
        {
            Generals[id] = info;
        }
        else
        {
            Generals.Add(id, info);
        }
    }

    public static int FindKingID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        string generalName = Utility.GeneralName(name);

        IEnumerator enumerator = XMLManager.Kings.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataKings data = (XMLDataKings)enumerator.Current;
            if (Utility.GeneralName(data.Name) == generalName)
            {
                return data.ID;
            }
        }

        Debugging.LogError("Function:FindKingID; name = " + name);
        return -1;
    }

    public static int FindCityID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        string cityName = Utility.GeneralName(name);

        IEnumerator enumerator = XMLManager.City.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataCity data = (XMLDataCity)enumerator.Current;
            if (Utility.GeneralName(data.Name) == cityName)
            {
                return data.ID;
            }
        }

        Debugging.LogError("Function:FindCityID; name = " + name);
        return -1;
    }

    public static int FindGeneralID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        string generalName = Utility.GeneralName(name);

        IEnumerator enumerator = XMLManager.Generals.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataGenerals data = (XMLDataGenerals)enumerator.Current;
            if (Utility.GeneralName(data.Name) == generalName)
            {
                return data.ID;
            }
        }

        Debugging.LogError("Function:FindGeneralID; name = " + name);
        return -1;
    }

    public static int FindBattleID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        int battle = 0;
        string[] battleArr = name.Split(' ');
        for (int i=0; i < battleArr.Length; i++)
        {
            IEnumerator enumerator = XMLManager.Battle.Data.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XMLDataBattle data = (XMLDataBattle)enumerator.Current;
                if (data.ShortName == battleArr[i])
                {
                    battle |= data.ID;
                }
            }
        }
        

        if (battle == 0)
            Debugging.LogError("Function:FindBattleID; name = " + name);

        return battle;
    }

    public static int FindForceID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        int force = 0;
        string[] forceArr = name.Split(' ');

        for (int i = 0; i < forceArr.Length; i++)
        {
            IEnumerator enumerator = XMLManager.Force.Data.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                XMLDataForce data = (XMLDataForce)enumerator.Current;
                if (data.ShortName == forceArr[i])
                {
                    force |= data.ID;
                }
            }
        }
        
        if (force == 0)
        {
            Debugging.LogError("Function:FindForceID; name = " + name);
        }
        
        return force;
    }

    public static int FindSkillID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        IEnumerator enumerator = XMLManager.Magic.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataMagic data = (XMLDataMagic)enumerator.Current;
            if (data.Name == name)
            {
                return data.ID;
            }
        }

        Debugging.LogError("Function:FindMagicID; name = " + name);
        return -1;
    }

    public static int FindWiseSkillID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        IEnumerator enumerator = XMLManager.WiseSkill.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataWiseSkill data = (XMLDataWiseSkill)enumerator.Current;
            if (data.FullName == name)
            {
                return data.ID;
            }
        }

        Debugging.LogError("Function:FindWiseSkillID; name = " + name);
        return -1;
    }

    public static int FindThingsID(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        IEnumerator enumerator = XMLManager.Things.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataThings data = (XMLDataThings)enumerator.Current;
            if (data.Name == name)
            {
                return data.ID;
            }
        }

        Debugging.LogError("Function:FindThingsID; name = " + name);
        return -1;
    }
}
