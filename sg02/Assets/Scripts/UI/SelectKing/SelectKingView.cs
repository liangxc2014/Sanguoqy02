using UnityEngine;
using System.Collections;

public class SelectKingView : MonoBehaviour 
{
    public GameObject m_buttonConfirm;
    public GameObject m_buttonCancel;

	// Use this for initialization
	void Start () 
    {
        SelectKingControl.Instance.Initialize(this);
	}
	
	void OnDestroy()
    {
        SelectKingControl.Instance.UnInitialize();
    }
}
