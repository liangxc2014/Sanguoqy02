using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;

public class WrapUtility
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetIPAddress", GetIPAddress),
		new LuaMethod("PointInPolygon", PointInPolygon),
		new LuaMethod("GetPoint", GetPoint),
		new LuaMethod("AddComponent", AddComponent),
		new LuaMethod("AddChild", AddChild),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};


	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Utility class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Utility));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Utility", regs);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIPAddress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Utility.GetIPAddress();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PointInPolygon(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
		List<Vector2> arg1 = LuaScriptMgr.GetNetObject<List<Vector2>>(L, 2);
		bool o = Utility.PointInPolygon(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPoint(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Vector3 o = Utility.GetPoint(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddComponent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		MonoBehaviour o = Utility.AddComponent(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		GameObject arg1 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		GameObject o = Utility.AddChild(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

