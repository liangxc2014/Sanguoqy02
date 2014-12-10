using System;
using UnityEngine;
using LuaInterface;

public class WrapGeneralInfo
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetFace", SetFace),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("State", get_State, set_State),
		new LuaField("ID", get_ID, set_ID),
		new LuaField("Name", get_Name, set_Name),
		new LuaField("Face", get_Face, set_Face),
		new LuaField("KingID", get_KingID, set_KingID),
		new LuaField("CityID", get_CityID, set_CityID),
		new LuaField("PrisonerID", get_PrisonerID, set_PrisonerID),
		new LuaField("Loyalty", get_Loyalty, set_Loyalty),
		new LuaField("Skill", get_Skill, set_Skill),
		new LuaField("SkillLevel", get_SkillLevel, set_SkillLevel),
		new LuaField("WiseSkill", get_WiseSkill, set_WiseSkill),
		new LuaField("WiseSkillLevel", get_WiseSkillLevel, set_WiseSkillLevel),
		new LuaField("Title", get_Title, set_Title),
		new LuaField("Strength", get_Strength, set_Strength),
		new LuaField("Intellect", get_Intellect, set_Intellect),
		new LuaField("Experience", get_Experience, set_Experience),
		new LuaField("Level", get_Level, set_Level),
		new LuaField("BaseHP", get_BaseHP, set_BaseHP),
		new LuaField("CurHP", get_CurHP, set_CurHP),
		new LuaField("BaseMP", get_BaseMP, set_BaseMP),
		new LuaField("CurMP", get_CurMP, set_CurMP),
		new LuaField("SoldierMax", get_SoldierMax, set_SoldierMax),
		new LuaField("SoldierCur", get_SoldierCur, set_SoldierCur),
		new LuaField("KnightMax", get_KnightMax, set_KnightMax),
		new LuaField("KnightCur", get_KnightCur, set_KnightCur),
		new LuaField("ForceArray", get_ForceArray, set_ForceArray),
		new LuaField("UseForce", get_UseForce, set_UseForce),
		new LuaField("BattleArray", get_BattleArray, set_BattleArray),
		new LuaField("UseBattle", get_UseBattle, set_UseBattle),
		new LuaField("Weapon", get_Weapon, set_Weapon),
		new LuaField("Horse", get_Horse, set_Horse),
		new LuaField("Thing", get_Thing, set_Thing),
		new LuaField("Escape", get_Escape, set_Escape),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GeneralInfo obj = new GeneralInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			GeneralInfo obj = new GeneralInfo(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GeneralInfo.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(GeneralInfo));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "GeneralInfo", typeof(GeneralInfo), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_State(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name State");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.State);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.ID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Face(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Face");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Face);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KingID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name KingID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.KingID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CityID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CityID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.CityID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PrisonerID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name PrisonerID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.PrisonerID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Loyalty(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Loyalty");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Loyalty);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Skill(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Skill");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.PushArray(L, obj.Skill);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SkillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SkillLevel");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.PushArray(L, obj.SkillLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WiseSkill(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WiseSkill");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.PushArray(L, obj.WiseSkill);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WiseSkillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WiseSkillLevel");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.PushArray(L, obj.WiseSkillLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Title(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Title");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Title);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Strength(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Strength");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Strength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Intellect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Intellect");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Intellect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Experience(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Experience");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Experience);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Level");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Level);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BaseHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BaseHP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.BaseHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurHP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.CurHP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BaseMP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BaseMP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.BaseMP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurMP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurMP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.CurMP);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SoldierMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SoldierMax");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.SoldierMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SoldierCur(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SoldierCur");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.SoldierCur);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KnightMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name KnightMax");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.KnightMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KnightCur(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name KnightCur");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.KnightCur);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ForceArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ForceArray");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.ForceArray);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UseForce");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.UseForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BattleArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BattleArray");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.BattleArray);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UseBattle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UseBattle");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.UseBattle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Weapon(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Weapon");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Weapon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Horse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Horse");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Horse);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Thing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Thing");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Thing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Escape(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Escape");
		}

		GeneralInfo obj = (GeneralInfo)o;
		LuaScriptMgr.Push(L, obj.Escape);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_State(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name State");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.State = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.ID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Face(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Face");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Face = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_KingID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name KingID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.KingID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CityID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CityID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.CityID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PrisonerID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name PrisonerID");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.PrisonerID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Loyalty(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Loyalty");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Loyalty = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Skill(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Skill");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Skill = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SkillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SkillLevel");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.SkillLevel = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WiseSkill(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WiseSkill");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.WiseSkill = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WiseSkillLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WiseSkillLevel");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.WiseSkillLevel = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Title(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Title");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Title = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Strength(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Strength");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Strength = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Intellect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Intellect");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Intellect = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Experience(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Experience");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Experience = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Level(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Level");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Level = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BaseHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BaseHP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.BaseHP = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurHP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurHP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.CurHP = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BaseMP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BaseMP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.BaseMP = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurMP(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurMP");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.CurMP = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SoldierMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SoldierMax");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.SoldierMax = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SoldierCur(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SoldierCur");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.SoldierCur = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_KnightMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name KnightMax");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.KnightMax = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_KnightCur(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name KnightCur");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.KnightCur = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ForceArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ForceArray");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.ForceArray = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UseForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UseForce");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.UseForce = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BattleArray(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BattleArray");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.BattleArray = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UseBattle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UseBattle");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.UseBattle = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Weapon(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Weapon");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Weapon = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Horse(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Horse");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Horse = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Thing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Thing");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Thing = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Escape(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Escape");
		}

		GeneralInfo obj = (GeneralInfo)o;
		obj.Escape = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFace(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GeneralInfo obj = LuaScriptMgr.GetNetObject<GeneralInfo>(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		obj.SetFace(arg0);
		return 0;
	}
}

