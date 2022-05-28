using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string ment;

    public Text text;
    private void OnTriggerStay2D(Collider2D other) {
             
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(text.transform.parent.gameObject.activeSelf);
        if(!text.transform.parent.gameObject.activeSelf && other.CompareTag("Player"))
        {
            text.text = ment;
            text.transform.parent.gameObject.SetActive(true);
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if(text.transform.parent.gameObject.activeSelf && other.CompareTag("Player"))
        {
            text.transform.parent.gameObject.SetActive(false);
        } 
    }
}
