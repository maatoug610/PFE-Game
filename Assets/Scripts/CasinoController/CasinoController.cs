using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasinoController : MonoBehaviour
{
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageCash;
    [Space]
    [Header ("Canavas Timer")]
    [SerializeField] private GameObject CanvasTimer;
    [Space]
    [Header ("Players")]
    [SerializeField] private GameObject PlayerPoker;
    [SerializeField] private GameObject PlayerPingPong;
     [Space]
    [Header ("Slider Level")]
    [SerializeField] private Slider sliderLevel;
    
    public float MoneyAdded = 0;
    public float Timer = 7;
    int StartTimer = 1;
    public float TimeRest = 6;

    private void OnTriggerEnter(Collider other){
            StartTimer = 0;
            CanvasTimer.SetActive(true);
            Destroy(other.gameObject,6f);   
            StartCoroutine("Counter");

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
            Timer = 7;
            StartTimer = 1;
            PlayerPoker.SetActive(true);
            PlayerPingPong.SetActive(true);
            //audioSource.Play();
        }   
    }

    IEnumerator Counter(){
        yield return new WaitForSeconds(30f);
          PlayerPoker.SetActive(false);
          PlayerPingPong.SetActive(false);
    }

    public void SliderLevel(){
        MoneyAdded += 1;
        sliderLevel.value = 1f;
    }
}
