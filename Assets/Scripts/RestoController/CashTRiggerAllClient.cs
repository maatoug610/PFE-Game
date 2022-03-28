using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashTRiggerAllClient : MonoBehaviour
{

    Animator _clientAnim;
    public float MoneyAdded = 0;
    public float Timer = 10;
    int StartTimer = 1;
    public float TimeRest = 6;
    //public Text MoneyText;

    //public Text TimerText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageCash;
    [Space]
    [Header("Canvas Timer")]
    [SerializeField] private GameObject CanvasTimer;
    

    private void OnTriggerEnter(Collider other){
        //Anination...
        //Timer
            StartTimer = 0;
            CanvasTimer.SetActive(true);
            Destroy(other.gameObject,10f);    
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _clientAnim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      TimerImageCash.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        if(StartTimer == 0 ){
            
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            //GameData.Gems = GameData.Gems + (int) MoneyAdded;
            
            //Timer = TimeRest;
            Timer = 10;
            StartTimer = 1;
        }   
    }
}
