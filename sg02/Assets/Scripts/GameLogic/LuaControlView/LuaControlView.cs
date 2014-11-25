using UnityEngine;
using System.Collections;

public class LuaControlView : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        XMLDataLuaControlView info = XMLManager.LuaControlView.GetInfoById(name);
        if (info != null)
        {
            GamePublic.Instance.LuaManager.CallLuaFunction(info.LuaName + ".Initialize", gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
