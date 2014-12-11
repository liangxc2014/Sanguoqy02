using System;
using LuaInterface;

public class WrapUIButton
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnClick", OnClick),
		new LuaMethod("OnPressDown", OnPressDown),
		new LuaMethod("SetText", SetText),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("IsPush", get_IsPush, set_IsPush),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIButton class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(UIButton));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UIButton", typeof(UIButton), regs, fields, "MonoBehaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsPush(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsPush");
		}

		UIButton obj = (UIButton)o;
		LuaScriptMgr.Push(L, obj.IsPush);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsPush(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name IsPush");
		}

		UIButton obj = (UIButton)o;
		obj.IsPush = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIButton obj = LuaScriptMgr.GetNetObject<UIButton>(L, 1);
		obj.OnClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPressDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIButton obj = LuaScriptMgr.GetNetObject<UIButton>(L, 1);
		obj.OnPressDown();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton obj = LuaScriptMgr.GetNetObject<UIButton>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SetText(arg0);
		return 0;
	}
}

