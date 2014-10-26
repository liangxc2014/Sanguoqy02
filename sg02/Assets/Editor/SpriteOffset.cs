using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteOffset
{
    [MenuItem("Tools/图片偏移量信息处理")]
    static void Execute()
    {
        Object[] selectObject = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        for (int index = 0; index < selectObject.Length; index++)
        {
            Object o = selectObject[index];
            if (!(o is Texture2D)) continue;
            string path = AssetDatabase.GetAssetPath(o);
            string infoFile = path + ".info.txt";

            //判断文件是否存在
            
            if (AssetDatabase.LoadAssetAtPath(infoFile, typeof(object)) == null)
                continue;

            FileStream fs = new FileStream(infoFile, FileMode.Open); 
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine(); //第一行注释
            line = sr.ReadLine().Trim(); //第二行偏移信息
            sr.Close();
            fs.Close();

            //删除信息文件
            AssetDatabase.DeleteAsset(infoFile);

            string[] lineSplit = line.Split(',');
            float[] info = new float[4];
            for (int i=0; i<4; i++)
            {
                info[i] = System.Convert.ToInt32(lineSplit[i]);
            }
            //中心点在(0, 0)表示不偏移
            if (info[0] == 0 && info[1] == 0)
                continue;

            Vector2 spritePivot = new Vector2();
            spritePivot.x = info[0] / info[2];
            spritePivot.y = (info[3] - info[1]) / info[3];

            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;

            TextureImporterSettings settings = new TextureImporterSettings();
            textureImporter.ReadTextureSettings(settings);
            settings.spriteAlignment = (int)SpriteAlignment.Custom;
            settings.spritePivot = spritePivot;
            settings.spritePixelsToUnits = 1;
            textureImporter.SetTextureSettings(settings);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

            EditorUtility.DisplayProgressBar("Processing", path, 1.0f * index / selectObject.Length);
        }

        EditorUtility.ClearProgressBar();
    }
}
