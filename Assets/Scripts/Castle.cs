using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public double bottom; //Bottom of this y is "fallen"
    private double health = 100.0;
    private int numOfBlocks;
    private List<Transform> bricks;
    // Start is called before the first frame update
    void Start()
    {
        var o = this.gameObject;
        if (o != null)
        {
            bricks = GetComponentsInChildren<Transform>().ToList();
            numOfBlocks = bricks.Capacity;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CheckDamage()
    {
        int count = 0;
        foreach (var brick in bricks)
        {
            if (brick.transform.position.y <= bottom)
            {
                count++;
            }
        }
        health -= (count / numOfBlocks * 100);
        numOfBlocks -= count;
        return Mathf.RoundToInt((float) health);
    }
}
