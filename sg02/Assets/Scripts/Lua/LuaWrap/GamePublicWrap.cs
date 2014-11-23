using System;
using LuaInterface;

public class GamePublicWrap
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
		new LuaField("GameStatesManager", get_GameStatesManager, null),
		new LuaField("SceneCamera", get_SceneCamera, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GamePublic obj = new GamePublic();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GamePublic.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(GamePublic));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "GamePublic", typeof(GamePublic), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, GamePublic.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameStatesManager(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name GameStatesManager");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.GameStatesManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SceneCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SceneCamera");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.Push(L, obj.SceneCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
			obj.Initialize();
			return 0;
		}
		else if (count == 2)
		{
			GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			obj.Initialize(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GamePublic.Initialize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnInitialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
		obj.UnInitialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GamePublic obj = LuaScriptMgr.GetNetObject<GamePublic>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

