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
        CharacterController2D Char = GameObject.Find("DrawCharacter-Changing").GetComponent<CharacterController2D>();
        float hp = Char.life;
        switch(info){
            case "realHealth":
                slider.value = hp / 10;
                break;
            case "Damage":
                val = characterData.offensetree["damage"];
                slider.value = val / 30;
                break;
            case "Accuracy":
                val = characterData.offensetree["accuracy"];
                slider.value = val / 30;
                break;
            case "Rate":
                val = characterData.offensetree["rate"];
                slider.value = val / 30;
                break;
            case "Health":
                val = characterData.defensetree["health"];
                slider.value = val / 30;
                break;
            case "Armor":
                val = characterData.defensetree["armor"];
                slider.value = val / 30;
                break;
            case "Healrate":
                val = characterData.defensetree["healrate"];
                slider.value = val / 30;
                break;
            case "Reward":
                val = characterData.utilitytree["reward"];
                slider.value = val / 30;
                break;
            case "Dodge":
                val = characterData.utilitytree["dodge"];
                slider.value = val / 30;
                break;
            case "Critical":
                val = characterData.utilitytree["critical"];
                slider.value = val / 30;
                break;
        }

    }

    // public void PlayerArmourBar() {
    //     int Armor = DataController.Instance._gameData.defensetree["armor"];
    //     sliderArmor.value = Armor / 30;
    // }
}
