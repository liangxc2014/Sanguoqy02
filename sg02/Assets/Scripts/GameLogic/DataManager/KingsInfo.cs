using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KingsInfo
{
    public bool Active { get; set; }

    private int m_ID;
    public int ID { get { return ID; } }

    private int m_generalID;
    public int GeneralID { get { return m_generalID; } }

    private List<CityInfo> m_citys;
    public List<CityInfo> Citys { get { return m_citys; } }

    private List<GeneralInfo> m_generals;
    public List<GeneralInfo> Generals { get { return m_generals; } }

    public KingsInfo(int id)
    {
        m_ID = id;

        m_citys = new List<CityInfo>();
        m_generals = new List<GeneralInfo>();

        XMLDataKings data = XMLManager.Kings.GetInfoById(m_ID);
        
        m_generalID = GamePublic.Instance.DataManager.FindGeneralID(data.Name);

        int currentPeriod = GamePublic.Instance.CurrentPeriod;
        if (data.Period[currentPeriod] == 0)
        {
            Active = false;
        }
        else
        {
            Active = true;
        }
    }
}
