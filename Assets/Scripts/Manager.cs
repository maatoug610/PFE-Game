using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void HardLevel(){
         SceneManager.LoadScene("Version4");
    }

    public void EasyLevel(){
         SceneManager.LoadScene("");
    }
}
