using UnityEngine;
using System.Collections;

public class SelectPeriodView : MonoBehaviour 
{

    public GameObject[] m_buttons;

	// Use this for initialization
	void Start () 
    {
        SelectPeriodControl.Instance.Initialize(this);
	}
	
	void OnDestroy()
    {
        SelectPeriodControl.Instance.UnInitialize();
    }
}
