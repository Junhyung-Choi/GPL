using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    GameData characterData;
    public string info;
    float val;

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
                return;
            case "Damage":
                val = DataController.Instance.gameData.offensetree["damage"];
                slider.value = val / 10;
                break;
            case "Accuracy":
                val = DataController.Instance.gameData.offensetree["accuracy"];
                slider.value = val / 10;
                break;
            case "Rate":
                val = DataController.Instance.gameData.offensetree["rate"];
                slider.value = val / 10;
                break;
            case "Health":
                val = DataController.Instance.gameData.defensetree["health"];
                slider.value = val/10;
                return;
            case "Armor":
                val = DataController.Instance.gameData.defensetree["armor"];
                slider.value = val / 10;
                break;
            case "Healrate":
                val = DataController.Instance.gameData.defensetree["healrate"];
                slider.value = val / 10;
                break;
            case "Reward":
                val = DataController.Instance.gameData.utilitytree["reward"];
                slider.value = val / 10;
                break;
            case "Dodge":
                val = DataController.Instance.gameData.utilitytree["dodge"];
                slider.value = val / 10;
                break;
            case "Critical":
                val = DataController.Instance.gameData.utilitytree["critical"];
                slider.value = val / 10;
                break;
        }
    }

    // public void PlayerArmourBar() {
    //     int Armor = DataController.Instance._gameData.defensetree["armor"];
    //     sliderArmor.value = Armor / 30;
    // }
}
