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
        UIManager.Instance.ShowView(UINamesConfig.SelectKing);
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
