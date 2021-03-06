﻿using System;
using LuaInterface;

public class WrapIState
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnEnter", OnEnter),
		new LuaMethod("OnExit", OnExit),
		new LuaMethod("Update", Update),
		new LuaMethod("IfCanChangeToState", IfCanChangeToState),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Name", get_Name, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "IState class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(IState));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "IState", typeof(IState), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		IState obj = (IState)o;
		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IState obj = LuaScriptMgr.GetNetObject<IState>(L, 1);
		obj.OnEnter();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IState obj = LuaScriptMgr.GetNetObject<IState>(L, 1);
		obj.OnExit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IState obj = LuaScriptMgr.GetNetObject<IState>(L, 1);
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IfCanChangeToState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		IState obj = LuaScriptMgr.GetNetObject<IState>(L, 1);
		IState arg0 = LuaScriptMgr.GetNetObject<IState>(L, 2);
		bool o = obj.IfCanChangeToState(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

