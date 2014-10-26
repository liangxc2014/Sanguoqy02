using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelExporter
{
    [MenuItem("Tools/Excel 信息导出")]
	static void Execute()
    {
        bool flag = false;

        Object[] selectObject = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        for (int index=0; index<selectObject.Length; index++)
        {
            Object o = selectObject[index];
            string path = AssetDatabase.GetAssetPath(o);
            if (!(path.EndsWith(".xlsx"))) 
                continue;

            flag = true;
            new Export(path);

            EditorUtility.DisplayProgressBar("Processing", path, 1.0f * index / selectObject.Length);
        }
        
        if (flag)
            AssetDatabase.Refresh();

        EditorUtility.ClearProgressBar();
    }
}
