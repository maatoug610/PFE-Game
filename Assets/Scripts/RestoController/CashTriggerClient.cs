using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashTriggerClient : MonoBehaviour
{
    Animator _clientAnim;
    public float MoneyAdded = 50;
    public float Timer = 100;
    int StartTimer = 1;
    public float TimeRest = 10;
    public Text MoneyText;

    //public Text TimerText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageCash;
    [Space]
    [Header("Player")]
    [SerializeField] private GameObject Client1;
    [SerializeField] private GameObject Client2;

    private void OnTriggerEnter(Collider other){
        //Anination...
        //Timer
        StartTimer = 0;
        print("detected");
        
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
            Destroy(Client1);
            Destroy(Client2);
            //Timer = TimeRest;
            Timer = 20;
            StartTimer = 1;
        }
    }

 
}
