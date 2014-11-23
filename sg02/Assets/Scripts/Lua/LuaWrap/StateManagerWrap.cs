using System;
using LuaInterface;

public class StateManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("UnInitialize", UnInitialize),
		new LuaMethod("AddState", AddState),
		new LuaMethod("ContainsState", ContainsState),
		new LuaMethod("RemoveState", RemoveState),
		new LuaMethod("GetState", GetState),
		new LuaMethod("ChangeState", ChangeState),
		new LuaMethod("Update", Update),
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
		new LuaField("CurrentState", get_CurrentState, set_CurrentState),
		new LuaField("OldState", get_OldState, set_OldState),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "StateManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(StateManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "StateManager", typeof(StateManager), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentState");
		}

		StateManager obj = (StateManager)o;
		LuaScriptMgr.PushObject(L, obj.CurrentState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OldState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name OldState");
		}

		StateManager obj = (StateManager)o;
		LuaScriptMgr.PushObject(L, obj.OldState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrentState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentState");
		}

		StateManager obj = (StateManager)o;
		obj.CurrentState = LuaScriptMgr.GetNetObject<IState>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OldState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name OldState");
		}

		StateManager obj = (StateManager)o;
		obj.OldState = LuaScriptMgr.GetNetObject<IState>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
			obj.Initialize();
			return 0;
		}
		else if (count == 2)
		{
			StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			obj.Initialize(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: StateManager.Initialize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		IState arg0 = LuaScriptMgr.GetNetObject<IState>(L, 2);
		obj.AddState(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.ContainsState(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.RemoveState(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		IState o = obj.GetState(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ChangeState(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(StateManager), typeof(IState)};
		Type[] types1 = {typeof(StateManager), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
			IState arg0 = LuaScriptMgr.GetNetObject<IState>(L, 2);
			obj.ChangeState(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.ChangeState(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: StateManager.ChangeState");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		StateManager obj = LuaScriptMgr.GetNetObject<StateManager>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

