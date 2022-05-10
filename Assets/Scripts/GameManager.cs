using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData characterData;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
       DataController.Instance.LoadGameData();
       characterData = DataController.Instance._gameData;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("s")){
            characterData.heroexp++;
            DataController.Instance._gameData = characterData;
            DataController.Instance.SaveGameData();
        }
        if(Input.GetKeyDown("l")){
            DataController.Instance.LoadGameData();
        }
    }
}
