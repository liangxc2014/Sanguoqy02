using System;
using LuaInterface;

public class WrapKingInfo
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddCity", AddCity),
		new LuaMethod("RemoveCity", RemoveCity),
		new LuaMethod("AddGeneral", AddGeneral),
		new LuaMethod("RemoveGeneral", RemoveGeneral),
		new LuaMethod("AddPrisons", AddPrisons),
		new LuaMethod("RemovePrisons", RemovePrisons),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Active", get_Active, set_Active),
		new LuaField("ID", get_ID, set_ID),
		new LuaField("GeneralID", get_GeneralID, set_GeneralID),
		new LuaField("Citys", get_Citys, null),
		new LuaField("Generals", get_Generals, null),
		new LuaField("Prisons", get_Prisons, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			KingInfo obj = new KingInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			KingInfo obj = new KingInfo(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: KingInfo.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(KingInfo));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "KingInfo", typeof(KingInfo), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Active(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Active");
		}

		KingInfo obj = (KingInfo)o;
		LuaScriptMgr.Push(L, obj.Active);
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

		KingInfo obj = (KingInfo)o;
		LuaScriptMgr.Push(L, obj.ID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GeneralID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GeneralID");
		}

		KingInfo obj = (KingInfo)o;
		LuaScriptMgr.Push(L, obj.GeneralID);
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

		KingInfo obj = (KingInfo)o;
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

		KingInfo obj = (KingInfo)o;
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

		KingInfo obj = (KingInfo)o;
		LuaScriptMgr.PushObject(L, obj.Prisons);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Active(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Active");
		}

		KingInfo obj = (KingInfo)o;
		obj.Active = LuaScriptMgr.GetBoolean(L, 3);
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

		KingInfo obj = (KingInfo)o;
		obj.ID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GeneralID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GeneralID");
		}

		KingInfo obj = (KingInfo)o;
		obj.GeneralID = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddCity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		KingInfo obj = LuaScriptMgr.GetNetObject<KingInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddCity(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveCity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		KingInfo obj = LuaScriptMgr.GetNetObject<KingInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveCity(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddGeneral(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		KingInfo obj = LuaScriptMgr.GetNetObject<KingInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddGeneral(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveGeneral(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		KingInfo obj = LuaScriptMgr.GetNetObject<KingInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveGeneral(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPrisons(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		KingInfo obj = LuaScriptMgr.GetNetObject<KingInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.AddPrisons(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemovePrisons(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		KingInfo obj = LuaScriptMgr.GetNetObject<KingInfo>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemovePrisons(arg0);
		return 0;
	}
}

