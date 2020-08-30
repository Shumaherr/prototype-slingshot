using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject slingshotPrefab;
    [Header("Set in Inspector")]
    public GameObject castlePrefab;
    public Transform textPopup;
    private TextMeshPro _textMeshPro;
    private Transform _textGO;
    
    public TextMeshPro textLevel;
    public TextMeshPro attemptsText;
    public TextMeshPro accuracyText;
    
    public Vector2 castlePos;
    public Vector2 slingshotPos = new Vector3(-12,-9.57f,0);

    private bool _inTarget;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(slingshotPrefab, slingshotPos, Quaternion.Euler(0,-15,0));
        GameObject.Instantiate(castlePrefab, castlePos, Quaternion.identity);
        _textMeshPro = textPopup.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    IEnumerator ReloadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Game");
        // Code to execute after the delay
    }
    
    public void ShowPopupText(String text)
    {
        if (_textGO == null)
        {
            _textMeshPro.SetText(text);
            _textGO = Instantiate(textPopup, castlePos + new Vector2(0.0f, 5.0f), Quaternion.identity);
           StartCoroutine("ReloadScene", 1.5f);
        }

    }

    public void AddAttempt()
    {
        
    }
}
