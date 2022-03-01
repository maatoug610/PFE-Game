using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickObject : MonoBehaviour
{

     [SerializeField]  GameObject ChronometreShow;
  
     Ray ray;
     RaycastHit hit;
    
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if(Input.GetMouseButtonDown(0)){
                 
                if(hit.collider.name == "TerrainBuild"){
                  ChronometreShow.SetActive(true);
               }
                
             }
            
         }
     }
    
}

