using UnityEngine;
using System.Collections;

public class StartMenuView : MonoBehaviour 
{

    public GameObject m_btnStartGame;
    public GameObject m_btnLoadGame;
    public GameObject m_btnSetting;
    public GameObject m_btnQuit;

	// Use this for initialization
	void Start () 
    {
        StartMenuControl.Instance.Initialize(this);
	}

    void OnDestroy()
    {
        StartMenuControl.Instance.UnInitialize();
    }
}
