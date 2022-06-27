//Developed By: Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. +57 3508232690
//Bogotá Colombia.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProceduralTerrain : MonoBehaviour
{

    private List<GroundComponent> groundComponentsPool;

    int activeGround;

    public int groundWidth;

    GroundComponent lastGround;

    
    void Start()
    {
        groundComponentsPool = new List<GroundComponent>(GetComponentsInChildren<GroundComponent>());
        Firstground();
    }

    public void RestarGround()
    {
        for (int i = 1; i < groundComponentsPool.Count; i++)
        {
            groundComponentsPool[i].transform.localPosition = new Vector3(0,-30,0);
        }
    }


    void Firstground()
    {
        var firstGround = groundComponentsPool[0];
        firstGround.transform.localPosition = Vector3.zero;
        lastGround = firstGround;
    }

    public void Spawnground()
    {
        var NewGround = RandomGround();
        NewGround.transform.localPosition = new Vector3(lastGround.transform.localPosition.x + groundWidth, 0,0);
        lastGround = NewGround;
    }

    GroundComponent RandomGround()
    {
        var randomIndex = (int)Random.Range(1, groundComponentsPool.Count);        

        while (randomIndex == activeGround)
        {
            randomIndex = (int)Random.Range(1, groundComponentsPool.Count);
        }

        print("Random ground= " + randomIndex);
        activeGround = randomIndex;
        GroundComponent ground  = groundComponentsPool[randomIndex];

        return ground;
    }
}
