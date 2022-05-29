using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount;
    public float shakeSpeed;
    Vector3 initalPosition;
    Vector3 nextPosition;
    float dist;

    void Renew()
    {
        nextPosition = (Vector3)Random.insideUnitCircle * shakeAmount + initalPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        initalPosition = transform.position;
        Renew();
    }


    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position,nextPosition);
        if(dist > 3f)
        {
            transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * shakeSpeed);
        }
        else
        {
            Renew();
        }
    }
}
