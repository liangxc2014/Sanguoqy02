using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateAnimations
{
    //private static readonly string SourcePath = @"Assets\Resources\Shape\FORCE\";
    //private static readonly string SourcePath = @"Assets\Resources\Shape\MAJOR\BODY\";
    //private static readonly string SourcePath = @"Assets\Resources\Shape\MAJOR\HORSE\";
    //private static readonly string SourcePath = @"Assets\Resources\Shape\MAJOR\WEAPON\";
    //private static readonly string SourcePath = @"Assets\Resources\Shape\TROOP\";
    //private static readonly string SourcePath = @"Assets\Resources\Shape\FONTS\";
    private static readonly string SourcePath = @"Assets\Resources\Test\";

	private static readonly string OutPath = @"Assets\Resources\Animations\";

    //private static readonly int pattenLenght = 4;
    private static readonly int pattenLenght = 2;

    [MenuItem("Tools/生成动画文件", false, 2)]
    static void Execute()
    {
//         StreamWriter strWri = File.CreateText("animations.txt");
//         XMLLoader<XMLDataAnimations> Animations = new XMLLoader<XMLDataAnimations>(XMLConfigPath.Animations);
//         IEnumerator<object> enumerator = Animations.Data.Values.GetEnumerator();
//         while (enumerator.MoveNext())
//         {
//             XMLDataAnimations data = (XMLDataAnimations)enumerator.Current;
//             string[] split = data.Path.Split('\\');
//             strWri.WriteLine(split[split.Length - 1]);
//         }
//         strWri.Flush();
//         strWri.Close();
//         return;

        DirectoryInfo di = new DirectoryInfo(SourcePath);
        
        if (di.Exists == false)
            return;

        FileInfo[] fileInfos = di.GetFiles();
        bool flag = false;
        string prefix = "-_-";
        StreamWriter sw = null;

        StreamWriter animSW = File.CreateText("Animations.txt");

        for (int index = 0; index < fileInfos.Length; index++)
        {
            string path = fileInfos[index].FullName;
            string fileName = Path.GetFileNameWithoutExtension(path);

            if (!(path.EndsWith(".png")) || fileName.Length < pattenLenght + 1)
                continue;

            if (fileName.Length != 8)
                continue;

            flag = true;

            if (fileName.StartsWith(prefix) == false)
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();

                    animSW.WriteLine(OutPath + prefix);
                }

                prefix = fileName.Substring(0, fileName.Length - pattenLenght);    

                sw = File.CreateText(OutPath + prefix + ".txt");
            }

            if (sw != null)
            {
                int idx = path.IndexOf("Resources");
                string resPath = path.Substring(idx + 10, path.Length - idx - 14);
                
                sw.WriteLine(resPath);

                EditorUtility.DisplayProgressBar("Processing", resPath, 1.0f * index / fileInfos.Length);
            }
        }

        if (sw != null)
        {
            sw.Flush();
            sw.Close();
        }

        if (animSW != null)
        {
            //最后一个
            animSW.WriteLine(OutPath + prefix);

            animSW.Flush();
            animSW.Close();
        }

        if (flag)
            AssetDatabase.Refresh();

        EditorUtility.ClearProgressBar();
    }
}
