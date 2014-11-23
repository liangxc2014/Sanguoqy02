using System;
using UnityEngine;
using LuaInterface;

public class TestLuaFunctionTypeWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LuaFunctionType", LuaFunctionType),
		new LuaMethod("CallDelegate", CallDelegate),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("testDelegate", get_testDelegate, set_testDelegate),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
			TestLuaFunctionType obj = new TestLuaFunctionType(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: TestLuaFunctionType.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(TestLuaFunctionType));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "TestLuaFunctionType", typeof(TestLuaFunctionType), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_testDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name testDelegate");
		}

		TestLuaFunctionType obj = (TestLuaFunctionType)o;
		LuaScriptMgr.Push(L, obj.testDelegate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_testDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name testDelegate");
		}

		TestLuaFunctionType obj = (TestLuaFunctionType)o;
		obj.testDelegate = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaFunctionType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		TestLuaFunctionType obj = LuaScriptMgr.GetNetObject<TestLuaFunctionType>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		GameObject arg1 = LuaScriptMgr.GetNetObject<GameObject>(L, 3);
		obj.LuaFunctionType(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		TestLuaFunctionType obj = LuaScriptMgr.GetNetObject<TestLuaFunctionType>(L, 1);
		obj.CallDelegate();
		return 0;
	}
}

