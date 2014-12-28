using UnityEngine;
using System.Collections;

public class AnimationComponent : MonoBehaviour 
{

    public string animName { get; set; }
    public bool isPlaying { get; set; }

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void PlayAnimation(string animName)
    {
        this.animName = animName;
        this.isPlaying = true;


    }
}
