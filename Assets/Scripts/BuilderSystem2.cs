using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
namespace BuilderSystemSpace {
public enum Money {
		Gems,
	}
public class BuilderSystem2 : MonoBehaviour
{
    [Header ( "Chronometre UI" )]
    [SerializeField] Text TimerBuild;
    [SerializeField] GameObject ChronometreCanvas;
	[SerializeField] Button closeButton;
    [SerializeField] GameObject ButtonBuy;
    
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
    [Header("Time in second: 60s -> 1m")]
    public int startDay=259200; //3 days
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        statusClicked = PlayerPrefs.GetInt("statusClicked", 0);
        startDay = PlayerPrefs.GetInt("startDay", startDay);
        string dateQuitString = PlayerPrefs.GetString ("dateQuit", "");
        if (!dateQuitString.Equals("")) {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;
            if (dateNow > dateQuit){
                TimeSpan timespan = dateNow - dateQuit;
                //int seconds = (int)timespan.Seconds;
                int seconds = (int)timespan.TotalSeconds;
                startDay -= seconds;
                 }
            PlayerPrefs.SetString("dateQuit",""); 
        }
        if(statusClicked == 1 && startDay > 0){
            ButtonBuy.SetActive (false);
            StartCoroutine("Counter");
        }
        if(startDay <= 0){
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
                 
                if(hit.collider.tag == "Terrain_Building2"){
                    ChronometreCanvas.SetActive(true);
               }
                
             }
            
         }
        
    }
     // Button of Start Count Timer1:
    public void StartCounter(){
        if(startDay > 0){
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
        while(startDay > 0){
            yield return new WaitForSeconds(1f);
            startDay --;
            Debug.Log(startDay);
            TimerBuild.text = $"{(startDay / 86400) % 365}Day:{(startDay / 3600) % 24}H:{(startDay / 60) % 60}m:{startDay % 60}s";
            
        }
        
        PanelTimerBuild.SetActive(false);
        FinishedTimer.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(TerrainBuild);
        Build1.SetActive(true);
        
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
        PlayerPrefs.SetInt("startDay", startDay); //Save Time Text
        PlayerPrefs.SetInt("statusClicked",statusClicked);
        PlayerPrefs.Save();
    }

    //Destroy:
    void OnDestroy(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("startDay", startDay); //Save Time Text
        PlayerPrefs.SetInt("statusClicked",statusClicked);
        PlayerPrefs.Save();
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
