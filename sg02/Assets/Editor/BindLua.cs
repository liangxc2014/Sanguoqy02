using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Text;
using System.IO;

using Object = UnityEngine.Object;
using System.Diagnostics;
using System.Collections.Generic;

public static class LuaBinding
{
    private static string PathRegFile = "/Scripts/Lua/LuaWapBinder.cs";
    private static string PathProcessFile = "/Resources/Lua/Build.bat";
    private static string PathLuaOutDir = "/Assets/Resources/Lua/Out";
    private static string PathLuaBundle = "/Bundle/Lua.unity3d";

    public class BindType
    {
        public string name;
        public Type type;
        public bool IsStatic;
        public string baseName = null;
        public string wrapName = "";

        public BindType(string s, Type t, bool beStatic, string bn)
        {
            name = s;
            type = t;
            IsStatic = beStatic;
            baseName = bn;
            wrapName = name;
        }

        public BindType(string wrap, string s, Type t, bool beStatic, string bn)
        {
            name = s;
            type = t;
            IsStatic = beStatic;
            baseName = bn;
            wrapName = wrap;
        }
    }

    //注意必须保持基类在其派生类前面声明，否则自动生成的注册顺序是错误的
    static BindType[] binds = new BindType[]
    {	
        /*
        //object 由于跟 Object 文件重名就不加入了
        new BindType("Type", typeof(Type), false, null),
        //new BindType("IAssetFile", typeof(IAssetFile), false, "object"),        
        new BindType("Time", typeof(Time), false, "object"),
        new BindType("Vector2", typeof(Vector2), false, "object"),
        new BindType("Vector3", typeof(Vector3), false, "object"),
        //new BindType("LuaHelper", typeof(LuaHelper), false, "object"),

        //new BindType("Object", typeof(Object), false, "object"),              //Destroy 函数做了特殊处理, 加入了gc
        new BindType("GameObject", typeof(GameObject), false, "Object"),
        new BindType("Component", typeof(Component), false, "Object"),        
        
        new BindType("Behaviour", typeof(Behaviour), false, "Component"),
        new BindType("Transform", typeof(Transform), false, "Component"),

        new BindType("MonoBehaviour", typeof(MonoBehaviour), false, "Behaviour"),
        //new BindType("UIBase", typeof(UIBase), false, "MonoBehaviour"),
        //new BindType("UIEventListener", typeof(UIEventListener), false, "MonoBehaviour"),

        //new BindType("TableMgr", typeof(TableMgr), false, "MonoBehaviour"),
        //new BindType("AssetFileMgr", typeof(AssetFileMgr), false, "MonoBehaviour"),
        new BindType("Application", typeof(Application), false, "object"),    
        //new BindType("Debugger", typeof(Debugger), true, null),                
        //new BindType("UnGfx", typeof(UnGfx), true, null),              
        new BindType("Keyframe", typeof(Keyframe), false, "object"),
        new BindType("AnimationCurve", typeof(AnimationCurve), false, "object"),
        new BindType("TestToLua", typeof(TestToLua), false, "object"),
        new BindType("TestEnum", typeof(TestEnum), false, null),
        new BindType("Space", typeof(Space), false, null),
        //new BindType("DictInt2Str", "Dictionary<int,string>", typeof(Dictionary<int,string>), false, "object"),
        new BindType("Light", typeof(Light), false, "Behaviour"),
        new BindType("LightType", typeof(LightType), false, null),
        new BindType("Motion", typeof(Motion), false, null),
        new BindType("AnimationClip", typeof(AnimationClip), false, "Motion"),
        */
        /*
        new BindType("SpriteRenderer", typeof(UnityEngine.SpriteRenderer), false, null),
        new BindType("Text", typeof(UnityEngine.UI.Text), false, null),
        new BindType("Toggle", typeof(UnityEngine.UI.Toggle), false, null),

        new BindType("List_int", "List<int>", typeof(List<int>), false, null),
        new BindType("List_string", "List<string>", typeof(List<string>), false, null),
        new BindType("Dictionary", "Dictionary<object, object>", typeof(Dictionary<object,object>), false, null),
        new BindType("DictEnumerator", "Dictionary<object,object>.Enumerator", typeof(Dictionary<object,object>.Enumerator), false, null),
        */

        // Core
        new BindType("CallBack", typeof(CallBack), false, null),
        new BindType("IState", typeof(IState), false, null),
        new BindType("ObjectPool", typeof(ObjectPool), false, null),
        new BindType("StateManager", typeof(StateManager), false, null),

        new BindType("Debugging", typeof(Debugging), false, null),
        new BindType("InputManager", typeof(InputManager), false, null),
        new BindType("ResourcesManager", typeof(ResourcesManager), false, null),
        new BindType("ScreenControl", typeof(ScreenControl), false, null),
        new BindType("ScreenControl", typeof(ScreenControl), false, null),
        new BindType("TimerManager", typeof(TimerManager), false, null),
        new BindType("UIManager", typeof(UIManager), false, null),

        new BindType("Entity", typeof(Entity), false, null),
        new BindType("FSMBase", typeof(FSMBase), false, null),
        new BindType("StateBase", typeof(StateBase), false, null),
        new BindType("AnimationComponent", typeof(AnimationComponent), false, null),
        new BindType("MovmentComponent", typeof(MovmentComponent), false, null),

        // GameLogic/Common
        new BindType("GamePublic", typeof(GamePublic), false, null),
        new BindType("GlobalConfig", typeof(GlobalConfig), true, null),

        // GameLogic/DataManager
        new BindType("DataManager", typeof(DataManager), false, null),
        new BindType("KingInfo", typeof(KingInfo), false, null),
        new BindType("CityInfo", typeof(CityInfo), false, null),
        new BindType("GeneralInfo", typeof(GeneralInfo), false, null),

        // GameLogic/GameStates
        new BindType("GameStatesManager", typeof(GameStatesManager), false, "StateManager"),
        new BindType("InternalAffairsState", typeof(InternalAffairsState), false, "IState"),
        new BindType("LoadingState", typeof(LoadingState), false, "IState"),
        new BindType("SelectKingState", typeof(SelectKingState), false, "IState"),
        new BindType("SelectTimesState", typeof(SelectTimesState), false, "IState"),
        new BindType("StartMenuState", typeof(StartMenuState), false, "IState"),

        // GameLogic/MapCamera
        new BindType("MapCameraControl", typeof(MapCameraControl), false, null),

        // GameLogic/PathFinding
        new BindType("PathFinding", typeof(PathFinding), false, null),

        // GameLogic/Utility
        new BindType("Utility", typeof(Utility), true, null),

        // UI
        new BindType("UIButton", typeof(UIButton), true, "MonoBehaviour"),

        // XML
        new BindType("XMLConfigPath", typeof(XMLConfigPath), true, null),
        new BindType("XMLManager", typeof(XMLManager), true, null),

        // XML/Entity
        new BindType("XMLDataBattle", typeof(XMLDataBattle), true, null),
        new BindType("XMLDataCity", typeof(XMLDataCity), true, null),
        new BindType("XMLDataForce", typeof(XMLDataForce), true, null),
        new BindType("XMLDataGenerals", typeof(XMLDataGenerals), true, null),
        new BindType("XMLDataKings", typeof(XMLDataKings), true, null),
        new BindType("XMLDataLanguage", typeof(XMLDataLanguage), true, null),
        new BindType("XMLDataMagic", typeof(XMLDataMagic), true, null),
        new BindType("XMLDataMenuItem", typeof(XMLDataMenuItem), true, null),
        new BindType("XMLDataThings", typeof(XMLDataThings), true, null),
        new BindType("XMLDataTimes", typeof(XMLDataTimes), true, null),
        new BindType("XMLDataWiseSkill", typeof(XMLDataWiseSkill), true, null),

        new BindType("XMLDataPathInfo", typeof(XMLDataPathInfo), true, null),
        new BindType("XMLDataCityPoints", typeof(XMLDataCityPoints), true, null),

        new BindType("XMLLoader_XMLDataBattle", "XMLLoader<XMLDataBattle>", typeof(XMLLoader<XMLDataBattle>), true, null),
        new BindType("XMLLoader_XMLDataCity", "XMLLoader<XMLDataCity>", typeof(XMLLoader<XMLDataCity>), true, null),
        new BindType("XMLLoader_XMLDataForce", "XMLLoader<XMLDataForce>", typeof(XMLLoader<XMLDataForce>), true, null),
        new BindType("XMLLoader_XMLDataGenerals", "XMLLoader<XMLDataGenerals>", typeof(XMLLoader<XMLDataGenerals>), true, null),
        new BindType("XMLLoader_XMLDataKings", "XMLLoader<XMLDataKings>", typeof(XMLLoader<XMLDataKings>), true, null),
        new BindType("XMLLoader_XMLDataLanguage", "XMLLoader<XMLDataLanguage>", typeof(XMLLoader<XMLDataLanguage>), true, null),
        new BindType("XMLLoader_XMLDataMagic", "XMLLoader<XMLDataMagic>", typeof(XMLLoader<XMLDataMagic>), true, null),
        new BindType("XMLLoader_XMLDataMenuItem", "XMLLoader<XMLDataMenuItem>", typeof(XMLLoader<XMLDataMenuItem>), true, null),
        new BindType("XMLLoader_XMLDataThings", "XMLLoader<XMLDataThings>", typeof(XMLLoader<XMLDataThings>), true, null),
        new BindType("XMLLoader_XMLDataTimes", "XMLLoader<XMLDataTimes>", typeof(XMLLoader<XMLDataTimes>), true, null),
        new BindType("XMLLoader_XMLDataWiseSkill", "XMLLoader<XMLDataWiseSkill>", typeof(XMLLoader<XMLDataWiseSkill>), true, null),

        new BindType("XMLLoader_XMLDataPathInfo", "XMLLoader<XMLDataPathInfo>", typeof(XMLLoader<XMLDataPathInfo>), true, null),
        new BindType("XMLLoader_XMLDataCityPoints", "XMLLoader<XMLDataCityPoints>", typeof(XMLLoader<XMLDataCityPoints>), true, null),
        
        // Test
        new BindType("TestLuaFunctionType", typeof(TestLuaFunctionType), false, null),
    };

