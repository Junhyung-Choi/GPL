using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision) {
        doItemEffect(collision.gameObject);
        Destroy(this.gameObject);
    }

    void doItemEffect(GameObject player){
        switch (itemName){
            case "Chick":
                player.GetComponent<PlayerMovement>().runSpeed = 20f;
                break;
            case "FastChick":
                player.GetComponent<PlayerMovement>().runSpeed = 80f;
                break;
            default:
                // PlayerManager.SetTrueRelicItem(itemName);
                break;
        }
    }
}
