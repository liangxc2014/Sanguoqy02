using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LuaInterface;

public class WrapDictionary
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("Add", Add),
		new LuaMethod("Clear", Clear),
		new LuaMethod("ContainsKey", ContainsKey),
		new LuaMethod("ContainsValue", ContainsValue),
		new LuaMethod("GetObjectData", GetObjectData),
		new LuaMethod("OnDeserialization", OnDeserialization),
		new LuaMethod("Remove", Remove),
		new LuaMethod("TryGetValue", TryGetValue),
		new LuaMethod("GetEnumerator", GetEnumerator),
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
		new LuaField("Count", get_Count, null),
		new LuaField("Comparer", get_Comparer, null),
		new LuaField("Keys", get_Keys, null),
		new LuaField("Values", get_Values, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(int)};
		Type[] types2 = {typeof(IDictionary<object,object>)};
		Type[] types3 = {typeof(IEqualityComparer<object>)};
		Type[] types4 = {typeof(int), typeof(IEqualityComparer<object>)};
		Type[] types5 = {typeof(IDictionary<object,object>), typeof(IEqualityComparer<object>)};

		if (count == 0)
		{
			Dictionary<object, object> obj = new Dictionary<object, object>();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Dictionary<object, object> obj = new Dictionary<object, object>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			IDictionary<object,object> arg0 = LuaScriptMgr.GetNetObject<IDictionary<object,object>>(L, 1);
			Dictionary<object, object> obj = new Dictionary<object, object>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			IEqualityComparer<object> arg0 = LuaScriptMgr.GetNetObject<IEqualityComparer<object>>(L, 1);
			Dictionary<object, object> obj = new Dictionary<object, object>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			IEqualityComparer<object> arg1 = LuaScriptMgr.GetNetObject<IEqualityComparer<object>>(L, 2);
			Dictionary<object, object> obj = new Dictionary<object, object>(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types5, 1))
		{
			IDictionary<object,object> arg0 = LuaScriptMgr.GetNetObject<IDictionary<object,object>>(L, 1);
			IEqualityComparer<object> arg1 = LuaScriptMgr.GetNetObject<IEqualityComparer<object>>(L, 2);
			Dictionary<object, object> obj = new Dictionary<object, object>(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Dictionary<object, object>.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Dictionary<object, object>));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Dictionary<object, object>", typeof(Dictionary<object, object>), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Count");
		}

		Dictionary<object, object> obj = (Dictionary<object, object>)o;
		LuaScriptMgr.Push(L, obj.Count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Comparer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Comparer");
		}

		Dictionary<object, object> obj = (Dictionary<object, object>)o;
		LuaScriptMgr.PushObject(L, obj.Comparer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Keys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Keys");
		}

		Dictionary<object, object> obj = (Dictionary<object, object>)o;
		LuaScriptMgr.PushObject(L, obj.Keys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Values(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Values");
		}

		Dictionary<object, object> obj = (Dictionary<object, object>)o;
		LuaScriptMgr.PushObject(L, obj.Values);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object o = obj[arg0];
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj[arg0] = arg1;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj.Add(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		obj.Clear();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.ContainsKey(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.ContainsValue(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObjectData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		SerializationInfo arg0 = LuaScriptMgr.GetNetObject<SerializationInfo>(L, 2);
		StreamingContext arg1 = LuaScriptMgr.GetNetObject<StreamingContext>(L, 3);
		obj.GetObjectData(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDeserialization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.OnDeserialization(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Remove(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TryGetValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetNetObject<object>(L, 3);
		bool o = obj.TryGetValue(arg0,out arg1);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushVarObject(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		Dictionary<object,object>.Enumerator o = obj.GetEnumerator();
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Dictionary<object, object> obj = LuaScriptMgr.GetNetObject<Dictionary<object, object>>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

