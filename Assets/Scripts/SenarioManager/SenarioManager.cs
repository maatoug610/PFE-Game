using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SenarioManager : MonoBehaviour
{
    [Header("describe Canvas")]
    [SerializeField] private GameObject canvas;
    [Space]
    [SerializeField] private Image Shop;
    [Header("Describe Canvas")]
    [SerializeField] private GameObject describe1;
    [SerializeField] private GameObject describe2;

   
    // Start is called before the first frame update
    void Start()
    {
      
            
        canvas.SetActive(true);
   
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void Next(){
        GameData.Gems += 550;
        describe1.SetActive(false);
        describe2.SetActive(true);
    }
}
