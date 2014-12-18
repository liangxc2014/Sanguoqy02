using UnityEngine;
using System.Collections;

public class StartMenuState : IState
{

    public string Name
    {
        get
        {
            return this.GetType().Name;
        }
    }
    public void OnEnter()
    {
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "StartMenuState", "OnEnter");
    }

    public void OnExit()
    {
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "StartMenuState", "OnExit");
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
