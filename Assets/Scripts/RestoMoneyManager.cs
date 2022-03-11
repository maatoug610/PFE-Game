﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
namespace DailyRewardSystem {
public enum GemsType {
		Gems,
	}

public class RestoMoneyManager : MonoBehaviour
{
    float Money;
    public float MoneyAdded = 400;
    public float Timer = 6;
    public int StartTimer = 0;
    public float TimeRest = 6;

    public Text MoneyText;
    //public Text TimerText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageResto;
    
   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = GameData.Gems.ToString();
        //fxGems.Play ( );
        //MoneyText.text = Money.ToString();
        //TimerText.text = Timer.ToString("0.0");

        //Resto Timer:
        TimerImageResto.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        
        if(StartTimer == 0 ){
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            
            GameData.Gems = GameData.Gems + (int) MoneyAdded;
            //Timer = TimeRest;
            Timer = 20;
            StartTimer = 0;
        }
    }
   
    public void StartBtnClicked(){
        StartTimer = 1;
    }

}
}