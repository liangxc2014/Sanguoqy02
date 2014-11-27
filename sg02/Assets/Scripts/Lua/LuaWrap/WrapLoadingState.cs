using System;
using LuaInterface;

public class WrapLoadingState
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnEnter", OnEnter),
		new LuaMethod("OnExit", OnExit),
		new LuaMethod("Update", Update),
		new LuaMethod("IfCanChangeToState", IfCanChangeToState),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Name", get_Name, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LoadingState obj = new LoadingState();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LoadingState.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LoadingState));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "LoadingState", typeof(LoadingState), regs, fields, "IState");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		LoadingState obj = (LoadingState)o;
		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadingState obj = LuaScriptMgr.GetNetObject<LoadingState>(L, 1);
		obj.OnEnter();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadingState obj = LuaScriptMgr.GetNetObject<LoadingState>(L, 1);
		obj.OnExit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LoadingState obj = LuaScriptMgr.GetNetObject<LoadingState>(L, 1);
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IfCanChangeToState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LoadingState obj = LuaScriptMgr.GetNetObject<LoadingState>(L, 1);
		IState arg0 = LuaScriptMgr.GetNetObject<IState>(L, 2);
		bool o = obj.IfCanChangeToState(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

