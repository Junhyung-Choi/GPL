using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [TextArea]
    public string ment;

    public Text text;
    
    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(!text.transform.parent.gameObject.activeSelf && other.CompareTag("Player"))
        {
            text.text = ment;
            text.transform.parent.gameObject.SetActive(true);
        }
        
    }
    
    public virtual void OnTriggerExit2D(Collider2D other) {
        if(text.transform.parent.gameObject.activeSelf && other.CompareTag("Player"))
        {
            text.transform.parent.gameObject.SetActive(false);
        } 
    }
}
