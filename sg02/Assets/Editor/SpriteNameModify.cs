using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteNameModify
{

    [MenuItem("Tools/图片名字修改(去掉 '_1-1')")]
    static void Execute()
    {
        Object[] selectObject = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        for (int index = 0; index < selectObject.Length; index++)
        {
            Object o = selectObject[index];
            if (!(o is Texture2D)) continue;
            
            if (!(o.name.EndsWith("_1-1"))) continue;
            
            string pathName = AssetDatabase.GetAssetPath(o);
            string newName = o.name.Replace("_1-1", "");
            
            string message = AssetDatabase.RenameAsset(pathName, newName);
            if (message != null && !message.Equals(""))
            {
                Debug.Log(message);
            }

            string path = AssetDatabase.GetAssetPath(o);
            EditorUtility.DisplayProgressBar("Processing", path, 1.0f * index / selectObject.Length);
        }

        AssetDatabase.Refresh();

        EditorUtility.ClearProgressBar();
    }
}
