using System;
using LuaInterface;

public class WrapXMLDataGenerals
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("ID", get_ID, set_ID),
		new LuaField("Name", get_Name, set_Name),
		new LuaField("Strength", get_Strength, set_Strength),
		new LuaField("Intellect", get_Intellect, set_Intellect),
		new LuaField("Total", get_Total, set_Total),
		new LuaField("Magic", get_Magic, set_Magic),
		new LuaField("Level", get_Level, set_Level),
		new LuaField("MagicLevel", get_MagicLevel, set_MagicLevel),
		new LuaField("Buff", get_Buff, set_Buff),
		new LuaField("BuffLevel", get_BuffLevel, set_BuffLevel),
		new LuaField("Period", get_Period, set_Period),
		new LuaField("PeriodState", get_PeriodState, set_PeriodState),
		new LuaField("Weapon", get_Weapon, set_Weapon),
		new LuaField("Formations", get_Formations, set_Formations),
		new LuaField("FormationUsed", get_FormationUsed, set_FormationUsed),
		new LuaField("Arms", get_Arms, set_Arms),
		new LuaField("ArmUsed", get_ArmUsed, set_ArmUsed),
		new LuaField("Lord", get_Lord, set_Lord),
		new LuaField("Family", get_Family, set_Family),
		new LuaField("Character", get_Character, set_Character),
		new LuaField("Graph", get_Graph, set_Graph),
		new LuaField("Flag", get_Flag, set_Flag),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "XMLDataGenerals class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(XMLDataGenerals));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "XMLDataGenerals", typeof(XMLDataGenerals), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ID");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Name);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Intellect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Total(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Total");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Total);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Magic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Magic");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.Magic);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.Level);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MagicLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name MagicLevel");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.MagicLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Buff(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Buff");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.Buff);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BuffLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BuffLevel");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.BuffLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Period(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Period");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.Period);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PeriodState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name PeriodState");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.PushArray(L, obj.PeriodState);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Weapon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Formations(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Formations");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Formations);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FormationUsed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name FormationUsed");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.FormationUsed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Arms(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Arms");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Arms);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ArmUsed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ArmUsed");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.ArmUsed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Lord(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Lord");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Lord);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Family(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Family");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Family);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Character(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Character");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Character);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Graph(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Graph");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Graph);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		LuaScriptMgr.Push(L, obj.Flag);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Name = LuaScriptMgr.GetString(L, 3);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Intellect = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Total(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Total");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Total = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Magic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Magic");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Magic = LuaScriptMgr.GetNetObject<String[]>(L, 3);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Level = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MagicLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name MagicLevel");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.MagicLevel = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Buff(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Buff");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Buff = LuaScriptMgr.GetNetObject<String[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BuffLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name BuffLevel");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.BuffLevel = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Period(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Period");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Period = LuaScriptMgr.GetNetObject<String[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PeriodState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name PeriodState");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.PeriodState = LuaScriptMgr.GetNetObject<String[]>(L, 3);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Weapon = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Formations(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Formations");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Formations = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_FormationUsed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name FormationUsed");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.FormationUsed = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Arms(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Arms");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Arms = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ArmUsed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ArmUsed");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.ArmUsed = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Lord(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Lord");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Lord = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Family(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Family");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Family = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Character(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Character");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Character = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Graph(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Graph");
		}

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Graph = (int)LuaScriptMgr.GetNumber(L, 3);
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

		XMLDataGenerals obj = (XMLDataGenerals)o;
		obj.Flag = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

