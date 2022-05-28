using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    GameData characterData;
    public string info;
    int val;

    private void Start() { 
        slider = transform.GetComponent<Slider>();
        characterData = DataController.Instance._gameData;
        Debug.Log(characterData);
    }
    // Start is called before the first frame update
    void Update()
    {
        DrawBar();
    }

    public void DrawBar() {
        CharacterController2D Char = GameObject.Find("DrawCharacter-Changing").GetComponent<CharacterController2D>();
        float hp = Char.life;
        switch(info){
            case "realHealth":
                slider.value = hp / 10;
                break;
            case "Damage":
                val = DataController.Instance._gameData.offensetree["damage"];
                break;
            case "Accuracy":
                val = DataController.Instance._gameData.offensetree["accuracy"];
                break;
            case "Rate":
                val = DataController.Instance._gameData.offensetree["rate"];
                break;
            case "Health":
                val = DataController.Instance._gameData.defensetree["health"];
                break;
            case "Armor":
                val = DataController.Instance._gameData.defensetree["armor"];
                break;
            case "Healrate":
                val = DataController.Instance._gameData.defensetree["healrate"];
                break;
            case "Reward":
                val = DataController.Instance._gameData.utilitytree["reward"];
                break;
            case "Dodge":
                val = DataController.Instance._gameData.utilitytree["dodge"];
                break;
            case "Critical":
                val = DataController.Instance._gameData.utilitytree["critical"];
                break;
        }
        slider.value = val / 30;
    }

    // public void PlayerArmourBar() {
    //     int Armor = DataController.Instance._gameData.defensetree["armor"];
    //     sliderArmor.value = Armor / 30;
    // }
}
