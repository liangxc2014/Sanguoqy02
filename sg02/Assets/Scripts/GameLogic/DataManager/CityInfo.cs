using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityInfo
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int KingID { get; set; }
    public int Level { get; set; }
    public int Flag { get; set; }
    public int GeneralMax { get; set; }
    public int Major { get; set; }
    public int Wise { get; set; }
    public int Population { get; set; }
    public int Money { get; set; }
    public int Reservist { get; set; }
    public int ReservistMax { get; set; }
    public int Defense { get; set; }

    private List<int> m_generals;
    public List<int> Generals { get { return m_generals; } }

    private List<int> m_prisons;
    public List<int> Prisons { get { return m_prisons; } }

    private List<int> m_objects;
    public List<int> Objects { get { return m_objects; } }

    public CityInfo()
    {

    }

    public CityInfo(int id)
    {
        ID = id;

        XMLDataCity data = XMLManager.City.GetInfoById(ID);

        Name = data.Name;
        Level = data.Level;
        Flag = data.Flag;
        GeneralMax = data.GeneralMax;
        KingID = DataManager.FindKingID(data.Times[GamePublic.Instance.CurrentTimes]);
        Population = data.Population;
        Money = data.Money;
        Reservist = 0;
        ReservistMax = data.ReservistMax;
        Defense = data.Defense;

        m_generals = new List<int>();
        m_prisons = new List<int>();
        m_objects = new List<int>();
    }

    public void AddGeneral(int generalID)
    {
        GeneralInfo general = GamePublic.Instance.DataManager.GetGeneralInfo(generalID);
        if (general.KingID != KingID)
        {
            Debugging.LogError("Function:AddGeneral; KingID:" + KingID + ", general.KingID:" + general.KingID);
            return;
        }

        if (Generals.Contains(generalID))
        {
            return;
        }

        general.CityID = ID;
        Generals.Add(generalID);
    }

    public void RemoveGeneral(int generalID)
    {
        if (m_generals.Contains(generalID) == false)
        {
            return;
        }

        m_generals.Remove(generalID);

        GeneralInfo general = GamePublic.Instance.DataManager.GetGeneralInfo(generalID);
        general.CityID = 0;
    }

    public void AddPrison(int generalID)
    {
        if (Prisons.Contains(generalID))
        {
            return;
        }

        Prisons.Add(generalID);

        GeneralInfo general = GamePublic.Instance.DataManager.GetGeneralInfo(generalID);
        general.CityID = ID;
    }

    public void RemovePrison(int generalID)
    {
        if (Prisons.Contains(generalID) == false)
        {
            return;
        }

        Prisons.Remove(generalID);

        GeneralInfo general = GamePublic.Instance.DataManager.GetGeneralInfo(generalID);
        general.CityID = 0;
    }

    public void AddObject(int objID)
    {
        Objects.Add(objID);
    }

    public void RemoveObject(int objID)
    {
        Objects.Remove(objID);
    }

    public void FindMajor()
    {

    }
}
