using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Debugging
{
    private static string _filterWords = string.Empty;
    private static int g_level = 0;
    private static string[] g_level_title = new string[] { "debug", "info", "waring", "error" };
    public const int LV_DEBUG = 0;
    public const int LV_ERROR = 3;
    public const int LV_INFO = 1;
    public const int LV_NONE = 4;
    public const int LV_WARING = 2;

    public static void Init(int level)
    {
        if (!IsValid(level))
        {
            level = 4;
        }
        g_level = level;
    }

    private static bool IsValid(int level)
    {
        return ((level <= 4) && (level >= 0));
    }

    public static void Log(int _log)
    {
        Log(_log, 0);
    }

    public static void Log(float _log)
    {
        Log(_log, 0);
    }

    public static void Log(string log)
    {
        Log(log, 0);
    }

    public static void Log(int _log, int level)
    {
        Log(_log.ToString(), level);
    }

    public static void Log(float _log, int level)
    {
        Log(_log.ToString(), level);
    }

    public static void Log(string log, int level)
    {
        if (!GlobalConfig.IsDebuggingOpen)
            return;

        if ((Application.platform == RuntimePlatform.WindowsEditor) && !string.IsNullOrEmpty(_filterWords))
        {
            char[] separator = new char[] { '&' };
            foreach (string str in _filterWords.Split(separator))
            {
                if (!log.ToLower().Contains(str))
                {
                    return;
                }
            }
        }
        if (IsValid(level) && (level >= g_level))
        {
            string currTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string currThread = Thread.CurrentThread.ManagedThreadId.ToString();
            StackTrace trace = new StackTrace(true);
            string str4 = string.Empty;
            for (int i = trace.FrameCount - 1; i >= 0; i--)
            {
                StackFrame frame = trace.GetFrame(i);
                str4 = str4 + frame.GetMethod().Name + ".";
            }
            string[] textArray1 = new string[] { currTime, " [logs]-[", g_level_title[level], "]  [Thread:", currThread, "]  ", log, "\ncall stack: [", str4, "]\ntime(ms): [", DateTime.Now.ToShortTimeString(), "]" };
            string message = string.Concat(textArray1);
            if (level == 3)
            {
                UnityEngine.Debug.LogError(message);
            }
            else if (level == 2)
            {
                UnityEngine.Debug.LogWarning(message);
            }
            else
            {
                UnityEngine.Debug.Log(message);
            }
        }
    }

    public static void Log(Vector3 _log, int level)
    {
        Log("x=" + _log.x.ToString() + ",y=" + _log.y.ToString() + ",z=" + _log.z.ToString(), level);
    }

    public static void LogError(string log)
    {
        Log(log, 3);
    }

    public static void LogWaring(string log)
    {
        Log(log, 2);
    }

    public static void SetFilterWords(string filterWords)
    {
        _filterWords = filterWords;
    }

    public static int CurrentDebugLevel
    {
        get
        {
            return g_level;
        }
    }
}

