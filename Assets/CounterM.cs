using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CounterM : MonoBehaviour
{
    [SerializeField] Text TimerBuild;
    public int start;

    // Start is called before the first frame update
    void Start()
    {
        start = PlayerPrefs.GetInt("start", start);
        print(start);
        string dateQuitString = PlayerPrefs.GetString ("dateQuit", "");
        if (!dateQuitString.Equals("")) {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;
            if (dateNow > dateQuit){
                TimeSpan timespan = dateNow - dateQuit;
                int seconds = (int)timespan.TotalSeconds;
                start -= seconds;
                print("Line 26: "+start);
                
            }
            PlayerPrefs.SetString("dateQuit",""); 
        }
        StartCoroutine("CounterMinus");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CounterMinus(){
        while(start > 0){
            yield return new WaitForSeconds(1f);
            start --;
            TimerBuild.text = $"{(start / 3600) % 24}:{(start / 60) % 60}:{start % 60}";
        }
    }
    void OnApplicationQuit(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("start", start); //Save Time Text
        PlayerPrefs.Save();
    }

     void OnDestroy(){
        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString()); // Save date Quit game
        PlayerPrefs.SetInt("start", start); //Save Time Text
        PlayerPrefs.Save();
    }
}
