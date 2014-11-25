using UnityEngine;
using System.Collections;

public class StartMenuControl : Singleton<StartMenuControl> 
{
    private StartMenuView m_view; //视图类

    public override void Initialize(object owner)
    {
        m_view = (StartMenuView)owner;

        //InitButtonsEvent();
    }

    private void InitButtonsEvent()
    {
        InputManager.Instance.AddOnClickEvent(m_view.m_btnStartGame, OnStartGameButton);
        InputManager.Instance.AddOnClickEvent(m_view.m_btnLoadGame, OnLoadGameButton);
        InputManager.Instance.AddOnClickEvent(m_view.m_btnSetting, OnSettingsButton);
        InputManager.Instance.AddOnClickEvent(m_view.m_btnQuit, OnQuitButton);
    }

    #region 按钮响应

    private void OnStartGameButton(GameObject go)
    {
        GamePublic.Instance.GameStatesManager.ChangeState(GamePublic.Instance.GameStatesManager.SelectPeriodState);
    }

    private void OnLoadGameButton(GameObject go)
    {
        UIManager.Instance.ShowView(UINamesConfig.LoadgameMenu);
    }

    private void OnSettingsButton(GameObject go)
    {

    }

    private void OnQuitButton(GameObject go)
    {
        Application.Quit();
    }

    #endregion
}
