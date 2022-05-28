using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Update()
    {
        PlayerHPbar();
    }

    public void PlayerHPbar() {
        CharacterController2D Char = GameObject.Find("DrawCharacter-Changing").GetComponent<CharacterController2D>();
        float hp = Char.life;
        slider.value = hp / 10;
    }
}
