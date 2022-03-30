using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCDoorController : MonoBehaviour
{
    Animator _doorAnim;
    public AudioSource audioSource;
    
    
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageWC;
    [Space]
    [Header("Canvas Timer")]
    [SerializeField] private GameObject CanvasTimer;
   

    public float MoneyAdded = 0;
    public Text MoneyText;
    float Timer = 20;
    int StartTimer = 1;
    public float TimeRest = 15;
    

    private void OnTriggerEnter(Collider other){
        //Animation:
        _doorAnim.SetBool("OpenWC",true);

        //Timer 
        StartTimer = 0;
        CanvasTimer.SetActive(true);
        Destroy(other.gameObject,20f);    
    }

    private void OnTriggerExit(Collider other){
        _doorAnim.SetBool("OpenWC",false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
        
    }

    void Update(){

        TimerImageWC.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        if(StartTimer == 0 ){
            
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            GameData.Gems = GameData.Gems + (int) MoneyAdded;
            //Timer = TimeRest;
            Timer = 20;
            StartTimer = 1;
            //Audio sound :
            audioSource.Play();
        }
    }

   
}
