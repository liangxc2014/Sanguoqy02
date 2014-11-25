using System;
using UnityEngine;
using LuaInterface;

public class DebuggingWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Init", Init),
		new LuaMethod("Log", Log),
		new LuaMethod("LogError", LogError),
		new LuaMethod("LogWaring", LogWaring),
		new LuaMethod("SetFilterWords", SetFilterWords),
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetType", GetType),
		new LuaMethod("ToString", ToString),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("LV_DEBUG", get_LV_DEBUG, null),
		new LuaField("LV_ERROR", get_LV_ERROR, null),
		new LuaField("LV_INFO", get_LV_INFO, null),
		new LuaField("LV_NONE", get_LV_NONE, null),
		new LuaField("LV_WARING", get_LV_WARING, null),
		new LuaField("CurrentDebugLevel", get_CurrentDebugLevel, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Debugging obj = new Debugging();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debugging.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Debugging));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Debugging", typeof(Debugging), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LV_DEBUG(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugging.LV_DEBUG);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LV_ERROR(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugging.LV_ERROR);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LV_INFO(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugging.LV_INFO);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LV_NONE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugging.LV_NONE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LV_WARING(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugging.LV_WARING);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentDebugLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugging.CurrentDebugLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Debugging obj = LuaScriptMgr.GetNetObject<Debugging>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		Debugging.Init(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(float)};
		Type[] types2 = {typeof(Vector3), typeof(int)};
		Type[] types3 = {typeof(string), typeof(int)};
		Type[] types4 = {typeof(float), typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Debugging.Log(arg0);
			return 0;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			Debugging.Log(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Debugging.Log(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Debugging.Log(arg0,arg1);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Debugging.Log(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Debugging.Log");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Debugging.LogError(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWaring(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Debugging.LogWaring(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFilterWords(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Debugging.SetFilterWords(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Debugging obj = LuaScriptMgr.GetNetObject<Debugging>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Debugging obj = LuaScriptMgr.GetNetObject<Debugging>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Debugging obj = LuaScriptMgr.GetNetObject<Debugging>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Debugging obj = LuaScriptMgr.GetNetObject<Debugging>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

