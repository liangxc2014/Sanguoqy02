using UnityEngine;
using System.Collections;

public class ResourcesManager : Singleton<ResourcesManager>
{


	public override void Initialize()
	{

	}

	public override void UnInitialize()
	{

	}

    public Object Load(string path)
    {

        return Resources.Load(path);
    }

    public T Load<T>(string path) where T : Object
    {
        
        return Resources.Load<T>(path);
    }

    public GameObject LoadUIView(string name, GameObject parent)
    {
        GameObject prefab = Resources.Load<GameObject>(name);

        if (prefab == null)
        {
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
		go.transform.SetParent(parent.transform);
		go.transform.localPosition = Vector3.zero;
		go.transform.localScale = Vector3.one;

        return go;
    }
}
