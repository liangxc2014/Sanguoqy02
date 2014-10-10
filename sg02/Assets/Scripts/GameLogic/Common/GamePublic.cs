using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePublic : Singleton<GamePublic>
{
    /// <summary>
    /// 状态机管理
    /// </summary>
    private GameStatesManager m_gameStatesManager;
    public GameStatesManager GameStatesManager { get { return m_gameStatesManager; } }

    /// <summary>
    /// 场景摄像机
    /// </summary>
    private Camera m_sceneCamera;
    public Camera SceneCamera { get { return m_sceneCamera; } }

    private Camera m_uiCamera;
    public Camera UICamera { get { return m_uiCamera; } }

    public override void Initialize() 
    {
        m_gameStatesManager = new GameStatesManager();
        m_gameStatesManager.Initialize();

        m_sceneCamera = GameObject.FindGameObjectWithTag("SceneCamera").GetComponent<Camera>();
        m_uiCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
    }

    public override void UnInitialize() 
    {
        
    }
}
