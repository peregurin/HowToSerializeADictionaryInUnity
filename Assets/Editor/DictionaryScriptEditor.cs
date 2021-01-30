using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DictionaryScript))]
public class DictionaryScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (((DictionaryScript)target).modifyValues)
        {
            if(GUILayout.Button("Save Changes"))
            {
                ((DictionaryScript)target).DeserializeDictionary();
            }
        }
        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if(GUILayout.Button("Print Dictionary"))
        {
            ((DictionaryScript)target).PrintDictionary();
        }
    }
}
