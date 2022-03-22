using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{

    //varibales:
    [Header("Upgrade UI")]
    [SerializeField] GameObject UpgradeCanvas;
    [SerializeField] Button CloseButton;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        //Traitement ..
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)){
            if(Input.GetMouseButtonDown(0)){
                if(hit.collider.tag == "Resto2" || hit.collider.name == "Mall" || hit.collider.name == "Burger Shop 1"){
                    UpgradeCanvas.SetActive(true);
                }
            }
        }
    }

    void Initialize ( ) {
		CloseButton.onClick.RemoveAllListeners ( );
		CloseButton.onClick.AddListener ( OnCloseButtonClick );
    }
    //open canvas timer build 1:
	void OnCloseButtonClick ( ) {
		UpgradeCanvas.SetActive ( false );
	}
}
