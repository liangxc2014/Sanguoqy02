using UnityEngine;
using System.Collections;

public class MapCameraControl : Singleton<MapCameraControl>
{
    private float xOffMax;  //X方向上的最大偏移量
    private float yOffMax;  //Y方向上的最大偏移量

    public override void Initialize()
    {
        ScreenControl.Instance.Initialize();

        float screenWidth = GlobalConfig.DesignScreenWidth * ScreenControl.Instance.ScaleRatio;
        xOffMax = (GlobalConfig.MapSize.x - screenWidth) / 2;
        yOffMax = (GlobalConfig.MapSize.y - GlobalConfig.DesignScreenHeight) / 2;
        
        InputManager.Instance.AddOnMouseMoveEvent(OnMouseMove);
    }

    public override void UnInitialize()
    {
        InputManager.Instance.RemoveOnMouseMoveEvent(OnMouseMove);
    }

    private void OnMouseMove(Vector3 delta)
    {
        Vector3 position = GamePublic.Instance.SceneCamera.transform.position;
        position += delta;
        
        position.x = Mathf.Clamp(position.x, -xOffMax, xOffMax);
        position.y = Mathf.Clamp(position.y, -yOffMax, yOffMax);

        GamePublic.Instance.SceneCamera.transform.position = position;
    }
}
