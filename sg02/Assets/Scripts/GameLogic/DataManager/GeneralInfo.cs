using UnityEngine;
using System.Collections;

public class GeneralInfo 
{
    public int State { get; set; } //-1:不登场 0 :在野 1:登庸
    public int ID { get; set; }
    public string Name { get; set; }
    public int KingID { get; set; }
    public int CityID { get; set; }
    public int PrisonerID { get; set; }
    public int Loyalty { get; set; }
    public int[] Magic { get; set; }
    public int Title { get; set; }
    public int Things { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int HPMax { get; set; }
    public int HPCur { get; set; }
    public int MPMax { get; set; }
    public int MPCur { get; set; }
    public int SoldierMax { get; set; }
    public int SoldierCur { get; set; }
    public int KnightMax { get; set; }
    public int KnightCur { get; set; }
    public int Force { get; set; }
    public int ForceUse { get; set; }
    public int Battle { get; set; }
    public int BattleUse { get; set; }
    public int Escape { get; set; }

    public GeneralInfo()
    {

    }

    public GeneralInfo(int id)
    {
        ID = id;

        XMLDataGenerals data = XMLManager.Generals.GetInfoById(ID);

        string stateValue = data.TimesState[GamePublic.Instance.CurrentTimes];


        Name = data.Name;
        CityID = DataManager.FindCityID(data.Times[GamePublic.Instance.CurrentTimes]);
        KingID = GamePublic.Instance.DataManager.GetCityInfo(CityID).KingID;
        PrisonerID = -1;
        Loyalty = 90;
        //Magic = data.Magic;
    }
}
