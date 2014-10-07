using UnityEngine;
using System.Collections;

public class MapCameraControl : Singleton<MapCameraControl>
{
    private Camera m_mapCamera; //地图摄像机

    private float xOffMax;  //X方向上的最大偏移量
    private float yOffMax;  //Y方向上的最大偏移量

    public override void Initialize()
    {
        m_mapCamera = GameObject.Find("MapCamera").GetComponent<Camera>();

        float screenWidth = GlobalConfig.DesignScreenWidth * ScreenControl.Instance.ScaleRatio;
        xOffMax = (GlobalConfig.MapSize.x - screenWidth) / 2 / GlobalConfig.CameraSize;
        yOffMax = (GlobalConfig.MapSize.y - GlobalConfig.DesignScreenHeight) / 2 / GlobalConfig.CameraSize;
        
        InputManager.Instance.AddOnMouseMoveEvent(OnMouseMove);

        InputManager.Instance.SetCamera(m_mapCamera);
    }

    public override void UnInitialize()
    {
        m_mapCamera = null;
        InputManager.Instance.RemoveOnMouseMoveEvent(OnMouseMove);
    }

    private void OnMouseMove(Vector3 delta)
    {
        Vector3 position = m_mapCamera.transform.position;
        position += delta;
        
        position.x = Mathf.Clamp(position.x, -xOffMax, xOffMax);
        position.y = Mathf.Clamp(position.y, -yOffMax, yOffMax);

        m_mapCamera.transform.position = position;
    }
}
