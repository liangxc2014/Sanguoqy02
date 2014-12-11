using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIButton : MonoBehaviour 
{
    public bool IsPush { get; set; }

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
        name = value;
        GetComponent<Text>().text = value;
    }
}
