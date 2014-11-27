using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;

public class WrapObjectPool
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
		new LuaMethod("CreateOneObject", CreateOneObject),
		new LuaMethod("DestroyOneObject", DestroyOneObject),
		new LuaMethod("DestroyAll", DestroyAll),
		new LuaMethod("GetObject", GetObject),
		new LuaMethod("GiveBackObject", GiveBackObject),
		new LuaMethod("GiveBackAllObjects", GiveBackAllObjects),
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
		new LuaField("m_listObject", get_m_listObject, set_m_listObject),
		new LuaField("m_listState", get_m_listState, set_m_listState),
		new LuaField("PoolObjectCount", get_PoolObjectCount, null),
		new LuaField("CurrentUsedCount", get_CurrentUsedCount, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ObjectPool obj = new ObjectPool();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ObjectPool.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ObjectPool));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "ObjectPool", typeof(ObjectPool), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_listObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name m_listObject");
		}

		ObjectPool obj = (ObjectPool)o;
		LuaScriptMgr.PushObject(L, obj.m_listObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_m_listState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name m_listState");
		}

		ObjectPool obj = (ObjectPool)o;
		LuaScriptMgr.PushObject(L, obj.m_listState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PoolObjectCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name PoolObjectCount");
		}

		ObjectPool obj = (ObjectPool)o;
		LuaScriptMgr.Push(L, obj.PoolObjectCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentUsedCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentUsedCount");
		}

		ObjectPool obj = (ObjectPool)o;
		LuaScriptMgr.Push(L, obj.CurrentUsedCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_listObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name m_listObject");
		}

		ObjectPool obj = (ObjectPool)o;
		obj.m_listObject = LuaScriptMgr.GetNetObject<List<GameObject>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_m_listState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name m_listState");
		}

		ObjectPool obj = (ObjectPool)o;
		obj.m_listState = LuaScriptMgr.GetNetObject<List<bool>>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		ObjectPool.CreateObjectDelegate arg2 = LuaScriptMgr.GetNetObject<ObjectPool.CreateObjectDelegate>(L, 4);
		obj.Initialize(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateOneObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		int o = obj.CreateOneObject();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyOneObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		obj.DestroyOneObject(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestroyAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		obj.DestroyAll();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		GameObject o = obj.GetObject();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GiveBackObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 2);
		obj.GiveBackObject(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GiveBackAllObjects(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		obj.GiveBackAllObjects();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ObjectPool obj = LuaScriptMgr.GetNetObject<ObjectPool>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