    [MenuItem("Lua/Gen LuaBinding Files", false, 11)]
    public static void Binding()
    {
        if (!Application.isPlaying)
        {
            //EditorApplication.isPlaying = true;            
        }
        
        for (int i = 0; i < binds.Length; i++)
        {
            ToLua.Clear();
            ToLua.className = binds[i].name;
            ToLua.type = binds[i].type;
            ToLua.isStaticClass = binds[i].IsStatic;
            ToLua.baseClassName = binds[i].baseName;
            ToLua.wrapClassName = binds[i].wrapName;
            ToLua.libClassName = binds[i].name;
            ToLua.Generate(null);
        }

        //EditorApplication.isPlaying = false;
        GenRegFile();
        UnityEngine.Debug.Log("Generate lua binding files over");
        AssetDatabase.Refresh();
    }

    static void GenRegFile()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine("public static class LuaWapBinder");
        sb.AppendLine("{");
        sb.AppendLine("\tpublic static void Bind(IntPtr L)");
        sb.AppendLine("\t{");
        /*
        sb.AppendLine("\t\tobjectWrap.Register(L);");
        sb.AppendLine("\t\tObjectWrap.Register(L);");
        sb.AppendLine("\t\tcoroutineWrap.Register(L);");
        */
        for (int i = 0; i < binds.Length; i++)
        {
            sb.AppendFormat("\t\tWrap{0}.Register(L);\r\n", binds[i].wrapName);
        }

