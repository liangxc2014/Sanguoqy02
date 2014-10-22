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
        UIManager.Instance.ShowView(UINamesConfig.StartMenu);
    }

    public void OnExit()
    {
        UIManager.Instance.DestroyView(UINamesConfig.StartMenu);
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
