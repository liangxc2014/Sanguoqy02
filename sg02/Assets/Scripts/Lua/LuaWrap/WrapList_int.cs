using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using LuaInterface;

public class WrapList_int
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Add", Add),
		new LuaMethod("AddRange", AddRange),
		new LuaMethod("AsReadOnly", AsReadOnly),
		new LuaMethod("BinarySearch", BinarySearch),
		new LuaMethod("Clear", Clear),
		new LuaMethod("Contains", Contains),
		new LuaMethod("CopyTo", CopyTo),
		new LuaMethod("Exists", Exists),
		new LuaMethod("Find", Find),
		new LuaMethod("FindAll", FindAll),
		new LuaMethod("FindIndex", FindIndex),
		new LuaMethod("FindLast", FindLast),
		new LuaMethod("FindLastIndex", FindLastIndex),
		new LuaMethod("ForEach", ForEach),
		new LuaMethod("GetEnumerator", GetEnumerator),
		new LuaMethod("GetRange", GetRange),
		new LuaMethod("IndexOf", IndexOf),
		new LuaMethod("Insert", Insert),
		new LuaMethod("InsertRange", InsertRange),
		new LuaMethod("LastIndexOf", LastIndexOf),
		new LuaMethod("Remove", Remove),
		new LuaMethod("RemoveAll", RemoveAll),
		new LuaMethod("RemoveAt", RemoveAt),
		new LuaMethod("RemoveRange", RemoveRange),
		new LuaMethod("Reverse", Reverse),
		new LuaMethod("Sort", Sort),
		new LuaMethod("ToArray", ToArray),
		new LuaMethod("TrimExcess", TrimExcess),
		new LuaMethod("TrueForAll", TrueForAll),
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
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
		new LuaField("Capacity", get_Capacity, set_Capacity),
		new LuaField("Count", get_Count, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(int)};
		Type[] types2 = {typeof(IEnumerable<int>)};

		if (count == 0)
		{
			List<int> obj = new List<int>();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			List<int> obj = new List<int>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			IEnumerable<int> arg0 = LuaScriptMgr.GetNetObject<IEnumerable<int>>(L, 1);
			List<int> obj = new List<int>(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(List<int>));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "List<int>", typeof(List<int>), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Capacity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Capacity");
		}

		List<int> obj = (List<int>)o;
		LuaScriptMgr.Push(L, obj.Capacity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Count");
		}

		List<int> obj = (List<int>)o;
		LuaScriptMgr.Push(L, obj.Count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Capacity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Capacity");
		}

		List<int> obj = (List<int>)o;
		obj.Capacity = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.Add(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		IEnumerable<int> arg0 = LuaScriptMgr.GetNetObject<IEnumerable<int>>(L, 2);
		obj.AddRange(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AsReadOnly(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		ReadOnlyCollection<int> o = obj.AsReadOnly();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BinarySearch(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = obj.BinarySearch(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			IComparer<int> arg1 = LuaScriptMgr.GetNetObject<IComparer<int>>(L, 3);
			int o = obj.BinarySearch(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			IComparer<int> arg3 = LuaScriptMgr.GetNetObject<IComparer<int>>(L, 5);
			int o = obj.BinarySearch(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.BinarySearch");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		obj.Clear();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyTo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 2);
			obj.CopyTo(objs0);
			return 0;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.CopyTo(objs0,arg1);
			return 0;
		}
		else if (count == 5)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int[] objs1 = LuaScriptMgr.GetArrayNumber<int>(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			obj.CopyTo(arg0,objs1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.CopyTo");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Exists(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
		bool o = obj.Exists(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Find(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
		int o = obj.Find(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
		List<int> o = obj.FindAll(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindIndex(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
			int o = obj.FindIndex(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Predicate<int> arg1 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 3);
			int o = obj.FindIndex(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			Predicate<int> arg2 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 4);
			int o = obj.FindIndex(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.FindIndex");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindLast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
		int o = obj.FindLast(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindLastIndex(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
			int o = obj.FindLastIndex(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Predicate<int> arg1 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 3);
			int o = obj.FindLastIndex(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			Predicate<int> arg2 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 4);
			int o = obj.FindLastIndex(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.FindLastIndex");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ForEach(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Action<int> arg0 = LuaScriptMgr.GetNetObject<Action<int>>(L, 2);
		obj.ForEach(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		List<int>.Enumerator o = obj.GetEnumerator();
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		List<int> o = obj.GetRange(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IndexOf(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = obj.IndexOf(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int o = obj.IndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = obj.IndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.IndexOf");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Insert(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.Insert(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InsertRange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		IEnumerable<int> arg1 = LuaScriptMgr.GetNetObject<IEnumerable<int>>(L, 3);
		obj.InsertRange(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LastIndexOf(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = obj.LastIndexOf(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int o = obj.LastIndexOf(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = obj.LastIndexOf(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.LastIndexOf");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.Remove(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
		int o = obj.RemoveAll(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveAt(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveRange(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.RemoveRange(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Reverse(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			obj.Reverse();
			return 0;
		}
		else if (count == 3)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.Reverse(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.Reverse");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Sort(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(List<int>), typeof(Comparison<int>)};
		Type[] types2 = {typeof(List<int>), typeof(IComparer<int>)};

		if (count == 1)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			obj.Sort();
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			Comparison<int> arg0 = LuaScriptMgr.GetNetObject<Comparison<int>>(L, 2);
			obj.Sort(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			IComparer<int> arg0 = LuaScriptMgr.GetNetObject<IComparer<int>>(L, 2);
			obj.Sort(arg0);
			return 0;
		}
		else if (count == 4)
		{
			List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			IComparer<int> arg2 = LuaScriptMgr.GetNetObject<IComparer<int>>(L, 4);
			obj.Sort(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: List<int>.Sort");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int[] o = obj.ToArray();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TrimExcess(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		obj.TrimExcess();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TrueForAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Predicate<int> arg0 = LuaScriptMgr.GetNetObject<Predicate<int>>(L, 2);
		bool o = obj.TrueForAll(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj[arg0];
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj[arg0] = arg1;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		List<int> obj = LuaScriptMgr.GetNetObject<List<int>>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

