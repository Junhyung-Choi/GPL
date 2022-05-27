using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData characterData;
    public GameObject levelupWindow;
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
            DataController.Instance._gameData = characterData;
            DataController.Instance.SaveGameData();
        }
        if(Input.GetKeyDown("l")){
            DataController.Instance.LoadGameData();
        }
    }

    void Levelup(){
        Debug.Log(string.Format("{0} Level up!", characterData.herolevel));
    }

    public void Expcontrol(int exppoint){
        characterData.heroexp += exppoint;
        if(characterData.heroexp >= 100*characterData.herolevel){
            characterData.heroexp -= 100*characterData.herolevel;
            characterData.herolevel++;
            Levelup();
        }
    }


}
