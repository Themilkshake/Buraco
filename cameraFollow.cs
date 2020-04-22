using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        followSpeed = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        var aux = GameObject.Find("Platform");
        bool aux2 = aux.GetComponent<Platform>().cameraUnlock;
        if (aux2)
        {

            float dist = distance();

            if (dist >= 0.03f)
            {
                transform.position -= new Vector3(0, dist * followSpeed, 0);
            }

            else
            {
                Vector3 plataformPos = aux.transform.position;
                plataformPos.z = transform.position.z;
                transform.position = plataformPos;
            }
        }
    }

    float distance()
    {
        var aux = GameObject.Find("Platform");
        Vector3 plataformPos = aux.transform.position;
        float dist = abs(plataformPos.y - transform.position.y);
        return dist;
    }

    float abs(float a)
    {
        if (a < 0) return a * (-1);
        else return a;
    }
}
