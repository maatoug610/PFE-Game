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
    

    public static BuilderSystem Instance {get; private set;}
    int statusClicked=0;
    int StartCount=0;
    [Header("Time in second: 60s -> 1m")]
    public int EndTime=60;


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
                int seconds = (int)timespan.Seconds;
                if(StartCount > 0){
                    StartCount += seconds;
                }
            }
            PlayerPrefs.SetString("dateQuit","");
            
        }
        print(statusClicked);
        if(statusClicked == 1){
            StartCoroutine("Counter");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartCounter(){
        
        if( GameData.Gems >= 1000){
            GameData.Gems -= 1000;
            StartCoroutine("Counter");
            ButtonBuy.SetActive (false);
            statusClicked = 1;
            PlayerPrefs.SetInt("statusClicked",statusClicked);

        }
        else{
            Debug.Log("Don't Have Money For That !!!");
        }
    }
    IEnumerator Counter (){
        while(StartCount != EndTime){
            yield return new WaitForSeconds(1f);
            StartCount++;
            Debug.Log(StartCount);
            TimerBuild.text = $"{StartCount / 60:00}:{StartCount % 60:00}";
        }
        IconClose.SetActive(true);
    }

    void OnApplicationQuit(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("StartCount", StartCount); //Save Time Text
        PlayerPrefs.SetInt("statusClicked",statusClicked);
    }
    
    void Initialize ( ) {
		closeButton.onClick.RemoveAllListeners ( );
		closeButton.onClick.AddListener ( OnCloseButtonClick );
    }

	void OnCloseButtonClick ( ) {
		ChronometreCanvas.SetActive ( false );
	}
}
}