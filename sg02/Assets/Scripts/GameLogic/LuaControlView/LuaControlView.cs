﻿using UnityEngine;
using System.Collections;

public class LuaControlView : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        XMLDataLuaControlView info = XMLManager.LuaControlView.GetInfoById(name);

        if (info != null)
        {
            GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", info.LuaName, "Initialize", gameObject);
        }
        else
        {
            Debugging.LogError("Function: LuaControlView. LuaModule is not Find! name = " + name);
        }
	}
}