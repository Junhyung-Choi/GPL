using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int mp;
    public int gold;
    static Gun _gun;
    static Dictionary<string, bool> _gunDictionary;
    static Dictionary<string, bool> _bulletDictionary;
    static Dictionary<string, bool> _relicDictionary;static PlayerManager instance;
    public GameObject bulletPrefab;
    private void Awake() {
        instance = this;
        _gunDictionary = new Dictionary<string, bool>{
            {"handgun", true},
            {"machinegun", false},
            {"shotgun", false},
        };
        _bulletDictionary = new Dictionary<string, bool>{
            {"nor_bullet", true},
            {"ap_bullet", false},
            {"ex_bullet", false},
        };
        _relicDictionary = new Dictionary<string, bool>{
            {"magneticfiled", false},
            {"nanobot", false},
            {"iron_charm", false},
            {"ex_charm", false}
        };
    }

    private void Start() {
        _gun = this.gameObject.AddComponent(typeof(Gun)) as Gun;
        _gun.ChangeGun("handgun");
        _gun.bulletPrefab = bulletPrefab;
    }
    private void Update() {
        if (Input.GetKey(KeyCode.Y))
		{
			_gun.Shoot();
		}
    }
    public static void SetItem(string name)
    {
        string before = "";
        if(_gunDictionary.ContainsKey(name))
        {
            foreach (var items in _gunDictionary)
            {
                if(items.Value) before = items.Key;               
            }
            _gunDictionary[before] = false;
            _gunDictionary[name] = true;
            instance._UpdateGun();
        }
        if(_bulletDictionary.ContainsKey(name))
        {
            foreach(var items in _bulletDictionary)
            {
                if(items.Value) before = items.Key;
            }
            _bulletDictionary[before] = false;
            _bulletDictionary[name] = true;
            instance._UpdateBullet();
        }
        if(_relicDictionary.ContainsKey(name))
        {
            foreach (var items in _relicDictionary)
            {
                if(items.Key == name) _relicDictionary[items.Key] = true;
                else _relicDictionary[items.Key] = false;               
            }
            instance._UpdateRelic();
        }
    }

    private void _UpdateGun(){
        string gunname = "";
        foreach (var item in _gunDictionary)
        {
            if (item.Value) gunname = item.Key;
        }
        _gun.ChangeGun(gunname);
    }

    private void _UpdateBullet(){
        // 플레이어 총일 변경
        // 하나만 가능
    }

    private void _UpdateRelic(){
        // 플레이어 유물 변경
    }


    
}