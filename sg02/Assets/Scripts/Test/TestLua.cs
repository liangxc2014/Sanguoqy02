using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TestLua : MonoBehaviour 
{

    LuaScriptMgr luaMgr;
    Timer timer;

//     void Awake ()
//     {
// 
//         luaMgr = new LuaScriptMgr();
//         luaMgr.Start();
// 
//         LuaWapBinder.Bind(luaMgr.lua.L);
//     }

	// Use this for initialization
	void Start () 
    {
        timer = gameObject.AddComponent<Timer>();
        luaMgr = GamePublic.Instance.LuaManager;

        //luaMgr.DoFile("Lua/Base/Test.Lua");

//         luaMgr.DoFile("Lua/UI/StartMenu/StartMenuControl.lua");
//         luaMgr.DoFile("Lua/UI/StartMenu/StartMenuView.lua");
// 
//         luaMgr.CallLuaFunction("StartMenuControl.Initialize", GameObject.Find("UI Root/StartMenu(Clone)"));
// 
//         Type t = typeof(XMLLoader<XMLDataArms>);
//         Debug.Log(t.IsGenericType);
//         Debug.Log(t.Name);

        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);

        luaMgr.CallLuaFunction("TestLua.TestList", list);
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer.OnUpdate(Time.deltaTime);
	}

    public void CallFunction(string name, object args)
    {
        luaMgr.CallLuaFunction(name, args);
    }

    public void RegisterLuaDelegateType(Type delegateType, Type luaDelegateType)
    {
        //luaMgr.lua.RegisterLuaDelegateType(delegateType, luaDelegateType);
    }
}
