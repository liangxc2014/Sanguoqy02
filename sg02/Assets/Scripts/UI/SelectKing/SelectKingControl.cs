using UnityEngine;
using System.Collections;

public class SelectKingControl : Singleton<SelectKingControl>
{
    private SelectKingView m_view;

    public override void Initialize(object owner)
    {
        m_view = (SelectKingView)owner;

        InitButtonEvent();
    }

    public override void UnInitialize()
    {
        
    }

    private void InitButtonEvent()
    {
        InputManager.Instance.AddOnClickEvent(m_view.m_buttonConfirm, OnButtonConfirm);
    }

    private void OnButtonConfirm(GameObject go)
    {
        GamePublic.Instance.GameStatesManager.ChangeState(GamePublic.Instance.GameStatesManager.InternalAffairsState);
    }
}
