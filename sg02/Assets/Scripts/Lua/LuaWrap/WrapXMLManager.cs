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
		new LuaField("Arms", get_Arms, set_Arms),
		new LuaField("Buff", get_Buff, set_Buff),
		new LuaField("City", get_City, set_City),
		new LuaField("Formations", get_Formations, set_Formations),
		new LuaField("Generals", get_Generals, set_Generals),
		new LuaField("Kings", get_Kings, set_Kings),
		new LuaField("Magic", get_Magic, set_Magic),
		new LuaField("Objects", get_Objects, set_Objects),
		new LuaField("Period", get_Period, set_Period),
		new LuaField("PathInfo", get_PathInfo, set_PathInfo),
		new LuaField("CityPoints", get_CityPoints, set_CityPoints),
		new LuaField("LuaControlView", get_LuaControlView, set_LuaControlView),
		new LuaField("LuaScripts", get_LuaScripts, set_LuaScripts),
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
	static int get_Arms(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Arms);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Buff(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Buff);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_City(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.City);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Formations(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Formations);
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
	static int get_Magic(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Magic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Objects(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Objects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Period(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, XMLManager.Period);
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
	static int set_Arms(IntPtr L)
	{
		XMLManager.Arms = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataArms>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Buff(IntPtr L)
	{
		XMLManager.Buff = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataBuff>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_City(IntPtr L)
	{
		XMLManager.City = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataCity>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Formations(IntPtr L)
	{
		XMLManager.Formations = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataFormations>>(L, 3);
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
	static int set_Magic(IntPtr L)
	{
		XMLManager.Magic = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataMagic>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Objects(IntPtr L)
	{
		XMLManager.Objects = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataObjects>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Period(IntPtr L)
	{
		XMLManager.Period = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataPeriod>>(L, 3);
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
	static int LoadConfigs(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		XMLManager.LoadConfigs();
		return 0;
	}
}

