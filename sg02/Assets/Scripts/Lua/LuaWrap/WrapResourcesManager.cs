using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class WrapResourcesManager
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
		new LuaMethod("Load", Load),
		new LuaMethod("LoadUIView", LoadUIView),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Instance", get_Instance, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ResourcesManager obj = new ResourcesManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ResourcesManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ResourcesManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "ResourcesManager", typeof(ResourcesManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, ResourcesManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ResourcesManager obj = LuaScriptMgr.GetNetObject<ResourcesManager>(L, 1);
		obj.Initialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ResourcesManager obj = LuaScriptMgr.GetNetObject<ResourcesManager>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ResourcesManager obj = LuaScriptMgr.GetNetObject<ResourcesManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Object o = obj.Load(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadUIView(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ResourcesManager obj = LuaScriptMgr.GetNetObject<ResourcesManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		GameObject arg1 = LuaScriptMgr.GetNetObject<GameObject>(L, 3);
		GameObject o = obj.LoadUIView(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

