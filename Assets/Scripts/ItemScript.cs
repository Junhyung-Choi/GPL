using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.gameObject.GetComponent<PlayerMovement>().runSpeed = 10f;
        Destroy(this.gameObject);
    }


}
