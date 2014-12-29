using System;
using LuaInterface;

public class WrapXMLDataAnimations
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Name", get_Name, set_Name),
		new LuaField("Speed", get_Speed, set_Speed),
		new LuaField("Loop", get_Loop, set_Loop),
		new LuaField("NextAnim", get_NextAnim, set_NextAnim),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "XMLDataAnimations class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(XMLDataAnimations));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "XMLDataAnimations", typeof(XMLDataAnimations), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		LuaScriptMgr.Push(L, obj.Name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Speed");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		LuaScriptMgr.Push(L, obj.Speed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Loop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Loop");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		LuaScriptMgr.Push(L, obj.Loop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NextAnim(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name NextAnim");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		LuaScriptMgr.Push(L, obj.NextAnim);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Name");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		obj.Name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Speed");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		obj.Speed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Loop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Loop");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		obj.Loop = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_NextAnim(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name NextAnim");
		}

		XMLDataAnimations obj = (XMLDataAnimations)o;
		obj.NextAnim = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}

