using UnityEngine;
using System;
using System.Collections.Generic;
using LuaInterface;

public class ComponentWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetComponent", GetComponent),
		new LuaMethod("GetComponentInChildren", GetComponentInChildren),
		new LuaMethod("GetComponentsInChildren", GetComponentsInChildren),
		new LuaMethod("GetComponentInParent", GetComponentInParent),
		new LuaMethod("GetComponentsInParent", GetComponentsInParent),
		new LuaMethod("GetComponents", GetComponents),
		new LuaMethod("CompareTag", CompareTag),
		new LuaMethod("SendMessageUpwards", SendMessageUpwards),
		new LuaMethod("SendMessage", SendMessage),
		new LuaMethod("BroadcastMessage", BroadcastMessage),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("transform", get_transform, null),
		new LuaField("gameObject", get_gameObject, null),
		new LuaField("tag", get_tag, set_tag),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Component obj = new Component();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Component));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Component", typeof(Component), regs, fields, "Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name transform");
		}

		Component obj = (Component)o;
		LuaScriptMgr.Push(L, obj.transform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name gameObject");
		}

		Component obj = (Component)o;
		LuaScriptMgr.Push(L, obj.gameObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name tag");
		}

		Component obj = (Component)o;
		LuaScriptMgr.Push(L, obj.tag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name tag");
		}

		Component obj = (Component)o;
		obj.tag = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Component), typeof(string)};
		Type[] types1 = {typeof(Component), typeof(Type)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		Component o = obj.GetComponentInChildren(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInChildren(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInChildren(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponentsInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		Component o = obj.GetComponentInParent(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInParent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInParent(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInParent(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponentsInParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponents(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			List<Component> arg1 = LuaScriptMgr.GetNetObject<List<Component>>(L, 3);
			obj.GetComponents(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.GetComponents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.CompareTag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Component), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(Component), typeof(string), typeof(object)};

		if (count == 2)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessageUpwards(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.SendMessageUpwards(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.SendMessageUpwards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Component), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(Component), typeof(string), typeof(object)};

		if (count == 2)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.SendMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.SendMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Component), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(Component), typeof(string), typeof(object)};

		if (count == 2)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.BroadcastMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Component obj = LuaScriptMgr.GetNetObject<Component>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.BroadcastMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Component.BroadcastMessage");
		}

		return 0;
	}
}

