using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationComponent : MonoBehaviour 
{

    public string animName { get; private set; }
    public bool isPlaying { get; private set; }
    public bool isPause { get; private set; }
    public int animIndex { get; private set; }

    private List<Sprite> m_listSprite;
    private XMLDataAnimations m_animData;

    private CallBack.CallBackDelegate m_animCompleteEvent; //动画播放结束时回调
    private LuaInterface.LuaFunction m_animCompleteEventLua;

    private float m_timeTick;
    private SpriteRenderer m_spriteRenderer;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isPlaying)
            return;

        m_timeTick += Time.deltaTime * m_animData.Speed;
        if (m_timeTick >= GlobalConfig.AnimationSpeed)
        {
            m_timeTick = 0;
            animIndex++;
            if (animIndex >= m_listSprite.Count)
            {
                animIndex = 0;

                if (m_animData.Loop == 0)
                {
                    if (m_animCompleteEvent != null)
                    {
                        m_animCompleteEvent();
                        //m_animCompleteEvent = null;
                        PlayAnimation(m_animData.NextAnim, m_animCompleteEvent);
                    }
                        
                    if (m_animCompleteEventLua != null)
                    {
                        m_animCompleteEventLua.Call();
                        //m_animCompleteEventLua = null;
                        PlayAnimation(m_animData.NextAnim, m_animCompleteEventLua);
                    }
                }
                else
                {
                    m_spriteRenderer.sprite = m_listSprite[animIndex];
                }
            }
            else
            {
                m_spriteRenderer.sprite = m_listSprite[animIndex];
            }
        }
	}

    public void PlayAnimation(string animName)
    {
        if (string.IsNullOrEmpty(animName))
            return;

        if (!XMLManager.Animations.Data.ContainsKey(animName))
            return;

        m_listSprite = new List<Sprite>();
        m_animData = XMLManager.Animations.GetInfoByName(animName);

        TextAsset ta = ResourcesManager.Instance.Load<TextAsset>(animName);
        if (ta == null)
        {
            Debugging.LogError("PlayAnimation: animName = " + animName);
            return;
        }

        string[] spritePaths = ta.text.Trim().Split('\n');
        for (int i = 0; i < spritePaths.Length; i++)
        {
            string path = spritePaths[i].Trim();
            Sprite sprite = ResourcesManager.Instance.Load<Sprite>(path);
            if (sprite == null)
            {
                m_listSprite.Clear();
                Debugging.LogError("PlayAnimation: animName = " + animName + ", spritePath = " + path);
                continue;
            }
            m_listSprite.Add(sprite);
        }
        if (m_listSprite.Count == 0)
        {
            Debugging.LogError("PlayAnimation: animName = " + animName);
            return;
        }

        this.animName = animName;
        this.isPlaying = true;
        this.isPause = false;
        m_animCompleteEvent = null;
        m_timeTick = 0;
        this.animIndex = 0;

        if (m_spriteRenderer == null)
            m_spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        m_spriteRenderer.sprite = m_listSprite[animIndex];
    }

    public void PlayAnimation(string animName, CallBack.CallBackDelegate animCompleteEvent)
    {
        PlayAnimation(animName);

        m_animCompleteEvent = animCompleteEvent;
    }

    public void PlayAnimation(string animName, LuaInterface.LuaFunction animCompleteEvent)
    {
        PlayAnimation(animName);

        m_animCompleteEventLua = animCompleteEvent;
    }
    public void Pause()
    {
        isPause = true;
        isPlaying = false;
    }

    public void Resume()
    {
        isPause = false;
        isPlaying = true;
    }
}
