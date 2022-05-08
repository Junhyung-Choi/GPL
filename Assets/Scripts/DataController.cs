using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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
            Debug.Log("불러오기 성공!");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
            Debug.Log(string.Format("LoadData Result => herolevel: {0}, heroexp: {1}, offenselevel: {2}, defenselevel: {3}, utilitylevel: {4}, gunshoplevel: {5}, relicshoplevel: {6}, offensetree: {7}, defensetree: {8}, utilitytree: {9}", gameData.herolevel, gameData.heroexp, gameData.offenselevel, gameData.defenselevel, gameData.utilitylevel, gameData.gunshoplevel, gameData.relicshoplevel, gameData.offensetree, gameData.defensetree, gameData.utilitytree));
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath,ToJsonData);
        Debug.Log("저장 완료");
        Debug.Log(filePath);
    }

    private void OnApplicationQuit() {
        SaveGameData();    
    }
}
