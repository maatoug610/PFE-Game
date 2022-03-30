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
    [Space]
    [Header("Sound Claim")]
    [SerializeField] AudioClip CollectSound;

 
    float Timer = 20;
    public float MoneyAdded = 50;
    int StartTimer = 0;
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

    public void Collect(){
        //sound collect
        AudioSource.PlayClipAtPoint(CollectSound,transform.position,0.5f);
        //fxGems.Play ( );
        GameData.Gems = GameData.Gems + (int) MoneyAdded;
        IconMoney.SetActive(false);
        Timer = 20;
    }
    
}
