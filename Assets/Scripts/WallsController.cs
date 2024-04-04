using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    Breakable[] bWalls;
    public float shakeThreshHold;
    public float minWaitTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        bWalls = GetComponentsInChildren<Breakable>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0 && Input.acceleration.magnitude > shakeThreshHold) {
            //randomly pick a wall to hide
            int i = Random.Range(0, bWalls.Length);
            bWalls[i].hideMe();
            timer = minWaitTime;
        }
    }
}
