using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public GameObject canvasReward;
    public GameObject canvasChro1;
    public GameObject canvasChro2;
    public GameObject canvasChro3; 
    public GameObject canvasUpgrade;
    public GameObject canvasQuestion; 
    public GameObject canvasQuestion2;
    public GameObject canvasQuestion3;


    // Start is called before the first frame update
    void Update()  
    {
        
        if(canvasReward.activeSelf){
           
            canvasChro1.SetActive(false);
            canvasChro2.SetActive(false);
            canvasChro3.SetActive(false);
            canvasUpgrade.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasQuestion3.SetActive(false);
            //Time.timeScale = 0;
        }
        else if(canvasChro1.activeSelf){
            canvasReward.SetActive(false);
            canvasChro2.SetActive(false);
            canvasChro3.SetActive(false);
            canvasUpgrade.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasQuestion3.SetActive(false);
        }
        else if(canvasChro2.activeSelf){
            canvasChro1.SetActive(false);
            canvasReward.SetActive(false);
            canvasChro3.SetActive(false);
            canvasUpgrade.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasQuestion3.SetActive(false);
        }
        else if(canvasChro3.activeSelf){
            canvasChro1.SetActive(false);
            canvasChro2.SetActive(false);
            canvasReward.SetActive(false);
            canvasUpgrade.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasQuestion3.SetActive(false);
        }
       
        else if(canvasQuestion.activeSelf){
            canvasChro1.SetActive(false);
            canvasChro2.SetActive(false);
            canvasChro3.SetActive(false);
            canvasReward.SetActive(false);
            canvasUpgrade.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasQuestion3.SetActive(false);

        }
        else if(canvasQuestion2.activeSelf){
            canvasChro1.SetActive(false);
            canvasChro2.SetActive(false);
            canvasChro3.SetActive(false);
            canvasReward.SetActive(false);
            canvasUpgrade.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion3.SetActive(false);

        }
        else if(canvasQuestion3.activeSelf){
            canvasChro1.SetActive(false);
            canvasChro2.SetActive(false);
            canvasChro3.SetActive(false);
            canvasReward.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasUpgrade.SetActive(false);
        }
         else if(canvasUpgrade.activeSelf){
            canvasChro1.SetActive(false);
            canvasChro2.SetActive(false);
            canvasChro3.SetActive(false);
            canvasReward.SetActive(false);
            canvasQuestion.SetActive(false);
            canvasQuestion2.SetActive(false);
            canvasQuestion3.SetActive(false);
        }

        

    }

    
}
