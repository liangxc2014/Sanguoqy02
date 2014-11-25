using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Reflection;
using System.Linq;

public static class Utility 
{	
	/// <summary>
	/// 获取本地IP地址;
	/// </summary>
	/// <returns>The IP address.</returns>
	public static string GetIPAddress()
	{
		return UnityEngine.Network.player.ipAddress;
	}

	/// <summary>
	/// 判断点是否在多边形内;
	/// </summary>
	public static bool PointInPolygon(Vector2 p, List<Vector2> ptPolygon)
	{
		int nCount = ptPolygon.Count;
		int nCross = 0;

		for (int i=0; i<nCount; i++)
		{
			Vector2 p1 = ptPolygon[i];
			Vector2 p2 = ptPolygon[(i + 1) % nCount];

			if ( p1.y == p2.y )
				continue;

			if ( p.y < Mathf.Min(p1.y, p2.y) )
				continue;
			if ( p.y >= Mathf.Max(p1.y, p2.y) )
				continue;

			double x = (double)(p.y - p1.y) * (double)(p2.x - p1.x) / (double)(p2.y - p1.y) + p1.x;

			if ( x > p.x )
				nCross++;
		}

		return (nCross % 2 == 1);
	}

    /// <summary>
    /// 根据Key值找Value值
    /// </summary>
    public static TKey FindKeysFromValue<TKey, TValue>(Dictionary<TKey, TValue> dic, TValue value)
    {
        if (dic == null || !dic.ContainsValue(value))
            return default(TKey);

        TKey key = dic.FirstOrDefault(pair => pair.Value.Equals(value)).Key;
        return key;
    }

    /// <summary>
    /// 根据字符串找出一个Vector3
    /// </summary>
    public static Vector3 GetPoint(string pointString)
    {
        string[] pointInfo = pointString.Split(',');

        if (pointInfo.Length < 2)
        {
            return Vector3.zero;
        }

        Vector3 point = new Vector3();
        if (pointInfo[0] != "")
        {
            point.x = System.Convert.ToInt32(pointInfo[0]);
        }
        if (pointInfo[1] != "")
        {
            point.y = System.Convert.ToInt32(pointInfo[1]);
        }
        if (pointInfo.Length >= 3 && pointInfo[2] != "")
        {
            point.z = System.Convert.ToInt32(pointInfo[2]);
        }

        return point;
    }

    /// <summary>
    /// 因为Unity5已经去掉了AddComponent(string)函数,所以添加一个辅助函数
    /// </summary>
    public static MonoBehaviour AddComponent(GameObject go, string componentName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type type = assembly.GetType(componentName);
        return (MonoBehaviour)go.AddComponent(type);
    }
}
