using UnityEngine;
using System.Collections;

public class MapEditorMenuView : MonoBehaviour 
{
    public GameObject m_btnAddCity;

	// Use this for initialization
	void Start () 
    {
        MapEditorMenuControl.Instance.Initialize(this);
	}


}
