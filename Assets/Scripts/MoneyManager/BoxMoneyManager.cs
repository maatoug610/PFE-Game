using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.EventSystems;

public class BoxMoneyManager : MonoBehaviour
{
    [Header ("Money Icon UI")]
    [SerializeField] GameObject IconMoney;
    [Space]
	[Header ( "FX" )]
    [SerializeField] ParticleSystem fxGems;
    public float Timer = 10;
    public float MoneyAdded = 50;
    public int StartTimer = 1;
    public Text MoneyText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = GameData.Gems.ToString();
        if(StartTimer == 0 ){
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            IconMoney.SetActive(true);        
            Timer = 20;
            StartTimer = 0;
        }
    }

    public void BtnStart(){
        //fxGems.Play ( );
        GameData.Gems = GameData.Gems + (int) MoneyAdded;
        IconMoney.SetActive(false);
        StartTimer = 0;

    }
    
}