        sb.AppendLine("\t}");
        sb.AppendLine("}");

        string file = Application.dataPath + PathRegFile;

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }
    }

    static string GetOS()
    {
#if UNITY_STANDALONE
        return "Win";
#elif UNITY_ANDROID
        return "Android";
#elif UNITY_IPHONE
        return "IOS";
#endif
    }

    [MenuItem("Lua/Build Lua with luajit", false, 1)]
    public static void BuildLua()
    {
        BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DeterministicAssetBundle;
        UnityEngine.Debug.Log(Application.dataPath);
        Process proc = Process.Start(Application.dataPath + PathProcessFile);
        proc.WaitForExit();
        AssetDatabase.Refresh();
        string[] files = Directory.GetFiles(PathLuaOutDir, "*.lua.bytes");
        List<Object> list = new List<Object>();

        for (int i = 0; i < files.Length; i++)
        {
            Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
            list.Add(obj);
        }

        if (files.Length > 0)
        {
            string output = Application.dataPath + PathLuaBundle;
            BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
//             string output1 = string.Format("{0}/{1}/Lua.unity3d", Application.persistentDataPath, GetOS());
//             FileUtil.DeleteFileOrDirectory(output1);
//             Directory.CreateDirectory(Path.GetDirectoryName(output1));
//             FileUtil.CopyFileOrDirectory(output, output1);
            AssetDatabase.Refresh();
        }

        UnityEngine.Debug.Log("编译lua文件结束");
    }

    [MenuItem("Lua/Build Lua without jit", false, 2)]
    public static void BuildLuaNoJit()
    {
        BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DeterministicAssetBundle;

        string[] files = Directory.GetFiles("Assets/Lua/Out", "*.lua.bytes");

        for (int i = 0; i < files.Length; i++)
        {            
            FileUtil.DeleteFileOrDirectory(files[i]);
        }

        files = Directory.GetFiles(Application.dataPath + "/Lua/", "*.lua", SearchOption.TopDirectoryOnly);

        for (int i = 0; i < files.Length; i++)
        {
            string fname = Path.GetFileName(files[i]);
            FileUtil.CopyFileOrDirectory(files[i], Application.dataPath + "/Lua/Out/" + fname + ".bytes");
        }

        AssetDatabase.Refresh();

        files = Directory.GetFiles("Assets/Lua/Out", "*.lua.bytes");
        List<Object> list = new List<Object>();

        for (int i = 0; i < files.Length; i++)
        {
            Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
            list.Add(obj);
        }

        if (files.Length > 0)
        {
            string output = string.Format("{0}/Bundle/Lua.unity3d", Application.dataPath);
            BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
            string output1 = string.Format("{0}/{1}/Lua.unity3d", Application.persistentDataPath, GetOS());
            FileUtil.DeleteFileOrDirectory(output1);
            Directory.CreateDirectory(Path.GetDirectoryName(output1));
            FileUtil.CopyFileOrDirectory(output, output1);
            AssetDatabase.Refresh();
        }

        UnityEngine.Debug.Log("编译lua文件结束");
    }
}
