using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BuilderSystemBurger : MonoBehaviour
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
    [Header("Timer Quiz")]
    [SerializeField] private Text TimerText;
    // Raycast to detected object :
    Ray ray;
    RaycastHit hit;
    //Varibales
    //public static BuilderSystem2 Instance {get; private set;}
    int statusClicked2=0;
    [Header("Time in second: 60s -> 1m")]
    [SerializeField] int startDay=60; //1 min

    public QuizManager2 quizManager;
    // Mission Build Complet sound
    public AudioSource audioSource;
    public int Timer = 30;
    

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
        statusClicked2 = PlayerPrefs.GetInt("statusClicked2", 0);
        startDay = PlayerPrefs.GetInt("startDay", startDay);
        slider_store = PlayerPrefs.GetFloat("slider_store", slider_store);

        string dateExitString = PlayerPrefs.GetString ("dateExit", "");

       
        if (!dateExitString.Equals("")) {
            DateTime dateExit = DateTime.Parse(dateExitString);
            DateTime dateNow = DateTime.Now;
            
            if (dateNow > dateExit && statusClicked2 == 1 && startDay > 0){
                TimeSpan timespan = dateNow - dateExit;
                //int seconds = (int)timespan.Seconds;
                int seconds = (int)timespan.TotalSeconds;
                startDay -= seconds;
             }
            PlayerPrefs.SetString("dateExit",""); 
        }
        if(statusClicked2 == 1 && startDay > 0){
            ButtonBuy.SetActive (false);
            StartCoroutine("Counter2");
        }
        if(startDay <= 0){
           //FinishedTimer.SetActive(true); 
           Destroy(TerrainBuild);
           Build1.SetActive(true);
           nextBuild.SetActive(true);
           //store the level bar
           level_Slider.value = slider_store;
           audioSource.Play();
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
                    if(quizManager.End == true){
                        ChronometreCanvas.SetActive(true);
                    }
                    else{
                        QuizCanvas.SetActive(true);
                        StartCoroutine("CounterOfQuiz");
                    }
               }
             }
         }
        
    }
     void LoseGame()
    {
        Timer =25;
    if(QuizCanvas.activeSelf){
        LoseGameCanvas.SetActive(true);
        }
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
        if(startDay > 0){
        if(GameData.Gems >= 1000){
            GameData.Gems -= 1000;
            StartCoroutine("Counter2");
            ButtonBuy.SetActive (false);
            statusClicked2 = 1;
            PlayerPrefs.SetInt("statusClicked2",statusClicked2);

        }else{
            Debug.Log("Don't Have Money For That !!!");
            StartCoroutine("EnableMinusMoneyPanel");
        }
        }
    }

    //Counter Timer Of Building:
    IEnumerator Counter2 (){
        while(startDay > 0){
            yield return new WaitForSeconds(1f);
            startDay --;
            //Debug.Log(startDay);
            TimerBuild.text = $"{(startDay / 86400) % 365}day:{(startDay / 3600) % 24}h:{(startDay / 60) % 60}m:{startDay % 60}s";
            
        }
        
        PanelTimerBuild.SetActive(false);
        FinishedTimer.SetActive(true);
        yield return new WaitForSeconds(2f);
        Destroy(TerrainBuild);
        Build1.SetActive(true);
        nextBuild.SetActive(true);
        audioSource.Play();
        level_Slider.value += 2;
        slider_store = level_Slider.value;
        PlayerPrefs.SetFloat("slider_store",slider_store);
        
    }
    //Timer of Show MinusMoney Panel:
    IEnumerator EnableMinusMoneyPanel(){
        MinusMoneyPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        MinusMoneyPanel.SetActive(false);
    }

    //SAVE DATA:
    void saveDATA(){
        DateTime dateExit = DateTime.Now;
        PlayerPrefs.SetString("dateExit", dateExit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("statusClicked2",statusClicked2);
        PlayerPrefs.SetInt("startDay", startDay); //Save Time Text
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
	}
}

