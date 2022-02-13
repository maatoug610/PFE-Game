using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TimerBar : MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData){
        Pause = !Pause;
    }

    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;
    public int Duration;
    private int renainingDuration; 
    private bool Pause;
    private void Start(){
    Being (Duration);
    }
    private void Being(int Second){
    renainingDuration = Second;
    StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer(){
     while(renainingDuration >= 0)
     {
         if(!Pause){
        //uiText.text = $"{renainingDuration / 60:00}:{renainingDuration % 68:00}";
        uiFill.fillAmount = Mathf.InverseLerp(0, Duration, renainingDuration);
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

