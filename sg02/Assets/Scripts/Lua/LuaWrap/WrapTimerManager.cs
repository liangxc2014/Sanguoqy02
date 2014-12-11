using System;
using LuaInterface;

public class WrapTimerManager
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
		new LuaMethod("WaitForSeconds", WaitForSeconds),
		new LuaMethod("WaitForEndOfFrame", WaitForEndOfFrame),
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
			TimerManager obj = new TimerManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TimerManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(TimerManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "TimerManager", typeof(TimerManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, TimerManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TimerManager obj = LuaScriptMgr.GetNetObject<TimerManager>(L, 1);
		obj.Initialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TimerManager obj = LuaScriptMgr.GetNetObject<TimerManager>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WaitForSeconds(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(TimerManager), typeof(float), typeof(TimerManager.CallbackWithArgs)};

		if (count == 3)
		{
			TimerManager obj = LuaScriptMgr.GetNetObject<TimerManager>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			TimerManager.Callback arg1 = LuaScriptMgr.GetNetObject<TimerManager.Callback>(L, 3);
			obj.WaitForSeconds(arg0,arg1);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, types1, 1) && LuaScriptMgr.CheckParamsType(L, typeof(object), 4, count - 3))
		{
			TimerManager obj = LuaScriptMgr.GetNetObject<TimerManager>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			TimerManager.CallbackWithArgs arg1 = LuaScriptMgr.GetNetObject<TimerManager.CallbackWithArgs>(L, 3);
			object[] objs2 = LuaScriptMgr.GetParamsObject(L, 4, count - 3);
			obj.WaitForSeconds(arg0,arg1,objs2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TimerManager.WaitForSeconds");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WaitForEndOfFrame(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(TimerManager), typeof(TimerManager.CallbackWithArgs)};

		if (count == 2)
		{
			TimerManager obj = LuaScriptMgr.GetNetObject<TimerManager>(L, 1);
			TimerManager.Callback arg0 = LuaScriptMgr.GetNetObject<TimerManager.Callback>(L, 2);
			obj.WaitForEndOfFrame(arg0);
			return 0;
		}
		else if (LuaScriptMgr.CheckTypes(L, types1, 1) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			TimerManager obj = LuaScriptMgr.GetNetObject<TimerManager>(L, 1);
			TimerManager.CallbackWithArgs arg0 = LuaScriptMgr.GetNetObject<TimerManager.CallbackWithArgs>(L, 2);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			obj.WaitForEndOfFrame(arg0,objs1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TimerManager.WaitForEndOfFrame");
		}

		return 0;
	}
}

