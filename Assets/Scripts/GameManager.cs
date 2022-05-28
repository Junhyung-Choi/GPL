using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        statusWindow = Instantiate(levelupWindow);
        statusPoint = 3;
        statusWindow.transform.SetParent(Canvas);
        statusWindow.transform.position = new Vector3(0, 0, -6);
        
        //statusWindow.transform.position = new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2, -6);
        
    }
    public void LevelUpButtonClick(string type)
    {
        switch(type){
            case "DamageUp":
                characterData.offensetree["damage"]++;
                characterData.offenselevel++;
                break;
            case "AccuracyUp":
                characterData.offensetree["accuracy"]++;
                characterData.offenselevel++;
                break;
            case "RateUp":
                characterData.offensetree["rate"]++;
                characterData.offenselevel++;
                break;
            case "HealthUp":
                characterData.defensetree["health"]++;
                characterData.defenselevel++;
                break;
            case "ArmorUp":
                characterData.defensetree["armor"]++;
                characterData.defenselevel++;
                break;
            case "HealrateUp":
                characterData.defensetree["healrate"]++;
                characterData.defenselevel++;
                break;
            case "RewardUp":
                characterData.utilitytree["reward"]++;
                characterData.utilitylevel++;
                break;
            case "DodgeUp":
                characterData.utilitytree["dodge"]++;
                characterData.utilitylevel++;
                break;
            case "CriticalUp":
                characterData.utilitytree["critical"]++;
                characterData.utilitylevel++;
                break;
        }
        statusPoint--;
        Debug.Log(string.Format("LoadData Result => herolevel: {0}, heroexp: {1}, offenselevel: {2}, defenselevel: {3}, utilitylevel: {4}, gunshoplevel: {5}, relicshoplevel: {6}", 
            characterData.herolevel, characterData.heroexp, characterData.offenselevel, characterData.defenselevel, characterData.utilitylevel, characterData.gunshoplevel, characterData.relicshoplevel));
        
        if(statusPoint < 0){
            Destroy(statusWindow);
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
