using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject _targetGO;
    private bool _inTarget;
    

    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _targetGO = GameObject.FindObjectOfType<Castle>().targetGO;
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetInTarget()
    {
        return _inTarget;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.Equals(_targetGO) && !_inTarget)
        {
            _inTarget = true;
            _gameManager.ShowPopupText("В цель!");
        }
        
    }
}
