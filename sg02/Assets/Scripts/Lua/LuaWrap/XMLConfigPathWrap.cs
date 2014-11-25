using System;
using LuaInterface;

public class XMLConfigPathWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("GlobalConfig", get_GlobalConfig, null),
		new LuaField("Kings", get_Kings, null),
		new LuaField("Arms", get_Arms, null),
		new LuaField("Buff", get_Buff, null),
		new LuaField("City", get_City, null),
		new LuaField("Formations", get_Formations, null),
		new LuaField("Generals", get_Generals, null),
		new LuaField("Magic", get_Magic, null),
		new LuaField("Objects", get_Objects, null),
		new LuaField("Period", get_Period, null),
		new LuaField("PathInfo", get_PathInfo, null),
		new LuaField("CityPoints", get_CityPoints, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "XMLConfigPath class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(XMLConfigPath));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "XMLConfigPath", typeof(XMLConfigPath), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GlobalConfig(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.GlobalConfig);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Kings(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Kings);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Arms(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Arms);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Buff(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Buff);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_City(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.City);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Formations(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Formations);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Generals(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Generals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Magic(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Magic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Objects(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Objects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Period(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Period);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PathInfo(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.PathInfo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CityPoints(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.CityPoints);
		return 1;
	}
}

