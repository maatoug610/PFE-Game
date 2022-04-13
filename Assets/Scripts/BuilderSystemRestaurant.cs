using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuilderSystemRestaurant : MonoBehaviour
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

    // Raycast to detected object :
    Ray ray;
    RaycastHit hit;
    //Varibales
    //public static BuilderSystem2 Instance {get; private set;}
    int statusClicked3=0;
    [Header("Time in second: 60s -> 1m")]
    int startDay2=54000; //15 hours
    public QuizManager2 quizManager;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
        statusClicked3 = PlayerPrefs.GetInt("statusClicked3", 0);
        startDay2 = PlayerPrefs.GetInt("startDay2", startDay2);
        string dateExitString = PlayerPrefs.GetString ("dateExit2", "");

       
        if (!dateExitString.Equals("")) {
            DateTime dateExit2 = DateTime.Parse(dateExitString);
            DateTime dateNow = DateTime.Now;
            
            if (dateNow > dateExit2 && statusClicked3 == 1 && startDay2 > 0){
                TimeSpan timespan = dateNow - dateExit2;
                //int seconds = (int)timespan.Seconds;
                int seconds = (int)timespan.TotalSeconds;
                startDay2 -= seconds;
             }
            PlayerPrefs.SetString("dateExit2",""); 
        }
        if(statusClicked3 == 1 && startDay2 > 0){
            ButtonBuy.SetActive (false);
            StartCoroutine("Counter2");
        }
        if(startDay2 <= 0){
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
                 
                if(hit.collider.tag == "Terrain_Building3"){
                     if(quizManager.End == true){
                        ChronometreCanvas.SetActive(true);
                    }else{
                        QuizCanvas.SetActive(true);
                    }
                    
               }
                
             }
            
         }
        
    }
     // Button of Start Count Timer1:
    public void StartCounter(){
        if(startDay2 > 0){
        if(GameData.Gems >= 2530){
            GameData.Gems -= 2530;
            StartCoroutine("Counter2");
            ButtonBuy.SetActive (false);
            statusClicked3 = 1;
            PlayerPrefs.SetInt("statusClicked3",statusClicked3);

        }else{
            Debug.Log("Don't Have Money For That !!!");
            StartCoroutine("EnableMinusMoneyPanel");
        }
        }
    }

    //Counter Timer Of Building:
    IEnumerator Counter2 (){
        while(startDay2 > 0){
            yield return new WaitForSeconds(1f);
            startDay2 --;
            //Debug.Log(startDay);
            TimerBuild.text = $"{(startDay2 / 86400) % 365}day:{(startDay2 / 3600) % 24}h:{(startDay2 / 60) % 60}m:{startDay2 % 60}s";
            
        }
        
        PanelTimerBuild.SetActive(false);
        FinishedTimer.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(TerrainBuild);
        Build1.SetActive(true);
        
    }
    //Timer of Show MinusMoney Panel:
    IEnumerator EnableMinusMoneyPanel(){
        MinusMoneyPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        MinusMoneyPanel.SetActive(false);
    }

    //SAVE DATA:
    void saveDATA(){
        DateTime dateExit2 = DateTime.Now;
        PlayerPrefs.SetString("dateExit2", dateExit2.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("statusClicked3",statusClicked3);
        PlayerPrefs.SetInt("startDay2", startDay2); //Save Time Text
        PlayerPrefs.Save();
    }
    //when application is quit:
     void OnApplicationQuit(){
        saveDATA();
    }

    //Destroy:
     void OnDestroy(){
        saveDATA();
    }

    //Paused:
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
	}}

   

