using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderHP;
    public Slider sliderArmor;
    // Start is called before the first frame update
    void Update()
    {
        PlayerHPbar();
    }

    public void PlayerHPbar() {
        CharacterController2D Char = GameObject.Find("DrawCharacter-Changing").GetComponent<CharacterController2D>();
        float hp = Char.life;
        sliderHP.value = hp / 10;
    }

    public void PlayerArmourBar() {
        int Armor = DataController.Instance._gameData.defensetree["armor"];
        sliderArmor.value = Armor / 30;
    }
}
