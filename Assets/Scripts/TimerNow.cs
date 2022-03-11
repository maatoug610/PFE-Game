using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerNow : MonoBehaviour
{
    [SerializeField] private Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dateNow = DateTime.Now;
        Debug.Log(dateNow);
        TimerText.text = dateNow.ToString();
    }
}
