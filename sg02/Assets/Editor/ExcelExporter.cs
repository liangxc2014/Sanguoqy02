using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelExporter
{
    private static readonly string PathExcel = @"Assets\Resources\Config\Excel";

    [MenuItem("Tools/Excel 信息导出")]
	static void Execute()
    {
        bool flag = false;

        //Object[] selectObject = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        
        DirectoryInfo di = new DirectoryInfo(PathExcel);
        
        if (di.Exists == false)
            return;

        FileInfo[] fileInfos = di.GetFiles();
        
        for (int index = 0; index < fileInfos.Length; index++)
        {
            string path = fileInfos[index].FullName;
            
            if (!(path.EndsWith(".xlsx"))) 
                continue;

            flag = true;
            new Export(path, @"Assets\Resources\Config\XML", @"Assets\Scripts\XML\Entity");

            Debug.Log(path);
            EditorUtility.DisplayProgressBar("Processing", path, 1.0f * index / fileInfos.Length);
        }
        
        if (flag)
            AssetDatabase.Refresh();

        EditorUtility.ClearProgressBar();
    }
}
