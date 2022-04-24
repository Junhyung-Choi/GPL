using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int mp;
    public int gold;
    static Dictionary<string, bool> _relicItemDictionary;
    public static Dictionary<string, bool> RelicItemDictionary{
        get
        {
            return _relicItemDictionary;
        }
        // set
        // {
        //     _relicItemDictionary[value] = !_relicItemDictionary[value];
        // }
    }

    public static void SetTrueRelicItem(string name)
    {
        _relicItemDictionary[name] = true;
        _UpdatePlayer();
    }

    static void _UpdatePlayer()
    {
        // 구현 예정;
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
