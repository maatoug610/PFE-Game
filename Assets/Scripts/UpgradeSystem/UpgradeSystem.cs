using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{

    //varibales:
    [Header("Upgrade UI")]
    [SerializeField] GameObject UpgradeCanvas;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)){
            if(Input.GetMouseButtonDown(0)){
                if(hit.collider.tag == "Resto2"){
                    print("resto2");
                    UpgradeCanvas.SetActive(true);
                }
            }
        }
    }
}
