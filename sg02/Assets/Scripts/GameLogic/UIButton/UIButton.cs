using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        InputManager.Instance.OnClick(gameObject);
    }

    public void OnPressDown()
    {
        InputManager.Instance.OnPress(gameObject, true);
    }

    public void SetText(string value)
    {
        GetComponent<Text>().text = value;
    }
}
