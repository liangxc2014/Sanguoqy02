using System;
using System.Collections.Generic;
using LuaInterface;

public class WrapDictEnumerator
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("MoveNext", MoveNext),
		new LuaMethod("Dispose", Dispose),
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("ToString", ToString),
		new LuaMethod("GetType", GetType),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Current", get_Current, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Dictionary<object,object>.Enumerator obj = new Dictionary<object,object>.Enumerator();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Dictionary<object,object>.Enumerator));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Dictionary<object,object>.Enumerator", typeof(Dictionary<object,object>.Enumerator), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Current(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Current");
		}

		Dictionary<object,object>.Enumerator obj = (Dictionary<object,object>.Enumerator)o;
		LuaScriptMgr.PushValue(L, obj.Current);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveNext(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		bool o = obj.MoveNext();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dispose(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		obj.Dispose();
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object,object>.Enumerator obj = LuaScriptMgr.GetNetObject<Dictionary<object,object>.Enumerator>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

