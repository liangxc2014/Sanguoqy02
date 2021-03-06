﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class WrapAnimationComponent
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("PlayAnimation", PlayAnimation),
		new LuaMethod("Pause", Pause),
		new LuaMethod("Resume", Resume),
		new LuaMethod("Invoke", Invoke),
		new LuaMethod("InvokeRepeating", InvokeRepeating),
		new LuaMethod("CancelInvoke", CancelInvoke),
		new LuaMethod("IsInvoking", IsInvoking),
		new LuaMethod("StartCoroutine", StartCoroutine),
		new LuaMethod("StartCoroutine_Auto", StartCoroutine_Auto),
		new LuaMethod("StopCoroutine", StopCoroutine),
		new LuaMethod("StopAllCoroutines", StopAllCoroutines),
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
		new LuaMethod("ToString", ToString),
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetInstanceID", GetInstanceID),
		new LuaMethod("GetType", GetType),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("animName", get_animName, null),
		new LuaField("isPlaying", get_isPlaying, null),
		new LuaField("isPause", get_isPause, null),
		new LuaField("animIndex", get_animIndex, null),
		new LuaField("useGUILayout", get_useGUILayout, set_useGUILayout),
		new LuaField("enabled", get_enabled, set_enabled),
		new LuaField("transform", get_transform, null),
		new LuaField("gameObject", get_gameObject, null),
		new LuaField("tag", get_tag, set_tag),
		new LuaField("name", get_name, set_name),
		new LuaField("hideFlags", get_hideFlags, set_hideFlags),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnimationComponent obj = new AnimationComponent();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnimationComponent));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "AnimationComponent", typeof(AnimationComponent), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name animName");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.animName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isPlaying");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isPause");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.isPause);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animIndex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name animIndex");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.animIndex);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name useGUILayout");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.useGUILayout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name enabled");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name transform");
		}

		AnimationComponent obj = (AnimationComponent)o;
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

		AnimationComponent obj = (AnimationComponent)o;
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

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.tag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name name");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.Push(L, obj.name);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hideFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name hideFlags");
		}

		AnimationComponent obj = (AnimationComponent)o;
		LuaScriptMgr.PushEnum(L, obj.hideFlags);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name useGUILayout");
		}

		AnimationComponent obj = (AnimationComponent)o;
		obj.useGUILayout = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name enabled");
		}

		AnimationComponent obj = (AnimationComponent)o;
		obj.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name tag");
		}

		AnimationComponent obj = (AnimationComponent)o;
		obj.tag = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_name(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name name");
		}

		AnimationComponent obj = (AnimationComponent)o;
		obj.name = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hideFlags(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name hideFlags");
		}

		AnimationComponent obj = (AnimationComponent)o;
		obj.hideFlags = LuaScriptMgr.GetNetObject<HideFlags>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayAnimation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(AnimationComponent), typeof(string), typeof(LuaInterface.LuaFunction)};
		Type[] types2 = {typeof(AnimationComponent), typeof(string), typeof(CallBack.CallBackDelegate)};

		if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.PlayAnimation(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
			obj.PlayAnimation(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			CallBack.CallBackDelegate arg1 = LuaScriptMgr.GetNetObject<CallBack.CallBackDelegate>(L, 3);
			obj.PlayAnimation(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.PlayAnimation");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		obj.Pause();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Resume(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		obj.Resume();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Invoke(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.Invoke(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeRepeating(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.InvokeRepeating(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelInvoke(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			obj.CancelInvoke();
			return 0;
		}
		else if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.CancelInvoke(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.CancelInvoke");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInvoking(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			bool o = obj.IsInvoking();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool o = obj.IsInvoking(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.IsInvoking");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(AnimationComponent), typeof(string)};
		Type[] types1 = {typeof(AnimationComponent), typeof(IEnumerator)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			Coroutine o = obj.StartCoroutine(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.StartCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine_Auto(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
		Coroutine o = obj.StartCoroutine_Auto(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(AnimationComponent), typeof(Coroutine)};
		Type[] types1 = {typeof(AnimationComponent), typeof(IEnumerator)};
		Type[] types2 = {typeof(AnimationComponent), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Coroutine arg0 = LuaScriptMgr.GetNetObject<Coroutine>(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.StopCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		obj.StopAllCoroutines();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(AnimationComponent), typeof(string)};
		Type[] types1 = {typeof(AnimationComponent), typeof(Type)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.GetComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
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
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInChildren(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInChildren(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.GetComponentsInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
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
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInParent(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInParent(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.GetComponentsInParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponents(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			List<Component> arg1 = LuaScriptMgr.GetNetObject<List<Component>>(L, 3);
			obj.GetComponents(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.GetComponents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.CompareTag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(AnimationComponent), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(AnimationComponent), typeof(string), typeof(object)};

		if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessageUpwards(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.SendMessageUpwards(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.SendMessageUpwards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(AnimationComponent), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(AnimationComponent), typeof(string), typeof(object)};

		if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.SendMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.SendMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(AnimationComponent), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(AnimationComponent), typeof(string), typeof(object)};

		if (count == 2)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.BroadcastMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.BroadcastMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationComponent.BroadcastMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstanceID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		int o = obj.GetInstanceID();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AnimationComponent obj = LuaScriptMgr.GetNetObject<AnimationComponent>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

