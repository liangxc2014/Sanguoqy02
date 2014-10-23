using UnityEngine;
using System.Collections;

public class SelectPeriodControl : Singleton<SelectPeriodControl>
{
    private SelectPeriodView m_view;


    public override void Initialize(object owner)
    {
        m_view = (SelectPeriodView)owner;

        InitButtonsEvent();
    }

    public override void UnInitialize()
    {
        
    }

    private void InitButtonsEvent()
    {
        for (int i = 0; i < m_view.m_buttons.Length; i++)
        {
            InputManager.Instance.AddOnClickEvent(m_view.m_buttons[i], OnButtonClick);
        }
    }

    private void OnButtonClick(GameObject go)
    {
        GamePublic.Instance.GameStatesManager.ChangeState(GamePublic.Instance.GameStatesManager.SelectKingState);
    }
}
