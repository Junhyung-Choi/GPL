using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public string SceneToLoad;
    // Start is called before the first frame update
    public void LoadGame() {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Update() {
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
