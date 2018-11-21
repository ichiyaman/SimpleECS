using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

/// <summary>
///  Vector3拡張
///  porting from
///  https://www.youtube.com/watch?v=S8YfVlffSSA 
/// </summary>
public static class Vector3Extentions {

    /// 部分的な値の変更
    public static Vector3 With(this Vector3 org, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? org.x, y ?? org.y, z ?? org.z);
    }
    /// 部分的な値の加算
    public static Vector3 Add(this Vector3 org, float? x = null, float? y = null, float? z = null)
    {
        Vector3 add = new Vector3(x ?? 0, y ?? 0, z ?? 0);
        return org + add;
    }
    /// 部分的な値の乗算
    public static Vector3 WithMul(this Vector3 org, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x * org.x ?? org.x, y  * org.y ?? org.y, z * org.z ?? org.z);
    }
    /// Yだけ zero に。地面に落とす
    public static Vector3 Flat(this Vector3 org)
    {
        return new Vector3(org.x, 0f, org.z);
    }
    /// DirectionTo
    public static Vector3 DirectionTo(this Vector3 src, Vector3 dst)
    {
        return Vector3.Normalize(dst - src);
    }
    /// Lerp 正規化
    public static Vector3 Lerp(this Vector3 src, Vector3 dst)
    {
        return Vector3.Normalize(dst - src);
    }
    /// ほぼ等しい
    public static bool AlmostSame(this Vector3 org, Vector3 tgt)
    {
        return (Mathf.Abs(org.x - tgt.x) < 0.01f && Mathf.Abs(org.y - tgt.y) < 0.01f && Mathf.Abs(org.z - tgt.z) < 0.01f) ? true : false  ;
    }
    
    
}
