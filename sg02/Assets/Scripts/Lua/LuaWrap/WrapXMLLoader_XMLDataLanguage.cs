﻿using System;
using System.Reflection;
using System.Collections.Generic;
using LuaInterface;

public class WrapXMLLoader_XMLDataLanguage
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LoadXML", LoadXML),
		new LuaMethod("GetInfoById", GetInfoById),
		new LuaMethod("GetInfoByName", GetInfoByName),
		new LuaMethod("ReflectionFields", ReflectionFields),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Data", get_Data, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "XMLLoader<XMLDataLanguage> class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(XMLLoader<XMLDataLanguage>));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "XMLLoader<XMLDataLanguage>", typeof(XMLLoader<XMLDataLanguage>), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name Data");
		}

		XMLLoader<XMLDataLanguage> obj = (XMLLoader<XMLDataLanguage>)o;
		LuaScriptMgr.PushObject(L, obj.Data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadXML(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		XMLLoader<XMLDataLanguage> obj = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLanguage>>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.LoadXML(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInfoById(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		XMLLoader<XMLDataLanguage> obj = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLanguage>>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		XMLDataLanguage o = obj.GetInfoById(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInfoByName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		XMLLoader<XMLDataLanguage> obj = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLanguage>>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		XMLDataLanguage o = obj.GetInfoByName(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReflectionFields(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		XMLLoader<XMLDataLanguage> obj = LuaScriptMgr.GetNetObject<XMLLoader<XMLDataLanguage>>(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
		IDictionary<string,FieldInfo> o = obj.ReflectionFields(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

