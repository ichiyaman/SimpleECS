using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// ListExtension.cs
/// porting from  http://kan-kikuchi.hatenablog.com/entry/ListExtension
/// </summary>
public static class ListExtensions {

  public static void AddUnique<T>(this List<T> list, T t){
    if(list.Contains(t)){
      return;
    }
    list.Add (t);
  }
  
  public static void Unique<T>(this List<T> list){
    List<T> newList = new List<T>();

    foreach (T item in list) {
      newList.AddUnique(item);
    }
    list = newList;
  }

  public static List<T> Shuffle<T>(this List<T> list){

    for (int i = 0; i < list.Count; i++) {
      T temp = list[i];
      int randomIndex = Random.Range(0, list.Count);
      list[i] = list[randomIndex];
      list[randomIndex] = temp;
    }
    return list;
  }

  public static T Pick<T>(this List<T> list, int targetNo){
    if(list.Count <= targetNo || targetNo < 0){
      Debug.LogError ("Not in list (ListCount : " + list.Count + ", No : " + targetNo + ")");
    }

    T target = list[targetNo];
    list.Remove (target);
    return target;
  }

  public static T Pop<T>(this List<T> list){
    return list.Pick(list.Count - 1);
  }

  public static T Shift<T>(this List<T> list){
    return list.Pick(0);
  }

  public static T GetRand<T>(this List<T> list){
    if(list.Count == 0){
      Debug.LogError ("List is empty");
    }

    return list[Random.Range(0, list.Count)];
  }

  public static T PickRand<T>(this List<T> list){
    T target = list.GetRand ();
    list.Remove (target);
    return target;
  }
}