using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;



public class RestoMoneyManager : MonoBehaviour
{
    
    public float MoneyAdded = 250;
    public float Timer = 100;
    public int StartTimer = 0;
    public float TimeRest = 10;
    public Text MoneyText;

    //public Text TimerText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageResto;
    [Space]
	[Header ( "FX" )]
	[SerializeField] ParticleSystem fxGems;
   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        MoneyText.text = GameData.Gems.ToString();
        // if(GameData.Gems >=1000){
        //     GameData.Gems = string.Format("{0}K",(GameData.Gems/1000));
        //     }
        

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
}
