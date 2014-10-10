using UnityEngine;
using System.Collections;

public class MapEditorMenuControl : Singleton<MapEditorMenuControl>
{
    private MapEditorMenuView m_viewPanel;

    public override void Initialize()
    {
        if (m_viewPanel != null)
        {
            m_viewPanel.gameObject.SetActive(true);

            InputManager.Instance.AddOnClickEvent(m_viewPanel.m_btnAddCity, OnAddCityButton);
        }
    }

    public override void Initialize(object owner)
    {
        if (m_viewPanel == null)
        {
            m_viewPanel = (MapEditorMenuView)owner;
            m_viewPanel.gameObject.SetActive(false);
        }
    }

    public override void UnInitialize()
    {
        m_viewPanel.gameObject.SetActive(false);

        InputManager.Instance.RemoveClickEvent(m_viewPanel.m_btnAddCity);
    }

    private void OnAddCityButton(GameObject go)
    {
        UnInitialize();
    }
}
