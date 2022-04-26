﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class BuilderSystem : MonoBehaviour
{

    [Header ( "Chronometre UI" )]
    [SerializeField] Text TimerBuild;
    [SerializeField] GameObject ChronometreCanvas;
    [SerializeField] GameObject QuizCanvas;
	[SerializeField] Button closeButton;
    [SerializeField] GameObject ButtonBuy;
    
    [SerializeField] GameObject FinishedTimer;
    [SerializeField] GameObject MinusMoneyPanel;
    [SerializeField] GameObject PanelTimerBuild;
    [Space]
    [Header("Builing object")]
    [SerializeField] GameObject Build1;
    [SerializeField] GameObject TerrainBuild;
    [Header("Time in second: 60s -> 1m")]// 6h -> 21600s// 3day -> 259200
    int StartCount=21600; 
    //int StartCount = 0;
    //public int EndTime = 21600;
    // Raycast to detected object :
    Ray ray;
    RaycastHit hit;
    //Varibales
    public static BuilderSystem Instance {get; private set;}
    int statusClicked=0;
     public QuizManager3 quizManager;
    
    
    // void Awake(){
    //     if(Instance == null){
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     } else{
    //         Destroy(gameObject);
    //     }
    // }


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
        statusClicked = PlayerPrefs.GetInt("statusClicked", 0);
        StartCount = PlayerPrefs.GetInt("StartCount", StartCount);
        
        string dateQuitString = PlayerPrefs.GetString ("dateQuit", "");
        if (!dateQuitString.Equals("")) {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;
            if (dateNow > dateQuit && statusClicked == 1 && StartCount > 0){
               
                TimeSpan timespan = dateNow - dateQuit;
                //int seconds = (int)timespan.Seconds;
                int seconds = (int)timespan.TotalSeconds;
                StartCount -= seconds;
                //StartCount += seconds;
            }
            PlayerPrefs.SetString("dateQuit",""); 
        }

        
        //Tester of Button Status and Timer end :
        if(statusClicked == 1 && StartCount > 0){
        //if(statusClicked == 1 && StartCount < EndTime){
            ButtonBuy.SetActive (false);
            StartCoroutine("Counter");
        }
        if(StartCount <= 0){
        //if(StartCount >= EndTime){
           FinishedTimer.SetActive(true); 
           Destroy(TerrainBuild);
           Build1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Code Of Detected object With mouse:
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if(Input.GetMouseButtonDown(0)){
                 
                if(hit.collider.tag == "Terrain_Building"){
                    if(quizManager.End == true){
                        ChronometreCanvas.SetActive(true);
                    }
                   else{
                       QuizCanvas.SetActive(true);
                   }

                   

               }
                
             }
            
         }
    }
    // Button of Start Count Timer1:
    public void StartCounter(){
        if(StartCount > 0){
        //if(StartCount < EndTime){
        if(GameData.Gems >= 500){
            GameData.Gems -= 500;
            StartCoroutine("Counter");
            ButtonBuy.SetActive (false);
            statusClicked = 1;
            PlayerPrefs.SetInt("statusClicked",statusClicked);

        }else{
            Debug.Log("Don't Have Money For That !!!");
            StartCoroutine("EnableMinusMoneyPanel");
        }
        }
    }

   

    //Counter Timer Of Building:
    IEnumerator Counter (){
        // while(StartCount != EndTime){
        //     yield return new WaitForSeconds(1f);
        //     StartCount++;
        //     Debug.Log(StartCount);
        //     //TimerBuild.text = $"{StartCount / 60:00}:{StartCount % 60:00}";
        //     TimerBuild.text = $"{(StartCount / 3600) % 24}H:{(StartCount / 60) % 60}m:{StartCount % 60}s";
            
        // }
        while(StartCount > 0){
            yield return new WaitForSeconds(1f);
            StartCount --;
            //Debug.Log(StartCount);
            TimerBuild.text = $"{(StartCount / 3600) % 24}H:{(StartCount / 60) % 60}m:{StartCount % 60}s";
        }
        
        PanelTimerBuild.SetActive(false);
        FinishedTimer.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(TerrainBuild);
        Build1.SetActive(true);
        //save Build active:
    }
    
    
    
    //Timer of Show MinusMoney Panel:
    IEnumerator EnableMinusMoneyPanel(){
        MinusMoneyPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        MinusMoneyPanel.SetActive(false);
    }

    //SAVE DATA:
    void saveDATA(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit",dateQuit.ToString());
        PlayerPrefs.SetInt("StartCount", StartCount); //Save Time Text
        PlayerPrefs.SetInt("statusClicked",statusClicked);
        PlayerPrefs.Save();
    }

    // when application is quit:
     void OnApplicationQuit(){
        saveDATA();
    }

    //when application is destroyed:
    void OnDestroy(){
        saveDATA();
    }
   
    //when application is Paused:
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            saveDATA();
        }
    }
       
    void Initialize ( ) {
		closeButton.onClick.RemoveAllListeners ( );
		closeButton.onClick.AddListener ( OnCloseButtonClick );
    }
    //open canvas timer build 1:
	void OnCloseButtonClick ( ) {
		ChronometreCanvas.SetActive ( false );
	}
}
