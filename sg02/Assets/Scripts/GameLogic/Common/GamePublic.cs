using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GamePublic : Singleton<GamePublic>
{
    /// <summary>
    /// 状态机管理
    /// </summary>
    private GameStatesManager m_gameStatesManager;
    public GameStatesManager GameStatesManager { get { return m_gameStatesManager; } }

    /// <summary>
    /// 场景摄像机
    /// </summary>
    private Camera m_sceneCamera;
    public Camera SceneCamera { get { return m_sceneCamera; } }

    /// <summary>
    /// LUA管理器
    /// </summary>
    private LuaScriptMgr m_luaMgr;
    public LuaScriptMgr LuaManager { get { return m_luaMgr; } }

    /// <summary>
    /// LUA 文件
    /// </summary>
    private Dictionary<string, string> m_dicLuaFiles;
    public Dictionary<string, string> LuaFiles { get { return m_dicLuaFiles; } }

    /// <summary>
    /// 数据管理
    /// </summary>
    private DataManager m_datamanager;
    public DataManager DataManager { get { return m_datamanager; } }

    /// <summary>
    /// 历史时期列表
    /// </summary>
    private List<string> m_listTimes;
    public List<string> TimesList { get { return m_listTimes; } }

    /// <summary>
    /// 当前选择的历史时期
    /// </summary>
    public int CurrentTimes { get; set; }

    public int CurrentKing { get; set; }

    // ------------------------------------------------------- 华丽的分割线 --------------------------------------------------

    /// <summary>
    /// 初始化函数
    /// </summary>
    public override void Initialize() 
    {
        m_gameStatesManager = new GameStatesManager();
        m_gameStatesManager.Initialize();

        m_sceneCamera = GameObject.FindGameObjectWithTag("SceneCamera").GetComponent<Camera>();

        m_datamanager = new DataManager();
        
        InitLuaManager();
        InitTimesList();

        LoadLuaFiles();
    }

    public override void UnInitialize() 
    {
        
    }

    /// <summary>
    /// 初始化LUA管理器
    /// </summary>
    private void InitLuaManager()
    {
        m_luaMgr = new LuaScriptMgr();
        m_luaMgr.Start();

        LuaWapBinder.Bind(m_luaMgr.lua.L);
    }

    /// <summary>
    /// 初始化历史时期列表
    /// </summary>
    private void InitTimesList()
    {
        m_listTimes = new List<string>();

        IEnumerator enumerator = XMLManager.Times.Data.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            XMLDataTimes info = (XMLDataTimes)enumerator.Current;
            m_listTimes.Add(info.Name);
        }
    }

    /// <summary>
    /// 加载所有的LUA文件
    /// </summary>
    private void LoadLuaFiles()
    {
        m_dicLuaFiles = new Dictionary<string, string>();

        IEnumerator enumerator = XMLManager.LuaScripts.Data.Keys.GetEnumerator();
        while (enumerator.MoveNext())
        {
            string path = (string)enumerator.Current;
            m_luaMgr.DoFile(path);

            string moduleName = Path.GetFileNameWithoutExtension(path);
            m_dicLuaFiles.Add(moduleName, path);
        }
    }
}
