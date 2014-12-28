using UnityEngine;
using System.Collections;

public class WorldMapControl : Singleton<WorldMapControl>
{

    // 进入时摄像机的偏移
    public Vector3 CameraOffset { get; set; }

    public override void Initialize()
    {
        Build();

        MapCameraControl.Instance.Initialize();

        GamePublic.Instance.SceneCamera.transform.localPosition = CameraOffset;
    }

    public override void UnInitialize()
    {
        MapCameraControl.Instance.UnInitialize();
    }

    public void Build()
    {
        CreateMap();
        CreateCity();
    }

    private void CreateMap()
    {
        GameObject go = Utility.CreateSceneObject("Map", XMLManager.ResourcePath.GetInfoByName("Map").Path);
        go.transform.localPosition = new Vector3(0, 0, 10);
    }

    private void CreateCity()
    {
        IEnumerator enumerator = XMLManager.City.Data.Values.GetEnumerator();

        while (enumerator.MoveNext())
        {
            XMLDataCity data = (XMLDataCity)enumerator.Current;

            string cityPath = "";
            if (data.Level == 0)
            {
                cityPath = XMLManager.ResourcePath.GetInfoByName("City01").Path;
            }
            else
            {
                cityPath = XMLManager.ResourcePath.GetInfoByName("City03").Path;
            }

            GameObject go = Utility.CreateSceneObject("City" + data.ID, cityPath);
            if (GamePublic.Instance.CityPoint.ContainsKey(data.ID))
            {
                go.transform.localPosition = GamePublic.Instance.CityPoint[data.ID];
            }
            else
            {
                Debugging.LogError("Function:CreateCity; cityID : " + data.ID);
            }
        }
    }
}
