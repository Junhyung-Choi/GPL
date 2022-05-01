using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
       void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            print("Player");
            SceneManager.LoadScene("BaseCamp");
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
