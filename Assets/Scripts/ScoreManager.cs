using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Transform LevelText;
    public Transform AttemptsText;
    public Transform RenderCanvas;
    
    private int _level;
    private int _attempts;
    private double _accuracy;
    private Transform _levelTextObj;
    private Transform _attemptTextObj;

    public int Level
    {
        get => _level;
        set => _level = value;
    }
    
    public int Attempts
    {
        get => _attempts;
        set => _attempts = value;
    }
    
    public double Accuracy => _accuracy;

    // Start is called before the first frame update
    public void NextLevel()
    {
        _attempts = 0;
        _level++;
    }

    public void AddAttempt()
    {
        _attempts++;
    }

    private void Start()
    {
        DontDestroyOnLoad(RenderCanvas);
        _attempts = 0;
        _level = 1;
        _levelTextObj = Instantiate(LevelText, new Vector3(-324, 158, 0), Quaternion.identity);
        _levelTextObj.transform.SetParent(RenderCanvas.transform, false);
        _attemptTextObj = Instantiate(AttemptsText, new Vector3(-324, 215, 0), Quaternion.identity);
        _attemptTextObj.transform.SetParent(RenderCanvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        _levelTextObj.GetComponent<TextMeshProUGUI>().text = "Level " + _level;
        _attemptTextObj.GetComponent<TextMeshProUGUI>().text = "Attempts " + _attempts;
        _levelTextObj.GetComponent<TextMeshProUGUI>().ForceMeshUpdate();
        _attemptTextObj.GetComponent<TextMeshProUGUI>().ForceMeshUpdate();
    }
}
