using UnityEngine;
using System.Collections;

public class SelectTimesState : IState
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
        UIManager.Instance.ShowView(UINamesConfig.SelectTimes);
    }

    public void OnExit()
    {
        UIManager.Instance.DestroyView(UINamesConfig.SelectTimes);
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
