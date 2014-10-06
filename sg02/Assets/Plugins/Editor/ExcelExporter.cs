using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelExporter
{
    [MenuItem("Tools/Excel Export")]
	static void Execute()
    {
        bool flag = false;
        foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
        {
            string path = AssetDatabase.GetAssetPath(o);
            if (!(path.EndsWith(".xlsx"))) 
                continue;

            flag = true;
            new Export(path);
        }
        
        if (flag)
            AssetDatabase.Refresh();
    }
}
