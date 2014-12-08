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
        GamePublic.Instance.DataManager.InitDataManager();

        UIManager.Instance.ShowView(UINamesConfig.SelectKing);
    }

    public void OnExit()
    {
        UIManager.Instance.DestroyView(UINamesConfig.SelectKing);
    }

    public void Update()
    {

    }

    public bool IfCanChangeToState(IState state)
    {
        return true;
    }
}
