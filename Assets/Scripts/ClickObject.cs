using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    //varibales:
    // public float TimerCola = 6;
    // public float StartTimerCola = 0;
    // public float TimerRestCola = 6;

    private void Update(){
        //condition of click mouse
      if (Input.GetMouseButtonDown (0))
      {
          //declanche click:
          //StartTimerCola = 1;
          //RaycastHit : detected object.
          RaycastHit hit;
          Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out hit, 100.0f))// 100.0f if the distance of ray
        {
             if (hit.transform != null){
                 Action(hit.transform.gameObject);
             }
        }
      }
    }
private void Action(GameObject go){
    print(go.name);
    // if(go.name == "ColaMachine"){
        
    //     if(StartTimerCola == 1){
    //         TimerCola = TimerCola - 1 * Time.deltaTime; 
    //     }
    //     else if (TimerCola < 0){
    //         TimerCola = TimerRestCola;
    //         StartTimerCola = 0;
    //     }
    // }
}
}
