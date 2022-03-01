﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

namespace DailyRewardSystem {
public enum BuildBuyType {
		Gems,
	}
public class BuildingTimerBuy : MonoBehaviour
{
    [SerializeField] Text TimerBuild;
    [Space]
    [Header ("Game Object")]
    [SerializeField] GameObject DoneIcon;
    [SerializeField] GameObject BuilderNotification;
    [SerializeField] GameObject Button;
    [SerializeField] GameObject Chronometre;
    [SerializeField] GameObject House1;
    //[SerializeField] GameObject Home1;
    //[SerializeField] Text TimerCounter;
    
    int c=0;
    //Animator m_Animator;
    public static BuildingTimerBuy Instance {get; private set;}

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
        //m_Animator = gameObject.GetComponent<Animator>();
        c = PlayerPrefs.GetInt("c", 0);
        print("c ligne 26: "+c);
        string dateQuitString = PlayerPrefs.GetString ("dateQuit", "");
        if (!dateQuitString.Equals("")) {
           DateTime dateQuit = DateTime.Parse(dateQuitString);
           DateTime dateNow = DateTime.Now;
           if (dateNow > dateQuit) {
               print("dateNow33: "+dateNow);
               print("dateQuit34: "+dateQuit);
               TimeSpan timespan = dateNow - dateQuit;
               print("TimeSpan: "+timespan);
               int seconds = (int)timespan.Seconds; 
               print("seconds40: "+seconds);
               if(c > 0){
               c += seconds; //ajouter le decalage 
               print("c42: "+c);
               }
           }
           PlayerPrefs.SetString("dateQuit","");
        }
        // StartCoroutine("Counter");
    }
 
    IEnumerator Counter(){
        while(true){
            yield return new WaitForSeconds(1f);
            c++;
            print("c in the counter(): "+c);
            //TimerBuild.text = c.ToString();
            TimerBuild.text = $"{c / 60:00}:{c % 60:00}";
            if(c == 20){ // 20 is Timer in seconds 60 = 1 muinte
                BuilderNotification.SetActive ( true );
                DoneIcon.SetActive ( true );
                //m_Animator.SetBool("isBuild", true);
                break;
            }
        }
    }

 //Buy Button Build:
	public void BuyButton(){ 
           if( GameData.Gems >= 1000){  
               StartCoroutine("Counter");
               Button.SetActive (false);
               GameData.Gems -= 1000;
			}
            else if(GameData.Gems < 1000){
                print("Don't Have Money For That !!");
                //m_Animator.SetBool("isBuild", false);
            } else{
                print("Timer Not Complet");
            }   
	}

    void OnApplicationQuit(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        //PlayerPrefs.SetInt("c", c); //Save Time Text
        PlayerPrefs.SetInt("c", 0); //To Restart at zero 0
    }
    
}
}