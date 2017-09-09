using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemMenu))]
public class ItemCreator : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ItemMenu item = (ItemMenu)target;
        if(GUILayout.Button("Create Item"))
        {
            item.createItem();
        }

    }
    
}
