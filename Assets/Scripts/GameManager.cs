using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int herolevel;
    public int gunshoplevel;
    public int relicshoplevel;
    // Start is called before the first frame update
    public static GameManager instance;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
