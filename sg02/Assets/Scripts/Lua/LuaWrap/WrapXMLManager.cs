using System;
using LuaInterface;

public class WrapXMLManager
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LoadConfigs", LoadConfigs),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Battle", get_Battle, set_Battle),
		new LuaField("City", get_City, set_City),
		new LuaField("Force", get_Force, set_Force),
		new LuaField("Generals", get_Generals, set_Generals),
		new LuaField("Kings", get_Kings, set_Kings),
		new LuaField("Language", get_Language, set_Language),
		new LuaField("Magic", get_Magic, set_Magic),
		new LuaField("MenuItem", get_MenuItem, set_MenuItem),
		new LuaField("Things", get_Things, set_Things),
		new LuaField("Times", get_Times, set_Times),
		new LuaField("WiseSkill", get_WiseSkill, set_WiseSkill),
		new LuaField("Animations", get_Animations, set_Animations),
		new LuaField("PathInfo", get_PathInfo, set_PathInfo),
		new LuaField("CityPoints", get_CityPoints, set_CityPoints),
		new LuaField("LuaControlView", get_LuaControlView, set_LuaControlView),
		new LuaField("LuaScripts", get_LuaScripts, set_LuaScripts),
		new LuaField("ResourcePath", get_ResourcePath, set_ResourcePath),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "XMLManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(XMLManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "XMLManager", typeof(XMLManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Battle(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Battle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_City(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.City);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Force(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Force);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Generals(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Generals);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Kings(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Kings);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Language(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Language);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Magic(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Magic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MenuItem(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.MenuItem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Things(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Things);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Times(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Times);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WiseSkill(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.WiseSkill);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Animations(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Animations);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PathInfo(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.PathInfo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CityPoints(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.CityPoints);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaControlView(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.LuaControlView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaScripts(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.LuaScripts);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ResourcePath(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.ResourcePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Battle(IntPtr L)
	{
		XMLManager.Battle = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataBattle>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_City(IntPtr L)
	{
		XMLManager.City = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataCity>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Force(IntPtr L)
	{
		XMLManager.Force = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataForce>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Generals(IntPtr L)
	{
		XMLManager.Generals = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataGenerals>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Kings(IntPtr L)
	{
		XMLManager.Kings = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataKings>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Language(IntPtr L)
	{
		XMLManager.Language = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLanguage>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Magic(IntPtr L)
	{
		XMLManager.Magic = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataMagic>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MenuItem(IntPtr L)
	{
		XMLManager.MenuItem = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataMenuItem>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Things(IntPtr L)
	{
		XMLManager.Things = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataThings>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Times(IntPtr L)
	{
		XMLManager.Times = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataTimes>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WiseSkill(IntPtr L)
	{
		XMLManager.WiseSkill = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataWiseSkill>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Animations(IntPtr L)
	{
		XMLManager.Animations = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataAnimations>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PathInfo(IntPtr L)
	{
		XMLManager.PathInfo = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataPathInfo>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CityPoints(IntPtr L)
	{
		XMLManager.CityPoints = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataCityPoints>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaControlView(IntPtr L)
	{
		XMLManager.LuaControlView = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLuaControlView>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaScripts(IntPtr L)
	{
		XMLManager.LuaScripts = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLuaScripts>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ResourcePath(IntPtr L)
	{
		XMLManager.ResourcePath = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataResourcePath>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadConfigs(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		XMLManager.LoadConfigs();
		return 0;
	}
}

