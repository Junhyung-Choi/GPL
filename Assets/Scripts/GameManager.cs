using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData characterData;
    public GameObject levelupWindow;
    GameObject statusWindow;
    int statusPoint = 0;
    int cnt = 0;
    public Transform Canvas;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
       DataController.Instance.LoadGameData();
       characterData = DataController.Instance._gameData;
       statusWindow = levelupWindow;
       statusWindow.SetActive(false);
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

    public void Levelup(){
        Time.timeScale = 0;
        Debug.Log(string.Format("{0} Level up!", characterData.herolevel));
        statusWindow.GetComponent<LevelUpWindow>().UpdateLeftStatusPoint(statusPoint);
        if(statusWindow.activeSelf == false) statusWindow.SetActive(true);
    }
    public void LevelUpButtonClick()
    {
        switch(EventSystem.current.currentSelectedGameObject.name){
            case "Damage":
                characterData.offensetree["damage"]++;
                characterData.offenselevel++;
                break;
            case "Accuracy":
                characterData.offensetree["accuracy"]++;
                characterData.offenselevel++;
                break;
            case "Rate":
                characterData.offensetree["rate"]++;
                characterData.offenselevel++;
                break;
            case "Health":
                characterData.defensetree["health"]++;
                characterData.defenselevel++;
                break;
            case "Armor":
                characterData.defensetree["armor"]++;
                characterData.defenselevel++;
                break;
            case "Healrate":
                characterData.defensetree["healrate"]++;
                characterData.defenselevel++;
                break;
            case "Reward":
                characterData.utilitytree["reward"]++;
                characterData.utilitylevel++;
                break;
            case "Dodge":
                characterData.utilitytree["dodge"]++;
                characterData.utilitylevel++;
                break;
            case "Critical":
                characterData.utilitytree["critical"]++;
                characterData.utilitylevel++;
                break;
        }
        statusPoint--;
        statusWindow.GetComponent<LevelUpWindow>().UpdateLeftStatusPoint(statusPoint);
        Debug.Log(string.Format("LoadData Result => herolevel: {0}, heroexp: {1}, offenselevel: {2}, defenselevel: {3}, utilitylevel: {4}", 
            characterData.herolevel, characterData.heroexp, characterData.offenselevel, characterData.defenselevel, characterData.utilitylevel));
        
        if(statusPoint <= 0){
            statusWindow.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Expcontrol(int exppoint){
        Debug.Log(exppoint);
        characterData.heroexp += exppoint;
        while(characterData.heroexp >= 100*characterData.herolevel){
            characterData.heroexp -= 100*characterData.herolevel;
            characterData.herolevel++;
            statusPoint += 3;
        }
        if(statusPoint != 0) Levelup();
    }
}
