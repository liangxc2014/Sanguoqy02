using UnityEngine;
using System.Collections;
using System;

public class TestLua : MonoBehaviour 
{

    LuaScriptMgr luaMgr;
    Timer timer;

    void Awake ()
    {
        timer = gameObject.AddComponent<Timer>();

        luaMgr = new LuaScriptMgr();
        luaMgr.Start();

        LuaWapBinder.Bind(luaMgr.lua.L);
    }

	// Use this for initialization
	void Start () 
    {
        //luaMgr.DoFile("Lua/Base/Test.Lua");

        luaMgr.DoFile("Lua/UI/StartMenu/StartMenuControl.lua");
        luaMgr.DoFile("Lua/UI/StartMenu/StartMenuView.lua");

        luaMgr.CallLuaFunction("StartMenuControl.Initialize", gameObject);
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
