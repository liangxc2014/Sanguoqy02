using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{

	// Use this for initialization
	void Awake () 
    {
        GlobalConfig.LoadConfig();
        XMLManager.LoadConfigs();

        GamePublic.Instance.Initialize();
        TimerManager.Instance.Initialize();

        ScreenControl.Instance.Initialize(GlobalConfig.DesignScreenWidth, GlobalConfig.DesignScreenHeight);

        EnterState();
	}
	
	// Update is called once per frame
	void Update () 
    {
        GamePublic.Instance.GameStatesManager.Update();
	}

    void OnDestroy ()
    {
        GamePublic.Instance.GameStatesManager.UnInitialize();
        TimerManager.Instance.UnInitialize();
    }

    private void EnterState()
    {
        GamePublic.Instance.GameStatesManager.ChangeState(typeof(StartMenuState).Name);
    }
}
