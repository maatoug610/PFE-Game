using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickObject : MonoBehaviour
{

     [SerializeField] private GameObject Canvas_Timer_Resto;
  
     Ray ray;
     RaycastHit hit;
    
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if(Input.GetMouseButtonDown(0)){
                 //Resto:
                 if(hit.collider.name == "Resto"){
                     //Canvas_Timer_Resto.SetActive(true);
                 }
                
             }
            
         }
     }
    
}

