using System.Collections.Generic;
using UnityEngine;

public class DictionaryScript : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField]
    private DictionaryScriptableObject dictionaryScriptableObject;

    [Header("DICTIONARY")]
        [SerializeField]
        private List<string> keys = new List<string>();
        [SerializeField]
        private List<int> values = new List<int>();

    private Dictionary<string, int> myDictionary = new Dictionary<string, int>();

    public bool modifyValues;

    private void Awake()
    {
        for (int i = 0; i < Mathf.Min(dictionaryScriptableObject.Keys.Count, dictionaryScriptableObject.Values.Count); i++)
        {
            myDictionary.Add(dictionaryScriptableObject.Keys[i], dictionaryScriptableObject.Values[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        if(modifyValues == false)
        {
            keys.Clear();
            values.Clear();
            for(int i=0;i<Mathf.Min(dictionaryScriptableObject.Keys.Count, dictionaryScriptableObject.Values.Count); i++)
            {
                keys.Add(dictionaryScriptableObject.Keys[i]);
                values.Add(dictionaryScriptableObject.Values[i]);
            }
        }
    }

    public void OnAfterDeserialize()
    {
    }

    public void DeserializeDictionary()
    {
        Debug.Log("DESERIALIZATION");
        myDictionary = new Dictionary<string, int>();
        dictionaryScriptableObject.Keys.Clear();
        dictionaryScriptableObject.Values.Clear();
        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
        {
            dictionaryScriptableObject.Keys.Add(keys[i]);
            dictionaryScriptableObject.Values.Add(values[i]);
            myDictionary.Add(keys[i], values[i]);
        }
        modifyValues = false;
    }

    public void PrintDictionary()
    {
        foreach(var pair in myDictionary)
        {
            Debug.Log("Key: " + pair.Key + " Value: " + pair.Value);
        }
    }

}
