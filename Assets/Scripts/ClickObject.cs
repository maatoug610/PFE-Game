using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickObject : MonoBehaviour
{

     [SerializeField]  GameObject chronometre1;
     [SerializeField]  GameObject chronometre2;
     [SerializeField]  GameObject Upgrade;
     [SerializeField]  GameObject Reaward;
  
     Ray ray;
     RaycastHit hit;
    
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if(Input.GetMouseButtonDown(0)){
                 
                if(hit.collider.name == "TerrainBuild"){
                  chronometre1.SetActive(true);
                  chronometre2.SetActive(false);
                  Upgrade.SetActive(false);
                  Reaward.SetActive(false);
               } else if(hit.collider.tag == "Terrain_Building2"){
                  chronometre1.SetActive(false);
                  chronometre2.SetActive(true);
                  Upgrade.SetActive(false);
                  Reaward.SetActive(false);
               } else if(hit.collider.tag == "Resto2" || hit.collider.name == "Mall" || hit.collider.name == "Burger Shop 1"){
                  chronometre1.SetActive(false);
                  chronometre2.SetActive(false);
                  Upgrade.SetActive(true);
                  Reaward.SetActive(false);
               }
                
             }
            
         }
     }
    
}

