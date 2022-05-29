using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindow : MonoBehaviour
{
    public Text text;

    public void UpdateLeftStatusPoint(int i)
    {
        text.text = i.ToString();
    }
}
