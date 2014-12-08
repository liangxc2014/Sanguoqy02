using System;
using LuaInterface;

public class WrapDataManager
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("InitDataManager", InitDataManager),
		new LuaMethod("InitKingsInfo", InitKingsInfo),
		new LuaMethod("GetKingInfo", GetKingInfo),
		new LuaMethod("SetKingInfo", SetKingInfo),
		new LuaMethod("InitCitysInfo", InitCitysInfo),
		new LuaMethod("GetCityInfo", GetCityInfo),
		new LuaMethod("SetCityInfo", SetCityInfo),
		new LuaMethod("InitGeneralsInfo", InitGeneralsInfo),
		new LuaMethod("GetGeneralInfo", GetGeneralInfo),
		new LuaMethod("SetGeneralInfo", SetGeneralInfo),
		new LuaMethod("FindKingID", FindKingID),
		new LuaMethod("FindCityID", FindCityID),
		new LuaMethod("FindGeneralID", FindGeneralID),
		new LuaMethod("FindBattleID", FindBattleID),
		new LuaMethod("FindForceID", FindForceID),
		new LuaMethod("FindSkillID", FindSkillID),
		new LuaMethod("FindWiseSkillID", FindWiseSkillID),
		new LuaMethod("FindThingsID", FindThingsID),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Kings", get_Kings, null),
		new LuaField("Citys", get_Citys, null),
		new LuaField("Generals", get_Generals, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			DataManager obj = new DataManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DataManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(DataManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "DataManager", typeof(DataManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Kings(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Kings");
		}

		DataManager obj = (DataManager)o;
		LuaScriptMgr.PushObject(L, obj.Kings);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Citys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Citys");
		}

		DataManager obj = (DataManager)o;
		LuaScriptMgr.PushObject(L, obj.Citys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Generals(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Generals");
		}

		DataManager obj = (DataManager)o;
		LuaScriptMgr.PushObject(L, obj.Generals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitDataManager(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		obj.InitDataManager();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitKingsInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		obj.InitKingsInfo();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKingInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		KingInfo o = obj.GetKingInfo(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetKingInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		KingInfo arg1 = LuaScriptMgr.GetNetObject<KingInfo>(L, 3);
		obj.SetKingInfo(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitCitysInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		obj.InitCitysInfo();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCityInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		CityInfo o = obj.GetCityInfo(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCityInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		CityInfo arg1 = LuaScriptMgr.GetNetObject<CityInfo>(L, 3);
		obj.SetCityInfo(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitGeneralsInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		obj.InitGeneralsInfo();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGeneralInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		GeneralInfo o = obj.GetGeneralInfo(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetGeneralInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		DataManager obj = LuaScriptMgr.GetNetObject<DataManager>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		GeneralInfo arg1 = LuaScriptMgr.GetNetObject<GeneralInfo>(L, 3);
		obj.SetGeneralInfo(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindKingID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindKingID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindCityID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindCityID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindGeneralID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindGeneralID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindBattleID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindBattleID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindForceID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindForceID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSkillID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindSkillID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindWiseSkillID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindWiseSkillID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindThingsID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = DataManager.FindThingsID(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

