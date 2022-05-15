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
    [Space ]
    [Header ("Slider Level")]
    [SerializeField] private Slider level_Slider;
    [Space ]
    [Header ("Slider Level 2")]
    [SerializeField] private Slider level_Slider2;
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
        // ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if(Physics.Raycast(ray, out hit)){
        //     if(Input.GetMouseButtonDown(0)){
        //         if(hit.collider.tag == "Resto2" || hit.collider.tag == "Mall" || hit.collider.tag == "Burger Shop 1"){
        //             UpgradeCanvas.SetActive(true);
        //         }
        //     }
        // }
    }
    public void UpgradeMoney(){
       
        level_Slider2.value += 1;
        
        if (level_Slider2.value > 9 ){
             level_Slider.value += 1;
            level_Slider2.value = 1;
            GameData.Gems += 10;
        }
    }
    public void openUpgrade(){
         UpgradeCanvas.SetActive(true);
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
