using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;

public class WrapUIManager
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ShowView", ShowView),
		new LuaMethod("HideView", HideView),
		new LuaMethod("DestroyView", DestroyView),
		new LuaMethod("DestroyAllView", DestroyAllView),
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
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
		new LuaField("Instance", get_Instance, null),
		new LuaField("m_dicUIView", get_m_dicUIView, set_m_dicUIView),
		new LuaField("UIRoot", get_UIRoot, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UIManager obj = new UIManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(UIManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UIManager", typeof(UIManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, UIManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_dicUIView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name m_dicUIView");
		}

		UIManager obj = (UIManager)o;
		LuaScriptMgr.PushObject(L, obj.m_dicUIView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UIRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UIRoot");
		}

		UIManager obj = (UIManager)o;
		LuaScriptMgr.Push(L, obj.UIRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_dicUIView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name m_dicUIView");
		}

		UIManager obj = (UIManager)o;
		obj.m_dicUIView = LuaScriptMgr.GetNetObject<Dictionary<string,GameObject>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowView(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		GameObject o = obj.ShowView(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideView(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.HideView(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyView(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(UIManager), typeof(GameObject)};
		Type[] types1 = {typeof(UIManager), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
			GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
			obj.DestroyView(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.DestroyView(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIManager.DestroyView");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyAllView(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		obj.DestroyAllView();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
			obj.Initialize();
			return 0;
		}
		else if (count == 2)
		{
			UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			obj.Initialize(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIManager.Initialize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIManager obj = LuaScriptMgr.GetNetObject<UIManager>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

