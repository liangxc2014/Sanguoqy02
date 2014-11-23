using System;
using LuaInterface;

public class GameStatesManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Initialize", Initialize),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("StartMenuState", get_StartMenuState, null),
		new LuaField("SelectPeriodState", get_SelectPeriodState, null),
		new LuaField("SelectKingState", get_SelectKingState, null),
		new LuaField("InternalAffairsState", get_InternalAffairsState, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GameStatesManager obj = new GameStatesManager();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GameStatesManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(GameStatesManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "GameStatesManager", typeof(GameStatesManager), regs, fields, "StateManager");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StartMenuState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name StartMenuState");
		}

		GameStatesManager obj = (GameStatesManager)o;
		LuaScriptMgr.PushObject(L, obj.StartMenuState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SelectPeriodState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SelectPeriodState");
		}

		GameStatesManager obj = (GameStatesManager)o;
		LuaScriptMgr.PushObject(L, obj.SelectPeriodState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SelectKingState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SelectKingState");
		}

		GameStatesManager obj = (GameStatesManager)o;
		LuaScriptMgr.PushObject(L, obj.SelectKingState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InternalAffairsState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name InternalAffairsState");
		}

		GameStatesManager obj = (GameStatesManager)o;
		LuaScriptMgr.PushObject(L, obj.InternalAffairsState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameStatesManager obj = LuaScriptMgr.GetNetObject<GameStatesManager>(L, 1);
		obj.Initialize();
		return 0;
	}
}

