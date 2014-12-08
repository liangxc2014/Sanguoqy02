using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralInfo 
{
    public int State { get; set; } //-1:不登场 0 :在野 1:登庸
    public int ID { get; set; }
    public string Name { get; set; }
    public int KingID { get; set; }
    public int CityID { get; set; }
    public int PrisonerID { get; set; }
    public int Loyalty { get; set; }
    public int[] Skill { get; set; }
    public int[] SkillLevel { get; set; }
    public int[] WiseSkill { get; set; }
    public int[] WiseSkillLevel { get; set; }
    public int Title { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int BaseHP { get; set; }
    public int CurHP { get; set; }
    public int BaseMP { get; set; }
    public int CurMP { get; set; }
    public int SoldierMax { get; set; }
    public int SoldierCur { get; set; }
    public int KnightMax { get; set; }
    public int KnightCur { get; set; }
    public int ForceArray { get; set; }
    public int UseForce { get; set; }
    public int BattleArray { get; set; }
    public int UseBattle { get; set; }
    public int Weapon { get; set; }
    public int Horse { get; set; }
    public int Thing { get; set; }
    
    public int Escape { get; set; }

    public GeneralInfo()
    {

    }

    public GeneralInfo(int id)
    {
        ID = id;

        XMLDataGenerals data = XMLManager.Generals.GetInfoById(ID);

        string stateValue = data.TimesState[GamePublic.Instance.CurrentTimes];
        switch (stateValue)
        {
            case "":
                State = -1;
                break;
            case "野":
                State = 0;
                break;
            case "登":
                State = 1;
                break;
            default:
                Debugging.LogError("Function:GeneralInfo; stateValue = " + stateValue);
                break;
        }

        Name = data.Name;
        CityID = DataManager.FindCityID(data.Times[GamePublic.Instance.CurrentTimes]);
        if (CityID > 0 && State == 1)
        {
            KingID = GamePublic.Instance.DataManager.GetCityInfo(CityID).KingID;
        }
        else
        {
            KingID = 0;
        }
        
        PrisonerID = 0;
        Loyalty = data.Loyalty;

        GetSkills(data.Skill, data.SkillLevel);
        GetWiseSkills(data.WiseSkill, data.WiseSkillLevel);

        Title = 0;
        Strength = data.Strength;
        Intellect = data.Intellect;
        Experience = 200;
        Level = 1;
        BaseHP = data.BaseHP;
        CurHP = BaseHP;
        BaseMP = data.BaseMP;
        CurMP = BaseMP;
        SoldierMax = 10;
        SoldierCur = 10;
        KnightMax = 0;
        KnightCur = 0;
        ForceArray = DataManager.FindForceID(data.Force);
        UseForce = DataManager.FindForceID(data.UseForce);
        BattleArray = DataManager.FindBattleID(data.BattleArray);
        Weapon = DataManager.FindThingsID(data.Weapon);
        Horse = DataManager.FindThingsID(data.Horse);
        Thing = DataManager.FindThingsID(data.Thing);
        Escape = 0;
    }

    private void GetSkills(string[] skillsName, int[] skillsLevel)
    {
        List<int> listSkills = new List<int>();
        List<int> listSkillsLevel = new List<int>();
        for (int i = 0; i < skillsName.Length; i++)
        {
            if (string.IsNullOrEmpty(skillsName[i]) == false)
            {
                int skillID = DataManager.FindSkillID(skillsName[i]);
                if (skillID > 0)
                {
                    listSkills.Add(skillID);
                    if (skillsLevel[i] <= 0)
                    {
                        listSkillsLevel.Add(1);
                        Debugging.LogError("Function:GeneralInfo; skillsLevel :" + skillsLevel[i]);
                    }
                    else
                    {
                        listSkillsLevel.Add(skillsLevel[i]);
                    }
                }
                else
                {
                    Debugging.LogError("Function:GeneralInfo; skill name:" + skillsName[i]);
                }
            }
        }

        Skill = listSkills.ToArray();
        SkillLevel = listSkillsLevel.ToArray();
    }

    private void GetWiseSkills(string[] wiseName, int[] wiseLevel)
    {
        List<int> listWise = new List<int>();
        List<int> listWiseLevel = new List<int>();
        for (int i = 0; i < wiseName.Length; i++)
        {
            if (string.IsNullOrEmpty(wiseName[i]) == false)
            {
                int wiseID = DataManager.FindWiseSkillID(wiseName[i]);
                if (wiseID > 0)
                {
                    listWise.Add(wiseID);
                    if (wiseLevel[i] <= 0)
                    {
                        listWiseLevel.Add(1);
                        Debugging.LogError("Function:GeneralInfo; skillsLevel :" + wiseLevel[i]);
                    }
                    else
                    {
                        listWiseLevel.Add(wiseLevel[i]);
                    }
                }
                else
                {
                    Debugging.LogError("Function:GeneralInfo; skill name:" + wiseName[i]);
                }
            }
        }

        WiseSkill = listWise.ToArray();
        WiseSkillLevel = listWiseLevel.ToArray();
    }
}
