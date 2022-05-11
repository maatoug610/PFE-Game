using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MallMoneyManager : MonoBehaviour
{
    public float MoneyAdded = 90;
    public float Timer = 80;
    public int StartTimer = 0;
    public float TimeRest = 10;

    public Text MoneyText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageMall;
    [Space]
	[Header ( "FX" )]
	[SerializeField] ParticleSystem fxGems;
    [Space]
    [Header ("Slider Level")]
    [SerializeField] private Slider sliderLevel;
    
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
            //fxGems.Play ( );
            GameData.Gems = GameData.Gems + (int) MoneyAdded;
            Timer = 20;
            StartTimer = 0;
         
        }
    }
    
    public void SliderLevel(){
        MoneyAdded += 1;
        sliderLevel.value = 1f;
    }
}
