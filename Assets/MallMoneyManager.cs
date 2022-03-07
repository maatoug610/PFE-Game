using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MallMoneyManager : MonoBehaviour
{
    public float MoneyAdded = 400;
    public float Timer = 6;
    public int StartTimer = 0;
    public float TimeRest = 6;

    public Text MoneyText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageMall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = GameData.Gems.ToString();
        //Mall Timer:
        TimerImageMall.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        if(StartTimer == 0 ){
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            GameData.Gems = GameData.Gems + (int) MoneyAdded;
            Timer = 20;
            StartTimer = 0;
        }
    }
}
