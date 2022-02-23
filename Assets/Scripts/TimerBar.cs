using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class TimerBar : MonoBehaviour  , IPointerClickHandler
{
    //[SerializeField] private Image uiFill;
    [Header ("Text Timer")]
    [SerializeField] private Text uiText;
    // duration 6h -> second = 6 * 60 = 360s;
    
    public int Duration;
    private int renainingDuration; 
    private bool Pause;
    //bool Go = false;

    public void OnPointerClick(PointerEventData eventData){
        Pause = !Pause;
    }
    // public void Declanche(){
    //     this.Go = true;
    //     print("Declanche(): "+Go);
    // }

    void Start(){
        //if(Go == true){
        Being ();
        
        
    }

    
    
    
    public void Being(){
        //Go = true;
        renainingDuration = Duration;
        StartCoroutine(UpdateTimer());
    }

   

    private IEnumerator UpdateTimer(){
     while(renainingDuration >= 0)
     {
        if(!Pause){
        uiText.text = $"{renainingDuration / 60:00}:{renainingDuration % 68:00}";
        //uiFill.fillAmount = Mathf.InverseLerp(0, Duration, renainingDuration);
        renainingDuration--;
        yield return new WaitForSeconds(1f);
        }
         yield return null;
     }
    OnEnd();
    }

    private void OnEnd(){
        print("End");
    }
}

