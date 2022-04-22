using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
    private void Start() {
        Debug.Log("ceil" + Mathf.Ceil(-2.3f));
        Debug.Log("floor" + Mathf.Floor(-1.75f));
    }
}
