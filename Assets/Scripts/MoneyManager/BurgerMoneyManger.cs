using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerMoneyManger : MonoBehaviour
{
    public float MoneyAdded = 70;
    public float Timer = 50;
    public int StartTimer = 0;
    public float TimeRest = 10;
    public Text MoneyText;

    [Header("Image Timer")]
    [SerializeField] private Image TimerImageBurger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerImageBurger.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
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
