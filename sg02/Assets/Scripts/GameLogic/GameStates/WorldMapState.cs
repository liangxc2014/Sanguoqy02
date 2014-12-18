using UnityEngine;
using System.Collections;

public class WorldMapState : IState
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
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "WorldMapState", "OnEnter");
    }

    public void OnExit()
    {
        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "WorldMapState", "OnExit");
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
