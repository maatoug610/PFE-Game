using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoController : MonoBehaviour
{
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageCash;
    [Space]
    [Header ("Canavas Timer")]
    [SerializeField] GameObject CanvasTimer;
    public float MoneyAdded = 0;
    public float Timer = 6;
    int StartTimer = 1;
    public float TimeRest = 6;

    private void OnTriggerEnter(Collider other){
            StartTimer = 0;
            CanvasTimer.SetActive(true);
            Destroy(other.gameObject,6f);    

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         TimerImageCash.fillAmount = Mathf.InverseLerp(0, TimeRest, Timer);
        if(StartTimer == 0 ){
            
            Timer = Timer - 1 * Time.deltaTime;
        }
        if(Timer < 0){
            GameData.Gems = GameData.Gems + (int) MoneyAdded;
            //Timer = TimeRest;
            Timer = 6;
            StartTimer = 1;
            //audioSource.Play();
        }   
    }
}
