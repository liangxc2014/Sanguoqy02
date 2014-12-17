using System;
using UnityEngine;
using LuaInterface;

public class WrapUIToggle
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnToggle", OnToggle),
		new LuaMethod("SetGroup", SetGroup),
		new LuaMethod("SetText", SetText),
		new LuaMethod("Toggle", Toggle),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIToggle class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(UIToggle));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UIToggle", typeof(UIToggle), regs, fields, "MonoBehaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnToggle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIToggle obj = LuaScriptMgr.GetNetObject<UIToggle>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.OnToggle(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetGroup(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIToggle obj = LuaScriptMgr.GetNetObject<UIToggle>(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		obj.SetGroup(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIToggle obj = LuaScriptMgr.GetNetObject<UIToggle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SetText(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Toggle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIToggle obj = LuaScriptMgr.GetNetObject<UIToggle>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.Toggle(arg0);
		return 0;
	}
}

