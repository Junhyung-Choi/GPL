using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.transform){
            Debug.Log("hi");
        }
    }
}
