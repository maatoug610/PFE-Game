using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{

    private void Update(){
      if (Input.GetMouseButtonDown (0)){
          RaycastHit hit;
          Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out hit, 100.0f))
        {
             if (hit.transform != null){
                 Action(hit.transform.gameObject);
             }
        }
     }
}
private void Action(GameObject go){
    print(go.name);
}
}
