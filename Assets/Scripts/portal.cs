using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class portal : NPC
{
    // Update is called once per frame
    public bool IsEnterPortal = false;
    public string nextStage;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsEnterPortal){
            SceneManager.LoadScene(nextStage);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        IsEnterPortal = true;
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        IsEnterPortal = false;
    }
}
