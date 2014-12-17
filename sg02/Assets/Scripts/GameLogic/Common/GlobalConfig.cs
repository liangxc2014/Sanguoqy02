using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalConfig 
{
    /// <summary>
    /// 加载全局配置
    /// </summary>
    public static void LoadConfig()
    {
        XMLLoader<XMLDataGlobalConfig> config = new XMLLoader<XMLDataGlobalConfig>(XMLConfigPath.GlobalConfig);

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
                case "MapSize":
                    {
                        string[] value = item.Value.Split(',');
                        MapSize = new Vector2(System.Convert.ToInt32(value[0]), System.Convert.ToInt32(value[1]));
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 设计像素分辨率规格
    /// </summary>
    public static float DesignScreenWidth { get; private set; }
    public static float DesignScreenHeight { get; private set; }

    /// <summary>
    /// 是否打开 Debug log
    /// </summary>
    public static bool IsDebuggingOpen { get { return true; } }

    /// <summary>
    /// 是否是编辑器模式
    /// </summary>
    public static bool IsMapEditorMode { get { return false; } }

    /// <summary>
    /// 大地图大小
    /// </summary>
    public static Vector2 MapSize { get; private set; }

    /// <summary>
    /// 字体按钮的间距
    /// </summary>
    public static int FontButtonsVSpace { get { return -28; } }

    /// <summary>
    /// 人物脸的图片的路径
    /// </summary>
    public static string PathShapeFace { get { return "Shape/FACE/"; } }
}
