using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuildSystemCasino : MonoBehaviour
{
    [Header ( "Chronometre UI" )]
    [SerializeField] Text TimerBuild;
    [SerializeField] GameObject ChronometreCanvas;
    [SerializeField] GameObject QuizCanvas;
    public GameObject LoseGameCanvas;
	[SerializeField] Button closeButton;
    [SerializeField] GameObject ButtonBuy;
    
    
    [SerializeField] GameObject FinishedTimer;
    [SerializeField] GameObject MinusMoneyPanel;
    [SerializeField] GameObject PanelTimerBuild;
    [Space]
    [Header("Builing object")]
    [SerializeField] GameObject Build1;
    [SerializeField] GameObject TerrainBuild;
    [SerializeField] GameObject nextBuild;
    [Space ]
    [Header ("Slider Level")]
    [SerializeField] private Slider level_Slider;
    float slider_store;
    [Space]
    [Header ("Attention Screen Canvas")]
    [SerializeField] private GameObject AttentionCanvas;
    [Space]
    [Header("Timer Quiz")]
    [SerializeField] private Text TimerText;
    // Raycast to detected object :
    Ray ray;
    RaycastHit hit;
    //Varibales
    //public static BuilderSystem2 Instance {get; private set;}
    int statusClicked4=0;
    [Header("Time in second: 60s -> 1m")]
    [SerializeField] int startDay4=60; //1 min
    public QuizManager4 quizManager;
    // Mission Build Complet sound
    [SerializeField] private AudioSource audioSource;
    public int Timer = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
        statusClicked4 = PlayerPrefs.GetInt("statusClicked4", 0);
        startDay4 = PlayerPrefs.GetInt("startDay4", startDay4);
        slider_store = PlayerPrefs.GetFloat("slider_store", slider_store);

        string dateExitString = PlayerPrefs.GetString ("dateExit4", "");

       
        if (!dateExitString.Equals("")) {
            DateTime dateExit4 = DateTime.Parse(dateExitString);
            DateTime dateNow = DateTime.Now;
            
            if (dateNow > dateExit4 && statusClicked4 == 1 && startDay4 > 0){
                TimeSpan timespan = dateNow - dateExit4;
                //int seconds = (int)timespan.Seconds;
                int seconds = (int)timespan.TotalSeconds;
                startDay4 -= seconds;
             }
            PlayerPrefs.SetString("dateExit4",""); 
        }
        if(statusClicked4 == 1 && startDay4 > 0){
            ButtonBuy.SetActive (false);
            StartCoroutine("Counter2");
        }
        if(startDay4 <= 0){
           //FinishedTimer.SetActive(true); 
           Destroy(TerrainBuild);
           Build1.SetActive(true);
           nextBuild.SetActive(true);
           //store the level bar
           level_Slider.value = slider_store;
           audioSource.Play();
           StartCoroutine("AttentionCounter");
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
                 
                if(hit.collider.tag == "Terrain_Building4"){
                     if(quizManager.End == true){
                        ChronometreCanvas.SetActive(true);
                    }else{
                        QuizCanvas.SetActive(true);
                        StartCoroutine("CounterOfQuiz");
                    }
                    
               }
                
             }
            
         }
        
    }
    void LoseGame()
    {
        LoseGameCanvas.SetActive(true);
        QuizCanvas.SetActive(false);
        GameData.Gems -=20;
        StartCoroutine("ActivePanel");
    }
    IEnumerator CounterOfQuiz(){
     while(Timer > 0){
        yield return new WaitForSeconds(1f);
        Timer --;
        TimerText.text = $"{(Timer / 60) % 60}m:{Timer % 60}s";
        }
        LoseGame();
    }
    IEnumerator ActivePanel(){
        yield return new WaitForSeconds(2f);
        LoseGameCanvas.SetActive(false);
    }
     // Button of Start Count Timer1:
    public void StartCounter(){
        if(startDay4 > 0){
        if(GameData.Gems >= 3002){
            GameData.Gems -= 3000;
            StartCoroutine("Counter2");
            ButtonBuy.SetActive (false);
            statusClicked4 = 1;
            PlayerPrefs.SetInt("statusClicked4",statusClicked4);

        }else{
            Debug.Log("Don't Have Money For That !!!");
            StartCoroutine("EnableMinusMoneyPanel");
        }
        }
    }

    //Counter Timer Of Building:
    IEnumerator Counter2 (){
        while(startDay4 > 0){
            yield return new WaitForSeconds(1f);
            startDay4 --;
            //Debug.Log(startDay);
            TimerBuild.text = $"{(startDay4 / 86400) % 365}day:{(startDay4 / 3600) % 24}h:{(startDay4 / 60) % 60}m:{startDay4 % 60}s";
            
        }
        
        PanelTimerBuild.SetActive(false);
        FinishedTimer.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(TerrainBuild);
        Build1.SetActive(true);
        nextBuild.SetActive(true);
        audioSource.Play();
        StartCoroutine("AttentionCounter");
        level_Slider.value += 4;
        slider_store = level_Slider.value;
        PlayerPrefs.SetFloat("slider_store",slider_store);
        
    }
    //Timer of Show MinusMoney Panel:
    IEnumerator EnableMinusMoneyPanel(){
        MinusMoneyPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        MinusMoneyPanel.SetActive(false);
    }

    //Timer of Attention Panel
    IEnumerator AttentionCounter(){
        yield return new WaitForSeconds(5f);
        if(GameData.Gems > 2000){
        AttentionCanvas.SetActive(true);
        }
        
    }

    //SAVE DATA:
    void saveDATA(){
        DateTime dateExit4 = DateTime.Now;
        PlayerPrefs.SetString("dateExit4", dateExit4.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("statusClicked4",statusClicked4);
        PlayerPrefs.SetInt("startDay4", startDay4); //Save Time Text
        PlayerPrefs.SetFloat("slider_store",slider_store);
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

   

