using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace BuilderSystemSpace {
public enum MoneyType {
		Gems,
	}
public class BuilderSystem : MonoBehaviour
{

    [Header ( "Chronometre UI" )]
    [SerializeField] Text TimerBuild;
	[SerializeField] GameObject ChronometreCanvas;
	[SerializeField] Button closeButton;
    [SerializeField] GameObject ButtonBuy;
    [SerializeField] GameObject IconClose;
    [SerializeField] GameObject FinishedTimer;
    [SerializeField] GameObject MinusMoneyPanel;
    [SerializeField] GameObject PanelTimerBuild;
    [Space]
    [Header("Builing object")]
    [SerializeField] GameObject Build1;
    [SerializeField] GameObject TerrainBuild;
    
    // Raycast to detected object :
    Ray ray;
    RaycastHit hit;
    //Varibales
    public static BuilderSystem Instance {get; private set;}
    int statusClicked=0;
    int StartCount=0;
    [Header("Time in second: 60s -> 1m")]
    public int EndTime =60;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
        statusClicked = PlayerPrefs.GetInt("statusClicked", 0);
        StartCount = PlayerPrefs.GetInt("StartCount", 0);
        
        string dateQuitString = PlayerPrefs.GetString ("dateQuit", "");
        if (!dateQuitString.Equals("")) {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;
            if (dateNow > dateQuit){
                TimeSpan timespan = dateNow - dateQuit;
                //int seconds = (int)timespan.Seconds;
                int seconds = (int)timespan.TotalSeconds;
                StartCount += seconds;
                // if(StartCount > 0){
                //     StartCount += seconds;
                // }
            }
            PlayerPrefs.SetString("dateQuit",""); 
        }

        
        //Tester of Button Status and Timer end :
        if(statusClicked == 1 && StartCount < EndTime){
            ButtonBuy.SetActive (false);
            StartCoroutine("Counter");
        }
        if(StartCount >= EndTime){
           //FinishedTimer.SetActive(true); 
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
                 
                if(hit.collider.name == "barrel"){
                    print("Detected");
                  ChronometreCanvas.SetActive(true);
               }
                
             }
            
         }
    }
    // Button of Start Count Timer:
    public void StartCounter(){
        if(StartCount < EndTime){
        if(GameData.Gems >= 1000){
            GameData.Gems -= 1000;
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
        while(StartCount != EndTime){
            yield return new WaitForSeconds(1f);
            StartCount++;
            Debug.Log(StartCount);
            TimerBuild.text = $"{StartCount / 60:00}:{StartCount % 60:00}";
            
        }
        IconClose.SetActive(true);
        PanelTimerBuild.SetActive(false);
        FinishedTimer.SetActive(true);
        yield return new WaitForSeconds(1f);
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

    //when application is quit:
    void OnApplicationQuit(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("StartCount", StartCount); //Save Time Text
        PlayerPrefs.SetInt("statusClicked",statusClicked);
        PlayerPrefs.Save();
    }

    //Destroy:
    void OnDestroy(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("StartCount", StartCount); //Save Time Text
        PlayerPrefs.SetInt("statusClicked",statusClicked);
        PlayerPrefs.Save();
    }

    //Paues:
     void OnApplicationPause(bool pauseStatus){
         Debug.Log("The Application is paused: "+ pauseStatus);
         if (pauseStatus)
        {
            DateTime dateQuit = DateTime.Now;
            PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
            PlayerPrefs.SetInt("StartCount", StartCount); //Save Time Text
            PlayerPrefs.SetInt("statusClicked",statusClicked);
            PlayerPrefs.Save();
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
}