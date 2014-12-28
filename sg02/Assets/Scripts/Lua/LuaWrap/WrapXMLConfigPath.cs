using System;
using LuaInterface;

public class WrapXMLConfigPath
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("GlobalConfig", get_GlobalConfig, null),
		new LuaField("Battle", get_Battle, null),
		new LuaField("City", get_City, null),
		new LuaField("Force", get_Force, null),
		new LuaField("Generals", get_Generals, null),
		new LuaField("Kings", get_Kings, null),
		new LuaField("Language", get_Language, null),
		new LuaField("Magic", get_Magic, null),
		new LuaField("MenuItem", get_MenuItem, null),
		new LuaField("Things", get_Things, null),
		new LuaField("Times", get_Times, null),
		new LuaField("WiseSkill", get_WiseSkill, null),
		new LuaField("Animations", get_Animations, null),
		new LuaField("PathInfo", get_PathInfo, null),
		new LuaField("CityPoints", get_CityPoints, null),
		new LuaField("LuaControlView", get_LuaControlView, null),
		new LuaField("LuaScripts", get_LuaScripts, null),
		new LuaField("ResourcePath", get_ResourcePath, null),
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
	static int get_Battle(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Battle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_City(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.City);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Force(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Force);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Generals(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Generals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Kings(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Kings);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Language(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Language);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Magic(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Magic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MenuItem(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.MenuItem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Things(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Things);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Times(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Times);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WiseSkill(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.WiseSkill);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Animations(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.Animations);
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

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaControlView(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.LuaControlView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaScripts(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.LuaScripts);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ResourcePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, XMLConfigPath.ResourcePath);
		return 1;
	}
}

