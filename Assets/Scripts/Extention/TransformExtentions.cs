using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TransformExtension
/// https://www.youtube.com/watch?v=S8YfVlffSSA 
/// </summary>
public static class TransformExtension {

    // With
    public static void Set(this Transform src, Transform dst)
    {
        src.position = dst.position;
        src.rotation = dst.rotation;
        src.localScale = dst.localScale;
    }

    public static void SetScale(this Transform src,Vector3 localScale)
    {
        src.localScale = localScale;
    }
}
