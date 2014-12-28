using System;
using LuaInterface;

public class WrapGamePublic
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
		new LuaField("SceneRoot", get_SceneRoot, null),
		new LuaField("UIRoot", get_UIRoot, null),
		new LuaField("LuaManager", get_LuaManager, null),
		new LuaField("LuaFiles", get_LuaFiles, null),
		new LuaField("DataManager", get_DataManager, null),
		new LuaField("ButtonPool", get_ButtonPool, null),
		new LuaField("TogglePool", get_TogglePool, null),
		new LuaField("TimesList", get_TimesList, null),
		new LuaField("CurrentTimes", get_CurrentTimes, set_CurrentTimes),
		new LuaField("CurrentKing", get_CurrentKing, set_CurrentKing),
		new LuaField("CityPoint", get_CityPoint, null),
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
	static int get_SceneRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name SceneRoot");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.Push(L, obj.SceneRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UIRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name UIRoot");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.Push(L, obj.UIRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaManager(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name LuaManager");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.LuaManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaFiles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name LuaFiles");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.LuaFiles);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DataManager(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name DataManager");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.DataManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ButtonPool(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name ButtonPool");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.ButtonPool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TogglePool(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name TogglePool");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.TogglePool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TimesList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name TimesList");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.TimesList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentTimes(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentTimes");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.Push(L, obj.CurrentTimes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CurrentKing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentKing");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.Push(L, obj.CurrentKing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CityPoint(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CityPoint");
		}

		GamePublic obj = (GamePublic)o;
		LuaScriptMgr.PushObject(L, obj.CityPoint);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrentTimes(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentTimes");
		}

		GamePublic obj = (GamePublic)o;
		obj.CurrentTimes = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CurrentKing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name CurrentKing");
		}

		GamePublic obj = (GamePublic)o;
		obj.CurrentKing = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
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

