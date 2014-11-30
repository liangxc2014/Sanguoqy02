using System;
using LuaInterface;

public class WrapCityInfo
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddGeneral", AddGeneral),
		new LuaMethod("RemoveGeneral", RemoveGeneral),
		new LuaMethod("AddPrison", AddPrison),
		new LuaMethod("RemovePrison", RemovePrison),
		new LuaMethod("AddObject", AddObject),
		new LuaMethod("RemoveObject", RemoveObject),
		new LuaMethod("FindMajor", FindMajor),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("ID", get_ID, set_ID),
		new LuaField("Name", get_Name, set_Name),
		new LuaField("KingID", get_KingID, set_KingID),
		new LuaField("Level", get_Level, set_Level),
		new LuaField("Flag", get_Flag, set_Flag),
		new LuaField("GeneralMax", get_GeneralMax, set_GeneralMax),
		new LuaField("Major", get_Major, set_Major),
		new LuaField("Wise", get_Wise, set_Wise),
		new LuaField("Population", get_Population, set_Population),
		new LuaField("Money", get_Money, set_Money),
		new LuaField("Reservist", get_Reservist, set_Reservist),
		new LuaField("ReservistMax", get_ReservistMax, set_ReservistMax),
		new LuaField("Defense", get_Defense, set_Defense),
		new LuaField("Generals", get_Generals, null),
		new LuaField("Prisons", get_Prisons, null),
		new LuaField("Objects", get_Objects, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CityInfo obj = new CityInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			CityInfo obj = new CityInfo(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CityInfo.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(CityInfo));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "CityInfo", typeof(CityInfo), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ID");
		}

		CityInfo obj = (CityInfo)o;
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

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Name);
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

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.KingID);
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

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Level);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Flag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Flag");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Flag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GeneralMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GeneralMax");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.GeneralMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Major(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Major");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Major);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Wise(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Wise");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Wise);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Population(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Population");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Population);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Money(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Money");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Money);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Reservist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Reservist");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Reservist);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ReservistMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ReservistMax");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.ReservistMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Defense(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Defense");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.Push(L, obj.Defense);
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

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.PushObject(L, obj.Generals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Prisons(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Prisons");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.PushObject(L, obj.Prisons);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Objects(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Objects");
		}

		CityInfo obj = (CityInfo)o;
		LuaScriptMgr.PushObject(L, obj.Objects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ID");
		}

		CityInfo obj = (CityInfo)o;
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

		CityInfo obj = (CityInfo)o;
		obj.Name = LuaScriptMgr.GetString(L, 3);
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

		CityInfo obj = (CityInfo)o;
		obj.KingID = (int)LuaScriptMgr.GetNumber(L, 3);
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

		CityInfo obj = (CityInfo)o;
		obj.Level = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Flag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Flag");
		}

		CityInfo obj = (CityInfo)o;
		obj.Flag = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GeneralMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GeneralMax");
		}

		CityInfo obj = (CityInfo)o;
		obj.GeneralMax = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Major(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Major");
		}

		CityInfo obj = (CityInfo)o;
		obj.Major = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Wise(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Wise");
		}

		CityInfo obj = (CityInfo)o;
		obj.Wise = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Population(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Population");
		}

		CityInfo obj = (CityInfo)o;
		obj.Population = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Money(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Money");
		}

		CityInfo obj = (CityInfo)o;
		obj.Money = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Reservist(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Reservist");
		}

		CityInfo obj = (CityInfo)o;
		obj.Reservist = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ReservistMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ReservistMax");
		}

		CityInfo obj = (CityInfo)o;
		obj.ReservistMax = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Defense(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Defense");
		}

		CityInfo obj = (CityInfo)o;
		obj.Defense = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddGeneral(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddGeneral(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveGeneral(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveGeneral(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPrison(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddPrison(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemovePrison(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemovePrison(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddObject(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveObject(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindMajor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CityInfo obj = LuaScriptMgr.GetNetObject<CityInfo>(L, 1);
		obj.FindMajor();
		return 0;
	}
}

