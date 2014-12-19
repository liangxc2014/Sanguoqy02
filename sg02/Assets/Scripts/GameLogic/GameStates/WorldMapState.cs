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
        WorldMapControl.Instance.Initialize();

        GamePublic.Instance.LuaManager.CallLuaFunction("LuaFunctionHelper.CallFunction", "WorldMapState", "OnEnter");
    }

    public void OnExit()
    {
        WorldMapControl.Instance.UnInitialize();

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
