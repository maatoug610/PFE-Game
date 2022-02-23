using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Chronometre_Canvas : MonoBehaviour
{
    [Header ( "Reward UI" )]
	[SerializeField] GameObject ChronometreCanvas;
    [SerializeField] Button openButton;
	[SerializeField] Button closeButton;
    [SerializeField] GameObject BuildNotification;
    


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
    }

    void Initialize ( ) {
            openButton.onClick.RemoveAllListeners ( );
			openButton.onClick.AddListener ( OnOpenButtonClick );

			closeButton.onClick.RemoveAllListeners ( );
			closeButton.onClick.AddListener ( OnCloseButtonClick );
    }

    //  void OnMouseDown(){
    //     if(this.gameObject.name == "Terrain1"){
            
    //     }
    // }
    //Open | Close UI -------------------------------------------------------
		void OnOpenButtonClick ( ) {
			ChronometreCanvas.SetActive ( true );
		}

		void OnCloseButtonClick ( ) {
			ChronometreCanvas.SetActive ( false );
		}
}
