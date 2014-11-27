using System;
using LuaInterface;

public class WrapXMLDataObjects
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
		new LuaField("UsedType", get_UsedType, set_UsedType),
		new LuaField("TypeName", get_TypeName, set_TypeName),
		new LuaField("WeaponType", get_WeaponType, set_WeaponType),
		new LuaField("WeaponObject", get_WeaponObject, set_WeaponObject),
		new LuaField("SearchType", get_SearchType, set_SearchType),
		new LuaField("Type", get_Type, set_Type),
		new LuaField("LevelLimit", get_LevelLimit, set_LevelLimit),
		new LuaField("Picture", get_Picture, set_Picture),
		new LuaField("SearchProbability", get_SearchProbability, set_SearchProbability),
		new LuaField("Strength", get_Strength, set_Strength),
		new LuaField("Intellect", get_Intellect, set_Intellect),
		new LuaField("HealthyMax", get_HealthyMax, set_HealthyMax),
		new LuaField("ManaMax", get_ManaMax, set_ManaMax),
		new LuaField("ArmsLearn", get_ArmsLearn, set_ArmsLearn),
		new LuaField("FormationLearn", get_FormationLearn, set_FormationLearn),
		new LuaField("SpecialSkill", get_SpecialSkill, set_SpecialSkill),
		new LuaField("Speed", get_Speed, set_Speed),
		new LuaField("Loyalty", get_Loyalty, set_Loyalty),
		new LuaField("Descript", get_Descript, set_Descript),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "XMLDataObjects class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(XMLDataObjects));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "XMLDataObjects", typeof(XMLDataObjects), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ID");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
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

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UsedType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UsedType");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.UsedType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TypeName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name TypeName");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.TypeName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WeaponType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WeaponType");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.WeaponType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WeaponObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WeaponObject");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.WeaponObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SearchType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SearchType");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.SearchType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Type");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Type);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LevelLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name LevelLimit");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.LevelLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Picture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Picture");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Picture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SearchProbability(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SearchProbability");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.SearchProbability);
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

		XMLDataObjects obj = (XMLDataObjects)o;
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

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Intellect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HealthyMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name HealthyMax");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.HealthyMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ManaMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ManaMax");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.ManaMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ArmsLearn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ArmsLearn");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.ArmsLearn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FormationLearn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name FormationLearn");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.FormationLearn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpecialSkill(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SpecialSkill");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.SpecialSkill);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Speed");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Speed);
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

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Loyalty);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Descript(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Descript");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		LuaScriptMgr.Push(L, obj.Descript);
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

		XMLDataObjects obj = (XMLDataObjects)o;
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

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UsedType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UsedType");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.UsedType = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_TypeName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name TypeName");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.TypeName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WeaponType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WeaponType");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.WeaponType = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WeaponObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name WeaponObject");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.WeaponObject = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SearchType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SearchType");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.SearchType = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Type(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Type");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Type = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LevelLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name LevelLimit");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.LevelLimit = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Picture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Picture");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Picture = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SearchProbability(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SearchProbability");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.SearchProbability = (int)LuaScriptMgr.GetNumber(L, 3);
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

		XMLDataObjects obj = (XMLDataObjects)o;
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

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Intellect = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_HealthyMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name HealthyMax");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.HealthyMax = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ManaMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ManaMax");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.ManaMax = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ArmsLearn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ArmsLearn");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.ArmsLearn = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_FormationLearn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name FormationLearn");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.FormationLearn = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SpecialSkill(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SpecialSkill");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.SpecialSkill = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Speed");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Speed = (int)LuaScriptMgr.GetNumber(L, 3);
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

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Loyalty = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Descript(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Descript");
		}

		XMLDataObjects obj = (XMLDataObjects)o;
		obj.Descript = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}

