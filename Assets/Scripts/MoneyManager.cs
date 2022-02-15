using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyManager : MonoBehaviour
{
    public float Money = 0;
    public float MoneyAdded = 400;
    public float Timer = 6;
    public int StartTimer = 0;
    public float TimeRest = 6;

    public Text MoneyText;
    public Text TimerText;
    [SerializeField] private Image TimerImage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoneyText.text = Money.ToString("C2");
        
        TimerText.text = Timer.ToString("0.0");
        TimerImage.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        if(StartTimer == 1 ){
            Timer = Timer - 1 * Time.deltaTime; 
        }
        if(Timer < 0){
            Money = Money + MoneyAdded;
            Timer = TimeRest;
            StartTimer = 0;
        }
    }

    public void StartBtnClicked(){
        StartTimer = 1;
    }

    public void ClaimMoney(){
        MoneyText.text = Money.ToString("C2");
    }
}
