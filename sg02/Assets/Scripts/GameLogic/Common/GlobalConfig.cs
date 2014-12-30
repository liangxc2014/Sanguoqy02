using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalConfig 
{
    /// <summary>
    /// 设计像素分辨率规格
    /// </summary>
    public static float DesignScreenWidth { get; private set; }
    public static float DesignScreenHeight { get; private set; }

    /// <summary>
    /// 是否打开 Debug log
    /// </summary>
    public static bool IsDebuggingOpen { get; private set; }

    /// <summary>
    /// 是否是编辑器模式
    /// </summary>
    public static bool IsMapEditorMode { get; private set; }

    /// <summary>
    /// 大地图大小
    /// </summary>
    public static Vector2 MapSize { get; private set; }

    /// <summary>
    /// 字体按钮的间距
    /// </summary>
    public static int FontButtonsVSpace { get; private set; }

    /// <summary>
    /// 人物脸的图片的路径
    /// </summary>
    public static string PathShapeFace { get; private set; }

    /// <summary>
    /// 动画播放的速度
    /// </summary>
    public static float AnimationSpeed { get; private set; }

    /// <summary>
    /// 盗贼势力的旗帜
    /// </summary>
    public static string TroopFlag { get; private set; }

    public static Vector3 FlagOffset1 { get; private set; }
    public static Vector3 FlagOffset2 { get; private set; }
    public static Vector3 FlagOffset3 { get; private set; }
    public static Vector3 FlagOffset4 { get; private set; }

    /// <summary>
    /// 加载全局配置
    /// </summary>
    public static void LoadConfig()
    {
        XMLLoader<XMLDataGlobalConfig> config = new XMLLoader<XMLDataGlobalConfig>(XMLConfigPath.GlobalConfig, "Name");

        IEnumerator enumerator = config.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataGlobalConfig item = (XMLDataGlobalConfig)enumerator.Current;
            switch (item.Name)
            {
                case "DesignScreenResolution":
                    {
                        string[] value = item.Value.Split(',');
                        DesignScreenWidth = System.Convert.ToInt32(value[0]);
                        DesignScreenHeight = System.Convert.ToInt32(value[1]);
                    }
                    break;
                case "IsDebuggingOpen":
                    {
                        IsDebuggingOpen = System.Convert.ToBoolean(item.Value);
                    }
                    break;
                case "IsMapEditorMode":
                    {
                        IsMapEditorMode = System.Convert.ToBoolean(item.Value);
                    }
                    break;
                case "MapSize":
                    {
                        string[] value = item.Value.Split(',');
                        MapSize = new Vector2(System.Convert.ToInt32(value[0]), System.Convert.ToInt32(value[1]));
                    }
                    break;
                case "FontButtonsVSpace":
                    {
                        FontButtonsVSpace = System.Convert.ToInt32(item.Value);
                    }
                    break;
                case "PathShapeFace":
                    {
                        PathShapeFace = item.Value;
                    }
                    break;
                case "AnimationSpeed":
                    {
                        AnimationSpeed = System.Convert.ToSingle(item.Value);
                    }
                    break;
                case "TroopFlag":
                    {
                        TroopFlag = item.Value;
                    }
                    break;
                case "FlagOffset1":
                    {
                        FlagOffset1 = Utility.GetPoint(item.Value);
                    }
                    break;
                case "FlagOffset2":
                    {
                        FlagOffset2 = Utility.GetPoint(item.Value);
                    }
                    break;
                case "FlagOffset3":
                    {
                        FlagOffset3 = Utility.GetPoint(item.Value);
                    }
                    break;
                case "FlagOffset4":
                    {
                        FlagOffset4 = Utility.GetPoint(item.Value);
                    }
                    break;
            }
        }
    }
}
