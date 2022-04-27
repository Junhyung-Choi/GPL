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
            case "handgun":
                PlayerManager.SetItem("handgun");
                break;
            case "machinegun":
                PlayerManager.SetItem("machinegun");
                break;
            case "shotgun":
                PlayerManager.SetItem("shotgun");
                break;
            case "nor_bullet":
                PlayerManager.SetItem("nor_bullet");
                break;
            case "ap_bullet":
                PlayerManager.SetItem("ap_bullet");
                break;
            case "ex_bullet":
                PlayerManager.SetItem("ex_bullet");
                break;
            case "mf_generator":
                PlayerManager.SetItem("mf_generator");
                break;
            case "nanobot":
                PlayerManager.SetItem("nanobot");
                break;
            case "iron_charm":
                PlayerManager.SetItem("iron_charm");
                break;
            case "ex_charm":
                PlayerManager.SetItem("ex_charm");
                break;
            default:
                // PlayerManager.SetTrueRelicItem(itemName);
                break;
        }
    }
}
