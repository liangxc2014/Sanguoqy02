using System;
using UnityEngine;
using LuaInterface;

public class WrapWorldMapControl
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
		new LuaMethod("Build", Build),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Instance", get_Instance, null),
		new LuaField("CameraOffset", get_CameraOffset, set_CameraOffset),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			WorldMapControl obj = new WorldMapControl();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WorldMapControl.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(WorldMapControl));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "WorldMapControl", typeof(WorldMapControl), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, WorldMapControl.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CameraOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CameraOffset");
		}

		WorldMapControl obj = (WorldMapControl)o;
		LuaScriptMgr.PushValue(L, obj.CameraOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CameraOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CameraOffset");
		}

		WorldMapControl obj = (WorldMapControl)o;
		obj.CameraOffset = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		WorldMapControl obj = LuaScriptMgr.GetNetObject<WorldMapControl>(L, 1);
		obj.Initialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		WorldMapControl obj = LuaScriptMgr.GetNetObject<WorldMapControl>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Build(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		WorldMapControl obj = LuaScriptMgr.GetNetObject<WorldMapControl>(L, 1);
		obj.Build();
		return 0;
	}
}

