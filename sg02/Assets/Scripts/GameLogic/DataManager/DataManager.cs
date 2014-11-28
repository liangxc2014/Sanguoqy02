using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager
{

    private Dictionary<int, KingsInfo> m_listKings;
    public Dictionary<int, KingsInfo> Kings { get { return m_listKings; } }

    private Dictionary<int, CityInfo> m_listCitys;
    public Dictionary<int, CityInfo> Citys { get { return m_listCitys; } }

    private Dictionary<int, GeneralInfo> m_listGenerals;
    public Dictionary<int, GeneralInfo> Generals { get { return m_listGenerals; } }

    public DataManager()
    {
        m_listKings = new Dictionary<int, KingsInfo>();
        m_listCitys = new Dictionary<int, CityInfo>();
        m_listGenerals = new Dictionary<int, GeneralInfo>();
    }

    public KingsInfo GetKingInfo(int id)
    {
        if (Kings.ContainsKey(id))
        {
            return Kings[id];
        }

        return null;
    }

    public void SetKingInfo(int id, KingsInfo info)
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

    public int FindKingID(string name)
    {
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

    public int FindCityID(string name)
    {
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

    public int FindGeneralID(string name)
    {
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
}
