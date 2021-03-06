﻿using System;
using LuaInterface;

public class WrapGlobalConfig
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LoadConfig", LoadConfig),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("DesignScreenWidth", get_DesignScreenWidth, null),
		new LuaField("DesignScreenHeight", get_DesignScreenHeight, null),
		new LuaField("IsDebuggingOpen", get_IsDebuggingOpen, null),
		new LuaField("IsMapEditorMode", get_IsMapEditorMode, null),
		new LuaField("MapSize", get_MapSize, null),
		new LuaField("FontButtonsVSpace", get_FontButtonsVSpace, null),
		new LuaField("PathShapeFace", get_PathShapeFace, null),
		new LuaField("AnimationSpeed", get_AnimationSpeed, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "GlobalConfig class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(GlobalConfig));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "GlobalConfig", typeof(GlobalConfig), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DesignScreenWidth(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.DesignScreenWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DesignScreenHeight(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.DesignScreenHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsDebuggingOpen(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.IsDebuggingOpen);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsMapEditorMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.IsMapEditorMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MapSize(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, GlobalConfig.MapSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FontButtonsVSpace(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.FontButtonsVSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PathShapeFace(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.PathShapeFace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AnimationSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, GlobalConfig.AnimationSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadConfig(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		GlobalConfig.LoadConfig();
		return 0;
	}
}

