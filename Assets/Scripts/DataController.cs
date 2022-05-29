using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

public class DataController : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if(!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    
    public string GameDataFileName = "save.json";
    public GameData _gameData;
    public GameData gameData{
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonConvert.DeserializeObject<GameData>(FromJsonData);
            Debug.Log("불러오기 성공!");
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
        Debug.Log(string.Format("LoadData Result {0}",_gameData));
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonConvert.SerializeObject(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath,ToJsonData);
        Debug.Log(ToJsonData);
        Debug.Log("저장 완료");
        Debug.Log(filePath);
    }

    private void OnApplicationQuit() {
        SaveGameData();    
    }
}
