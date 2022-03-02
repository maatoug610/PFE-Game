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
    public float Timer = 6;
    public int StartTimer = 0;
    public Text MoneyText;
    public float MoneyAdded = 50;
    
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
        GameData.Gems = GameData.Gems + (int) MoneyAdded;
        IconMoney.SetActive(false);
        StartTimer = 0;

    }
    
}
