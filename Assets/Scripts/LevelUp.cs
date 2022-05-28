using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public static LevelUp instance;
    public GameObject levelupWindow;
    GameObject statusWindow;
    private int statusPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Levelup(){
        Debug.Log(string.Format("{0} Level up!", GameManager.instance.characterData.herolevel));
        statusWindow = Instantiate(levelupWindow);
        statusPoint = 3;
    }

    public void LevelUpButtonClick(string type)
    {
        switch(type){
            case "DamageUp":
                GameManager.instance.characterData.offensetree["damage"]++;
                GameManager.instance.characterData.offenselevel++;
                break;
            case "AccuracyUp":
                GameManager.instance.characterData.offensetree["accuracy"]++;
                GameManager.instance.characterData.offenselevel++;
                break;
            case "RateUp":
                GameManager.instance.characterData.offensetree["rate"]++;
                GameManager.instance.characterData.offenselevel++;
                break;
            case "HealthUp":
                GameManager.instance.characterData.defensetree["health"]++;
                GameManager.instance.characterData.defenselevel++;
                break;
            case "ArmorUp":
                GameManager.instance.characterData.defensetree["armor"]++;
                GameManager.instance.characterData.defenselevel++;
                break;
            case "HealrateUp":
                GameManager.instance.characterData.defensetree["healrate"]++;
                GameManager.instance.characterData.defenselevel++;
                break;
            case "RewardUp":
                GameManager.instance.characterData.utilitytree["reward"]++;
                GameManager.instance.characterData.utilitylevel++;
                break;
            case "DodgeUp":
                GameManager.instance.characterData.utilitytree["dodge"]++;
                GameManager.instance.characterData.utilitylevel++;
                break;
            case "CriticalUp":
                GameManager.instance.characterData.utilitytree["critical"]++;
                GameManager.instance.characterData.utilitylevel++;
                break;
        }
        statusPoint--;
        Debug.Log(string.Format("LoadData Result => herolevel: {0}, heroexp: {1}, offenselevel: {2}, defenselevel: {3}, utilitylevel: {4}, gunshoplevel: {5}, relicshoplevel: {6}", 
            GameManager.instance.characterData.herolevel, GameManager.instance.characterData.heroexp, GameManager.instance.characterData.offenselevel, GameManager.instance.characterData.defenselevel, GameManager.instance.characterData.utilitylevel, GameManager.instance.characterData.gunshoplevel, GameManager.instance.characterData.relicshoplevel));
        
        if(statusPoint <= 0){
            Destroy(statusWindow);
            Debug.Log("check");
        }
    }
}
