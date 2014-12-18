using UnityEngine;
using System.Collections;

public class InternalAffairsState : IState
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
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "InternalAffairsState", "OnEnter");
    }

    public void OnExit()
    {
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "InternalAffairsState", "OnExit");
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
