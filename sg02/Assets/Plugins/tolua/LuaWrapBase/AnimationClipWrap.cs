﻿using UnityEngine;
using System;
using LuaInterface;

public class AnimationClipWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SampleAnimation", SampleAnimation),
		new LuaMethod("SetCurve", SetCurve),
		new LuaMethod("EnsureQuaternionContinuity", EnsureQuaternionContinuity),
		new LuaMethod("ClearCurves", ClearCurves),
		new LuaMethod("AddEvent", AddEvent),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("length", get_length, null),
		new LuaField("frameRate", get_frameRate, set_frameRate),
		new LuaField("wrapMode", get_wrapMode, set_wrapMode),
		new LuaField("localBounds", get_localBounds, set_localBounds),
		new LuaField("legacy", get_legacy, set_legacy),
		new LuaField("humanMotion", get_humanMotion, null),
		new LuaField("events", get_events, set_events),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnimationClip obj = new AnimationClip();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationClip.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnimationClip));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "AnimationClip", typeof(AnimationClip), regs, fields, "Motion");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_length(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name length");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.Push(L, obj.length);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name frameRate");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.Push(L, obj.frameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name wrapMode");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.PushEnum(L, obj.wrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localBounds");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.PushValue(L, obj.localBounds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legacy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name legacy");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.Push(L, obj.legacy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_humanMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name humanMotion");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.Push(L, obj.humanMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_events(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name events");
		}

		AnimationClip obj = (AnimationClip)o;
		LuaScriptMgr.PushArray(L, obj.events);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frameRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name frameRate");
		}

		AnimationClip obj = (AnimationClip)o;
		obj.frameRate = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name wrapMode");
		}

		AnimationClip obj = (AnimationClip)o;
		obj.wrapMode = LuaScriptMgr.GetNetObject<WrapMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name localBounds");
		}

		AnimationClip obj = (AnimationClip)o;
		obj.localBounds = LuaScriptMgr.GetNetObject<Bounds>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legacy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name legacy");
		}

		AnimationClip obj = (AnimationClip)o;
		obj.legacy = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_events(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name events");
		}

		AnimationClip obj = (AnimationClip)o;
		obj.events = LuaScriptMgr.GetNetObject<AnimationEvent[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SampleAnimation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AnimationClip obj = LuaScriptMgr.GetNetObject<AnimationClip>(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SampleAnimation(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurve(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		AnimationClip obj = LuaScriptMgr.GetNetObject<AnimationClip>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Type arg1 = LuaScriptMgr.GetTypeObject(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		AnimationCurve arg3 = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 5);
		obj.SetCurve(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnsureQuaternionContinuity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationClip obj = LuaScriptMgr.GetNetObject<AnimationClip>(L, 1);
		obj.EnsureQuaternionContinuity();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearCurves(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationClip obj = LuaScriptMgr.GetNetObject<AnimationClip>(L, 1);
		obj.ClearCurves();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationClip obj = LuaScriptMgr.GetNetObject<AnimationClip>(L, 1);
		AnimationEvent arg0 = LuaScriptMgr.GetNetObject<AnimationEvent>(L, 2);
		obj.AddEvent(arg0);
		return 0;
	}
}

