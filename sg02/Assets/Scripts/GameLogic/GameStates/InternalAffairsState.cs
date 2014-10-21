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
        UIManager.Instance.ShowView(UINamesConfig.InternalAffairs);
    }

    public void OnExit()
    {
        
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
