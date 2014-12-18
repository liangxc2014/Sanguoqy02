using UnityEngine;
using System.Collections;

public class SelectKingState : IState
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
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "SelectKingState", "OnEnter");
    }

    public void OnExit()
    {
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "SelectKingState", "OnExit");
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
