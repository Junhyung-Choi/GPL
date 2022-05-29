using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BackgroundScrolling : MonoBehaviour
{
    // public float speed;
    public GameObject[] backgrounds;
    public GameObject player;
    public Transform canvas;
    float minX;
    float maxX;
    float playerx;
    List<GameObject> backgroundList = new List<GameObject>();
    void Update()
    {
        playerx = player.transform.position.x;
        if(backgroundList.Count == 0)
        {
            for(int i = 0 ; i < backgrounds.Length; i++)
            {
               GameObject tmp = Instantiate(backgrounds[i],canvas);
               tmp.SetActive(true);
               backgroundList.Add(tmp);
            }
        } else {
            bool needtoInstantiate = true;
            foreach(var bg in backgroundList)
            {
                minX = Mathf.Min(bg.transform.position.x,minX);
                maxX = Mathf.Max(bg.transform.position.x,maxX);
            }
            if(minX - 20 < player.transform.position.x && player.transform.position.x < maxX + 20)
            {
                needtoInstantiate = false;
            }
            if(needtoInstantiate)
            {
                int posx = 0;
                if(playerx > 0)
                {
                    posx = ((int)player.transform.position.x + 100) / 100 * 100;
                } else {
                    posx = ((int)player.transform.position.x - 100) / 100 * 100;
                    Debug.Log(posx);
                }
                Vector3 pos = new Vector3(posx,0,0);
                for(int i = 0 ; i < backgrounds.Length; i++)
                {
                    GameObject tmp = Instantiate(backgrounds[i],pos,Quaternion.identity,canvas);
                    tmp.SetActive(true);
                    tmp.transform.transform.position = pos;
                    backgroundList.Add(tmp);
                }
            }
        }
    }
}