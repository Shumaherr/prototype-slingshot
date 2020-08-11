using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject slingshotPrefab;
    [Header("Set in Inspector")]
    public GameObject castlePrefab;

    public Vector2 castlePos;
    public Vector2 slingshotPos = new Vector3(-12,-9.57f,0);
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(slingshotPrefab, slingshotPos, Quaternion.Euler(0,-15,0));
        GameObject.Instantiate(castlePrefab, castlePos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
