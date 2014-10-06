using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteNameModify
{

    [MenuItem("Tools/Sprite Name Modify")]
    static void Execute()
    {
        foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
        {
            if (!(o is Texture2D)) continue;
            
            if (!(o.name.EndsWith("_1-1"))) continue;
            
            string pathName = AssetDatabase.GetAssetPath(o);
            string newName = o.name.Replace("_1-1", "");
            
            string message = AssetDatabase.RenameAsset(pathName, newName);
            if (message != null && !message.Equals(""))
            {
                Debug.Log(message);
            }
        }

        AssetDatabase.Refresh();
    }
}
