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

            List<int> listNext = new List<int>();
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

                listNext.Add(pointIdx);

                if (pointIdx == end)
                {
                    isFind = true;
                    break;
                }
            }

            //对相邻的点进行排序
            for (int i = 0; i < listNext.Count - 1; i++)
            {
                for (int j = i + 1; j < listNext.Count; j++)
                {
                    Vector3 p1 = Utility.GetPoint((pathInfo[listNext[i]] as XMLDataPathInfo).Position);
                    Vector3 p2 = Utility.GetPoint((pathInfo[listNext[j]] as XMLDataPathInfo).Position);
                    Vector3 endPoint = Utility.GetPoint((pathInfo[end] as XMLDataPathInfo).Position);

                    if (Vector3.Distance(p1, endPoint) > Vector3.Distance(p2, endPoint))
                    {
                        int temp = listNext[i];
                        listNext[i] = listNext[j];
                        listNext[j] = temp;
                    }
                }
            }

            for (int i = 0; i < listNext.Count; i++)
            {
                queue.Add(listNext[i]);
                visitList.Add(listNext[i]);
                visitIndex.Add(searchIndex);
                queueIndex.Add(visitList.Count - 1);
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
