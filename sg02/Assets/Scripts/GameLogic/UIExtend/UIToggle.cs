using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIToggle : MonoBehaviour 
{
    public Text m_labelNormal;
    public Text m_labelCheck;

    /// <summary>
    /// 开关按钮触发
    /// </summary>
    public void OnToggle(bool state)
    {
        if (state)
        {
            GetComponent<Toggle>().interactable = false;
        }
        else
        {
            GetComponent<Toggle>().interactable = true;
        }

        InputManager.Instance.OnToggle(gameObject, state);
    }

    public void SetGroup(GameObject go)
    {
        if (go == null)
        {
            GetComponent<Toggle>().group = null;
            return;
        }

        ToggleGroup tg = go.GetComponent<ToggleGroup>();

        GetComponent<Toggle>().group = tg;
    }

    public void SetText(string value)
    {
        name = value;
        m_labelNormal.text = value;
        m_labelCheck.text = value;
    }

    public void Toggle(bool state)
    {
        GetComponent<Toggle>().isOn = state;
    }
}
