using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//taken from GarnetKane99 on github
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items")]
public class Item : ScriptableObject
{
    public string id;
    public Sprite icon;
    public int itemAmount;
    public int itemCost;
}

public static class ScriptableObjectExtension
{
    public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
    {
        if(scriptableObject == null)
        {
            Debug.LogError($"error: null scriptable object. returning default {typeof(T)} object.");
            return (T)ScriptableObject.CreateInstance(typeof(T));
        }

        T instance = UnityEngine.Object.Instantiate(scriptableObject);
        instance.name = scriptableObject.name;
        return instance;
    }
}
