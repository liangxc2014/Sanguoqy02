using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GeneratePathInfo 
{

    [MenuItem("Tools/Excel Export")]
    static void Execute()
    {
        if (Selection.objects.Length == 0) return;

        Object o = Selection.objects[0];
        if (!(o is Texture2D)) return;
        if (!o.name.EndsWith("PathMask")) return;


    }
}
