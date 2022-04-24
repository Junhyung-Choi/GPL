using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int mp;
    public int gold;
    static Dictionary<string, bool> _gunDictionary;
    static Dictionary<string, bool> _bulletDictionary;
    static Dictionary<string, bool> _relicItemDictionary;

    public static void SetItem(string name)
    {
        string dictType = "";
        if(_gunDictionary.ContainsKey(name))
        {
            dictType = "gun";
            foreach (var items in _gunDictionary)
            {
                if(items.Key == name) _gunDictionary[items.Key] = true;
                else _gunDictionary[items.Key] = false;               
            }
        }
        if(_bulletDictionary.ContainsKey(name))
        {
            dictType = "bullet";
            foreach (var items in _bulletDictionary)
            {
                if(items.Key == name) _bulletDictionary[items.Key] = true;
                else _bulletDictionary[items.Key] = false;               
            }
        }
        if(_relicItemDictionary.ContainsKey(name))
        {
            dictType = "relic";
            foreach (var items in _relicItemDictionary)
            {
                if(items.Key == name) _relicItemDictionary[items.Key] = true;
                else _relicItemDictionary[items.Key] = false;               
            }
        }
        _UpdatePlayer(dictType);
    }

    static void _UpdatePlayer(string dictType)
    {
        
    }

    public static PlayerManager instance;

    private void Awake() {
        instance = this;
        _relicItemDictionary = new Dictionary<string, bool>{
            {"magneticfiled" ,false},
            {"nanobot" ,false},
            {"steelman" ,false},
            {"destroy",false}
        };
    }
}