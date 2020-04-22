using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float speed;
    public int timer;
    public int TIME_STOPPED; 
    private int nextPos;
    public bool cameraUnlock;

    // Start is called before the first frame update
    void Start()
    {
        if (speed == 0) speed = 0.08f;
        timer = 0;
        cameraUnlock = false;
        nextPos = 1;
        TIME_STOPPED = 500;
    }

    // Update is called once per frame
    void Update()
    {

        const int ROOM_HIGHT = 23;

        if (!GameObject.Find("Main Camera").GetComponent<timeFreeze>().paused)
        {

            if (GetComponent<Transform>().position.y >= nextPos || timer >= TIME_STOPPED)
            {
                GetComponent<Transform>().position -= new Vector3(0, speed, 0);
                if (timer >= TIME_STOPPED)
                {
                    cameraUnlock = true;
                    timer = 0;
                    nextPos -= ROOM_HIGHT;
                }
            }

            else
            {
                timer += 1;
            }
        }

    }
}