﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashTriggerClientTwo : MonoBehaviour
{
    Animator _clientAnim;
    public float MoneyAdded = 2;
    public float Timer = 100;
    int StartTimer = 1;
    public float TimeRest = 10;
    public Text MoneyText;

    //public Text TimerText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageCash;
    [Space]
    [Header("Canvas Timer")]
    [SerializeField] private GameObject CanvasTimer;
    [Space]
    [Header("Clients List")]
    [SerializeField] private GameObject Client2;
    

    private void OnTriggerEnter(Collider other){
        //Anination...
        //Timer
        if(other.gameObject.name == "client 2"){
            StartTimer = 0;
            CanvasTimer.SetActive(true);

        }
        
        
        
    }

    private void OnTriggerExit(Collider other){
        //
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _clientAnim = this.transform.parent.GetComponent<Animator>();
    }
    void Update(){

        TimerImageCash.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        if(StartTimer == 0 ){
            
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            GameData.Gems = GameData.Gems + (int) MoneyAdded;
            
            Destroy(Client2);
           
            //Timer = TimeRest;
            Timer = 20;
            StartTimer = 1;
        }
    }

 
}