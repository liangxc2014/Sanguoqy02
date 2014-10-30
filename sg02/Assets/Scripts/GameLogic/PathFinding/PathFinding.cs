using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PathFinding
{

	public static List<int> GetPath(int start, int end, Dictionary<object, object> pathInfo)
    {
        if (start == end)
        {
            Debugging.LogError("Function:GetPath start == end");
            return null;
        }
        if ((!pathInfo.ContainsKey(start)) || (!pathInfo.ContainsKey(end)))
        {
            Debugging.LogError("Function:GetPath pathInfoContainsKey(start || end)");
            return null;
        }

        List<int> queue = new List<int>();      // 搜索序列
        List<int> queueIndex = new List<int>(); // 当前点的索引
        List<int> visitList = new List<int>();  // 保存所有搜索过的节点
        List<int> visitIndex = new List<int>(); // visit的父节点
        bool[] flags = new bool[pathInfo.Count];// 标志该点是否被搜索过

        int searchIndex = -1;

        // 加入起始点
        queue.Add(start);
        visitList.Add(start);
        visitIndex.Add(0);
        queueIndex.Add(visitList.Count - 1);
        flags[start - 1] = true;

        bool isFind = false;

        while (!isFind)
        {
            //全部相邻点搜索完毕,没有找到合适的点
            if (queue.Count == 0)
            {
                break;
            }

            searchIndex = queueIndex[0];

            XMLDataPathInfo point = (XMLDataPathInfo)pathInfo[queue[0]];
            string[] nextPoints = point.LinkPoints.Split(',');
            for (int i = 0; i < nextPoints.Length; i++)
            {
                int pointIdx = System.Convert.ToInt32(nextPoints[i]);

                if (flags[pointIdx - 1] == false)
                {
                    //标志该点
                    flags[pointIdx - 1] = true;
                }
                else
                {
                    //如果该点已经搜索过了就继续下一个
                    continue;
                }

                queue.Add(pointIdx);
                visitList.Add(pointIdx);
                visitIndex.Add(searchIndex);
                queueIndex.Add(visitList.Count - 1);

                if (pointIdx == end)
                {
                    isFind = true;
                    break;
                }
            }

            queue.RemoveAt(0);
            queueIndex.RemoveAt(0);
        }

        // 此路不通,返回空
        if (!isFind)
        {
            return null;
        }

        List<int> points = new List<int>();

        // 从终点开始搜索返回起点
        int currentPos = end;
        int visit = visitIndex.Count - 1; //最后的一个点

        do
        {
            currentPos = visitList[visit];
            points.Add(currentPos);

            visit = visitIndex[visit];

        } while (currentPos != start);

        points.Reverse();
        return points;
    }
}
