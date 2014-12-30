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
        IEnumerator enumerator = GamePublic.Instance.DataManager.Citys.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            CityInfo cityInfo = (CityInfo)enumerator.Current;

            string cityPath = "";
            if (cityInfo.Level == 0)
            {
                cityPath = XMLManager.ResourcePath.GetInfoByName("City01").Path;
            }
            else
            {
                cityPath = XMLManager.ResourcePath.GetInfoByName("City03").Path;
            }

            GameObject go = Utility.CreateSceneObject("City" + cityInfo.ID, cityPath);
            if (GamePublic.Instance.CityPoint.ContainsKey(cityInfo.ID))
            {
                go.transform.localPosition = GamePublic.Instance.CityPoint[cityInfo.ID];
            }
            else
            {
                Debugging.LogError("Function:CreateCity; cityID : " + cityInfo.ID);
            }

            if (cityInfo.KingID == 0)
                continue;

            GameObject flag = new GameObject("Flag");
            Utility.SetObjectChild(go, flag);
            if (cityInfo.Level == 0)
            {
                flag.transform.localPosition = GlobalConfig.FlagOffset1;
            }
            else
            {
                flag.transform.localPosition = GlobalConfig.FlagOffset3;
            }
            AnimationComponent ac = flag.AddComponent<AnimationComponent>();

            if (cityInfo.KingID == -1)
            {
                ac.PlayAnimation(GlobalConfig.TroopFlag);
            }
            else
            {
                XMLDataKings kingData = XMLManager.Kings.GetInfoById(cityInfo.KingID);
                ac.PlayAnimation(kingData.FlagAnim);
            }
        }
    }
}
