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
    int statusPoint;
    public Transform Canvas;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
       DataController.Instance.LoadGameData();
       characterData = DataController.Instance._gameData;
       statusWindow = levelupWindow;
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
        Debug.Log(string.Format("{0} Level up!", characterData.herolevel));
        if(statusWindow.activeSelf == false) statusWindow.SetActive(true);
        statusPoint = 3;
        
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
        Debug.Log(string.Format("LoadData Result => herolevel: {0}, heroexp: {1}, offenselevel: {2}, defenselevel: {3}, utilitylevel: {4}, gunshoplevel: {5}, relicshoplevel: {6}", 
            characterData.herolevel, characterData.heroexp, characterData.offenselevel, characterData.defenselevel, characterData.utilitylevel, characterData.gunshoplevel, characterData.relicshoplevel));
        
        if(statusPoint <= 0){
            statusWindow.SetActive(false);
            Debug.Log("check");
        }
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
