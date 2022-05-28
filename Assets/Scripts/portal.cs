using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portal : NPC
{
    // Update is called once per frame
    void Update()
    {/*
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Stage");
        }*/
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Stage");
        }
    }
}
