﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeFreeze : MonoBehaviour
{
    public bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
            paused = !paused;
        }
    }
}
