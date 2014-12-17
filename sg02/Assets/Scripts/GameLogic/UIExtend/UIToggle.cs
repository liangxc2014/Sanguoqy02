using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UIToggle : MonoBehaviour 
{
    private Text m_labelNormal;
    private Text m_labelCheck;

    void Awake ()
    {
        if (m_labelNormal == null)
            m_labelNormal = transform.FindChild("LabelNormal").GetComponent<Text>();
        if (m_labelCheck == null)
            m_labelCheck = transform.FindChild("LabelCheck").GetComponent<Text>();
    }

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
        Awake();
        
        name = value;
        m_labelNormal.text = value;
        m_labelCheck.text = value;
    }

    public void Toggle(bool state)
    {
        GetComponent<Toggle>().isOn = state;
    }
}
