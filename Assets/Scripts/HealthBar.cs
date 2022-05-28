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
    }
    // Start is called before the first frame update
    void Update()
    {
        DrawBar();
    }

    public void DrawBar() {
        switch(info){
            case "realHealth":
            
            case "Damage":
                val = characterData.offensetree["damage"];
                break;
            case "Accuracy":
                val = characterData.offensetree["accuracy"];
                break;
            case "Rate":
                val = characterData.offensetree["rate"];
                break;
            case "Health":
                val = characterData.offensetree["health"];

                break;
            case "Armor":
                val = characterData.offensetree["armor"];

                break;
            case "Healrate":
                val = characterData.offensetree["healrate"];

                break;
            case "Reward":
                val = characterData.offensetree["reward"];

                break;
            case "Dodge":
                val = characterData.offensetree["dodge"];

                break;
            case "Critical":
                val = characterData.offensetree["critical"];
                break;
        }
        CharacterController2D Char = GameObject.Find("DrawCharacter-Changing").GetComponent<CharacterController2D>();
        float hp = Char.life;
        slider.value = hp / 10;

    }

    // public void PlayerArmourBar() {
    //     int Armor = DataController.Instance._gameData.defensetree["armor"];
    //     sliderArmor.value = Armor / 30;
    // }
}
