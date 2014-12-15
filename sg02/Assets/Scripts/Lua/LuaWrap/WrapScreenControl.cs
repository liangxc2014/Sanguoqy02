using System;
using LuaInterface;

public class WrapScreenControl
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
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
		new LuaField("Instance", get_Instance, null),
		new LuaField("ScreenAspectRatio", get_ScreenAspectRatio, null),
		new LuaField("DesignAspect", get_DesignAspect, null),
		new LuaField("ScaleRatio", get_ScaleRatio, null),
		new LuaField("FunctionRatio", get_FunctionRatio, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ScreenControl obj = new ScreenControl();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ScreenControl.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ScreenControl));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "ScreenControl", typeof(ScreenControl), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, ScreenControl.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ScreenAspectRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ScreenAspectRatio");
		}

		ScreenControl obj = (ScreenControl)o;
		LuaScriptMgr.Push(L, obj.ScreenAspectRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DesignAspect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name DesignAspect");
		}

		ScreenControl obj = (ScreenControl)o;
		LuaScriptMgr.Push(L, obj.DesignAspect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ScaleRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ScaleRatio");
		}

		ScreenControl obj = (ScreenControl)o;
		LuaScriptMgr.Push(L, obj.ScaleRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FunctionRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name FunctionRatio");
		}

		ScreenControl obj = (ScreenControl)o;
		LuaScriptMgr.Push(L, obj.FunctionRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
			obj.Initialize();
			return 0;
		}
		else if (count == 2)
		{
			ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			obj.Initialize(arg0);
			return 0;
		}
		else if (count == 3)
		{
			ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.Initialize(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ScreenControl.Initialize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ScreenControl obj = LuaScriptMgr.GetNetObject<ScreenControl>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

