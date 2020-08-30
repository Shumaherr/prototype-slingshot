using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Castle : MonoBehaviour
{
    private List<GameObject> bricks;

    public GameObject targetGO;
    // Start is called before the first frame update
    void Start()
    {
        var o = this.gameObject;
        int target = Random.Range(0, o.transform.childCount);
        o.GetComponentsInChildren<MeshRenderer>()[target]
            .material.color = Color.red;
        targetGO = o.transform.GetChild(target).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
