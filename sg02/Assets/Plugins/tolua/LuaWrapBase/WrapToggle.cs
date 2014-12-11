using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

using UnityEngine.UI;
using UI = UnityEngine.UI;
using Events = UnityEngine.Events;
using EventSystems = UnityEngine.EventSystems;

public class WrapToggle
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnPointerClick", OnPointerClick),
		new LuaMethod("OnSubmit", OnSubmit),
		new LuaMethod("IsInteractable", IsInteractable),
		new LuaMethod("FindSelectable", FindSelectable),
		new LuaMethod("FindSelectableOnLeft", FindSelectableOnLeft),
		new LuaMethod("FindSelectableOnRight", FindSelectableOnRight),
		new LuaMethod("FindSelectableOnUp", FindSelectableOnUp),
		new LuaMethod("FindSelectableOnDown", FindSelectableOnDown),
		new LuaMethod("OnMove", OnMove),
		new LuaMethod("OnPointerDown", OnPointerDown),
		new LuaMethod("OnPointerUp", OnPointerUp),
		new LuaMethod("OnPointerEnter", OnPointerEnter),
		new LuaMethod("OnPointerExit", OnPointerExit),
		new LuaMethod("OnSelect", OnSelect),
		new LuaMethod("OnDeselect", OnDeselect),
		new LuaMethod("Select", Select),
		new LuaMethod("IsActive", IsActive),
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
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetInstanceID", GetInstanceID),
		new LuaMethod("ToString", ToString),
		new LuaMethod("GetType", GetType),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("toggleTransition", get_toggleTransition, set_toggleTransition),
		new LuaField("graphic", get_graphic, set_graphic),
		new LuaField("onValueChanged", get_onValueChanged, set_onValueChanged),
		new LuaField("group", get_group, set_group),
		new LuaField("isOn", get_isOn, set_isOn),
		new LuaField("navigation", get_navigation, set_navigation),
		new LuaField("transition", get_transition, set_transition),
		new LuaField("colors", get_colors, set_colors),
		new LuaField("spriteState", get_spriteState, set_spriteState),
		new LuaField("animationTriggers", get_animationTriggers, set_animationTriggers),
		new LuaField("targetGraphic", get_targetGraphic, set_targetGraphic),
		new LuaField("interactable", get_interactable, set_interactable),
		new LuaField("image", get_image, set_image),
		new LuaField("animator", get_animator, null),
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
		LuaDLL.luaL_error(L, "Toggle class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Toggle));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Toggle", typeof(Toggle), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_toggleTransition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name toggleTransition");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushEnum(L, obj.toggleTransition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name graphic");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.graphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onValueChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onValueChanged");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushObject(L, obj.onValueChanged);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name group");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.group);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isOn");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.isOn);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_navigation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name navigation");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushValue(L, obj.navigation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name transition");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushEnum(L, obj.transition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colors(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name colors");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushValue(L, obj.colors);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name spriteState");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushValue(L, obj.spriteState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animationTriggers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name animationTriggers");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushObject(L, obj.animationTriggers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name targetGraphic");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.targetGraphic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_interactable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name interactable");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.interactable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_image(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name image");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.image);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animator(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name animator");
		}

		Toggle obj = (Toggle)o;
		LuaScriptMgr.Push(L, obj.animator);
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
		LuaScriptMgr.PushEnum(L, obj.hideFlags);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_toggleTransition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name toggleTransition");
		}

		Toggle obj = (Toggle)o;
		obj.toggleTransition = LuaScriptMgr.GetNetObject<UnityEngine.UI.Toggle.ToggleTransition>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_graphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name graphic");
		}

		Toggle obj = (Toggle)o;
		obj.graphic = LuaScriptMgr.GetNetObject<UI.Graphic>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onValueChanged(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onValueChanged");
		}

		Toggle obj = (Toggle)o;
		obj.onValueChanged = LuaScriptMgr.GetNetObject<UnityEngine.UI.Toggle.ToggleEvent>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_group(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name group");
		}

		Toggle obj = (Toggle)o;
		obj.group = LuaScriptMgr.GetNetObject<UI.ToggleGroup>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isOn(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name isOn");
		}

		Toggle obj = (Toggle)o;
		obj.isOn = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_navigation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name navigation");
		}

		Toggle obj = (Toggle)o;
		obj.navigation = LuaScriptMgr.GetNetObject<UI.Navigation>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_transition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name transition");
		}

		Toggle obj = (Toggle)o;
		obj.transition = LuaScriptMgr.GetNetObject<UnityEngine.UI.Selectable.Transition>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colors(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name colors");
		}

		Toggle obj = (Toggle)o;
		obj.colors = LuaScriptMgr.GetNetObject<UI.ColorBlock>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name spriteState");
		}

		Toggle obj = (Toggle)o;
		obj.spriteState = LuaScriptMgr.GetNetObject<UI.SpriteState>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_animationTriggers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name animationTriggers");
		}

		Toggle obj = (Toggle)o;
		obj.animationTriggers = LuaScriptMgr.GetNetObject<UI.AnimationTriggers>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetGraphic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name targetGraphic");
		}

		Toggle obj = (Toggle)o;
		obj.targetGraphic = LuaScriptMgr.GetNetObject<UI.Graphic>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_interactable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name interactable");
		}

		Toggle obj = (Toggle)o;
		obj.interactable = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_image(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name image");
		}

		Toggle obj = (Toggle)o;
		obj.image = LuaScriptMgr.GetNetObject<UI.Image>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name useGUILayout");
		}

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
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

		Toggle obj = (Toggle)o;
		obj.hideFlags = LuaScriptMgr.GetNetObject<HideFlags>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		LuaScriptMgr.Push(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.PointerEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.PointerEventData>(L, 2);
		obj.OnPointerClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSubmit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.BaseEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.BaseEventData>(L, 2);
		obj.OnSubmit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInteractable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		bool o = obj.IsInteractable();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		UI.Selectable o = obj.FindSelectable(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnLeft(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		UI.Selectable o = obj.FindSelectableOnLeft();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnRight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		UI.Selectable o = obj.FindSelectableOnRight();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		UI.Selectable o = obj.FindSelectableOnUp();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindSelectableOnDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		UI.Selectable o = obj.FindSelectableOnDown();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnMove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.AxisEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.AxisEventData>(L, 2);
		obj.OnMove(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.PointerEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.PointerEventData>(L, 2);
		obj.OnPointerDown(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.PointerEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.PointerEventData>(L, 2);
		obj.OnPointerUp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.PointerEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.PointerEventData>(L, 2);
		obj.OnPointerEnter(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPointerExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.PointerEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.PointerEventData>(L, 2);
		obj.OnPointerExit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnSelect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.BaseEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.BaseEventData>(L, 2);
		obj.OnSelect(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDeselect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		EventSystems.BaseEventData arg0 = LuaScriptMgr.GetNetObject<EventSystems.BaseEventData>(L, 2);
		obj.OnDeselect(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Select(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		obj.Select();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsActive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		bool o = obj.IsActive();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Invoke(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.Invoke(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeRepeating(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
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
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			obj.CancelInvoke();
			return 0;
		}
		else if (count == 2)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.CancelInvoke(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.CancelInvoke");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInvoking(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			bool o = obj.IsInvoking();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool o = obj.IsInvoking(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.IsInvoking");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(UI.Toggle), typeof(string)};
		Type[] types1 = {typeof(UI.Toggle), typeof(IEnumerator)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			Coroutine o = obj.StartCoroutine(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.StartCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine_Auto(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
		Coroutine o = obj.StartCoroutine_Auto(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(UI.Toggle), typeof(Coroutine)};
		Type[] types1 = {typeof(UI.Toggle), typeof(IEnumerator)};
		Type[] types2 = {typeof(UI.Toggle), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Coroutine arg0 = LuaScriptMgr.GetNetObject<Coroutine>(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			IEnumerator arg0 = LuaScriptMgr.GetNetObject<IEnumerator>(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.StopCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		obj.StopAllCoroutines();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(UI.Toggle), typeof(string)};
		Type[] types1 = {typeof(UI.Toggle), typeof(Type)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component o = obj.GetComponent(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.GetComponent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
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
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInChildren(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInChildren(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.GetComponentsInChildren");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInParent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
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
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponentsInParent(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			Component[] o = obj.GetComponentsInParent(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.GetComponentsInParent");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Component[] o = obj.GetComponents(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			List<Component> arg1 = LuaScriptMgr.GetNetObject<List<Component>>(L, 3);
			obj.GetComponents(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.GetComponents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompareTag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.CompareTag(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessageUpwards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(UI.Toggle), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(UI.Toggle), typeof(string), typeof(object)};

		if (count == 2)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessageUpwards(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessageUpwards(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.SendMessageUpwards(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.SendMessageUpwards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(UI.Toggle), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(UI.Toggle), typeof(string), typeof(object)};

		if (count == 2)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.SendMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.SendMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.SendMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.SendMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BroadcastMessage(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(UI.Toggle), typeof(string), typeof(SendMessageOptions)};
		Type[] types2 = {typeof(UI.Toggle), typeof(string), typeof(object)};

		if (count == 2)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.BroadcastMessage(arg0);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			SendMessageOptions arg1 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.BroadcastMessage(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			SendMessageOptions arg2 = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 4);
			obj.BroadcastMessage(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toggle.BroadcastMessage");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstanceID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		int o = obj.GetInstanceID();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toggle obj = LuaScriptMgr.GetNetObject<Toggle>(L, 1);
		Type o = obj.GetType();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

