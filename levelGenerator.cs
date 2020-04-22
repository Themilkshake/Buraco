using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform wallTile;
    public Transform floorTile;
    public Transform normalWall;
    public Transform lightWall;
    public Transform middleBg;
    public Transform halfBlock;

    private bool wasPrinted;
    private int printedRows;
    private int lastPosY;
    private int[] backgroundArray = {-18, -6, 6};
    void Start()
    {
        printedRows = 4;
        wasPrinted = false;
        lastPosY = -3;
    }

    // Update is called once per frame
    void Update()
    {
        int currPosY = ceil(GameObject.Find("Main Camera").transform.position.y - 15.0f);

        if (lastPosY != currPosY)
        {
            wasPrinted = false;
        }

        if (!wasPrinted)
        {
            spawnWallTile(new Vector3(-19, currPosY, 0));
            spawnWallTile(new Vector3(-19 + 37, currPosY, 0));

            wasPrinted = true;
            lastPosY = currPosY;
            printedRows++;

            if (printedRows == 10 || printedRows == 16)
            {
                for(int i=0; i<3; i++)
                {
                    spawnNormalWall(new Vector3(backgroundArray[i], currPosY, 0));
                }
            }

            else if(printedRows == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    spawnLightWall(new Vector3(backgroundArray[i], currPosY, 0));
                }
            }
            
            else if(printedRows == 21)
            {
                spawnMiddleBg(new Vector3(-3, currPosY-1, 0));
            }

            else if (printedRows >= 22)
            {
                printFloor(currPosY);

                if (printedRows == 23)
                {
                    for(int i = 0; i<3; i++)
                    {
                        spawnHalfBlock(new Vector3(backgroundArray[i], currPosY-1, 0));
                    }


                    printedRows = 0;
                }
            }
        }

        
    }


    private void printFloor(int currPosY)
    {
        for(int i = -18; i < -3; i++)
        {
            spawnFloorTile(new Vector3(i, currPosY, 0));
        }

        for (int i = 3; i < 18; i++)
        {
            spawnFloorTile(new Vector3(i, currPosY, 0));
        }
    }

    private void spawnWallTile(Vector3 spawnPos)
    {
        Instantiate(wallTile, spawnPos, Quaternion.identity);
    }

    private void spawnFloorTile(Vector3 spawnPos)
    {
        Instantiate(floorTile, spawnPos, Quaternion.identity);
    }
    private void spawnNormalWall(Vector3 spawnPos)
    {
        Instantiate(normalWall, spawnPos, Quaternion.identity);
    }
    private void spawnLightWall(Vector3 spawnPos)
    {
        Instantiate(lightWall, spawnPos, Quaternion.identity);
    }
    private void spawnMiddleBg(Vector3 spawnPos)
    {
        Instantiate(middleBg, spawnPos, Quaternion.identity);
    }
    private void spawnHalfBlock(Vector3 spawnPos)
    {
        Instantiate(halfBlock, spawnPos, Quaternion.identity);
    }

    int ceil(float a)
    {
        int b = (int)a;
        return (b - 1);
    }


}
