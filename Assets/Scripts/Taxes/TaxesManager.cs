using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxesManager : MonoBehaviour
{
    [Header ("Attention Canavas")]
    [SerializeField] private GameObject Canvas;
    [Space]
    [Header("Audio ")]
    [SerializeField] public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Confirm(){
        
       Canvas.SetActive(false);
       if(GameData.Gems > 2000){
           GameData.Gems -= 1000; 
           if(GameData.Gems > 3000){
               GameData.Gems -= 2000; 
           }
           if(GameData.Gems > 4000){
               GameData.Gems -= 3000; 
           }
           if(GameData.Gems > 5000){
               GameData.Gems -= 4000; 
           }       
       }
       audioSource.Play();
       
       
    }
}
