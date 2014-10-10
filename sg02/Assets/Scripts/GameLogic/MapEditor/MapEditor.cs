using UnityEngine;
using System.Collections;

public class MapEditor : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        InputManager.Instance.Initialize();
        MapCameraControl.Instance.Initialize();
	}
	
	// Update is called once per frame
	void Update () 
    {
        InputManager.Instance.Update();

        OnRightButtonDown();
	}

    void OnDestroy()
    {
        InputManager.Instance.UnInitialize();
        MapCameraControl.Instance.UnInitialize();
    }

    void OnRightButtonDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MapEditorMenuControl.Instance.Initialize();
        }
    }
}
