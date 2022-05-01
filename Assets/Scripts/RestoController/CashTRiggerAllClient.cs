using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashTRiggerAllClient : MonoBehaviour
{

    
    public AudioSource audioSource;
    public AudioSource audioEat;
    public float MoneyAdded = 0;
    public float Timer = 10;
    int StartTimer = 1;
    public float TimeRest = 6;
    int r;
    //public Text MoneyText;

    //public Text TimerText;
    [Header("Image Timer")]
    [SerializeField] private Image TimerImageCash;
    [Space]
    [Header("Canvas Timer")]
    [SerializeField] private GameObject CanvasTimer;
    [Space]
    [Header("Fruit Image")]
    [SerializeField] private GameObject[] FoodImage;

    private void OnTriggerEnter(Collider other){
        //Animation...
        
        //Timer
            StartTimer = 0;
            CanvasTimer.SetActive(true);
            int rand = Random.Range(0,FoodImage.Length);
            r = rand;
            FoodImage[rand].gameObject.SetActive(true);
            StartCoroutine("count");
            audioEat.Play();
            Destroy(other.gameObject,10f);    
            
    }

     IEnumerator count(){
        
        yield return new WaitForSeconds(8f);
        FoodImage[r].gameObject.SetActive(false);
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
            Timer = 10;
            StartTimer = 1;
            audioSource.Play();
        }   
    }
}
