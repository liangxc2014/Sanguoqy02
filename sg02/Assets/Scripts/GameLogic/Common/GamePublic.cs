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
    /// 场景头节点
    /// </summary>
    private string m_sceneRootName = "Scene Root";
    private GameObject m_sceneRoot;
    public GameObject SceneRoot { get { return m_sceneRoot; } }

    /// <summary>
    /// UI 头节点
    /// </summary>
    private string m_uiRootName = "UI Root";
    private GameObject m_uiRoot;
    public GameObject UIRoot { get { return m_uiRoot; } }

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
    /// 按钮的对象池
    /// </summary>
    private string m_poolRootName = "UI Root/Pool";
    private GameObject m_poolRoot;
    private ObjectPool m_poolButton;
    private int m_poolButtonSize = 30;
    public ObjectPool ButtonPool { get { return m_poolButton; } }

    private ObjectPool m_poolToggle;
    private int m_poolToggleSize = 30;
    public ObjectPool TogglePool { get { return m_poolToggle; } }

    /// <summary>
    /// 历史时期列表
    /// </summary>
    private List<string> m_listTimes;
    public List<string> TimesList { get { return m_listTimes; } }

    /// <summary>
    /// 当前选择的历史时期
    /// </summary>
    public int CurrentTimes { get; set; }

    /// <summary>
    /// 玩家选择的君主
    /// </summary>
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
        m_uiRoot = GameObject.Find(m_uiRootName);
        m_sceneRoot = GameObject.Find(m_sceneRootName);

        m_datamanager = new DataManager();

        InitPool();
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
    /// 初始化对象池
    /// </summary>
    private void InitPool()
    {
        m_poolRoot = GameObject.Find(m_poolRootName);

        m_poolButton = new ObjectPool();
        m_poolButton.Initialize(m_poolButtonSize, 1000, CreateOneButton);

        m_poolToggle = new ObjectPool();
        m_poolToggle.Initialize(m_poolToggleSize, 1000, CreateOnToggle);
    }

    private GameObject CreateOneButton()
    {
        GameObject temp = ResourcesManager.Instance.Load<GameObject>(UINamesConfig.FontButtonExample);
        GameObject go = Object.Instantiate(temp) as GameObject;
        Utility.SetObjectChild(m_poolRoot, go);
        return go;
    }

    private GameObject CreateOnToggle()
    {
        GameObject temp = ResourcesManager.Instance.Load<GameObject>(UINamesConfig.FontToggleExample);
        GameObject go = Object.Instantiate(temp) as GameObject;
        Utility.SetObjectChild(m_poolRoot, go);
        return go;
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
