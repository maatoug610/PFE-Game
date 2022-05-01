using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerCasino : MonoBehaviour
{

 Animator _doorAnim;

 private void OnTriggerEnter(Collider other){
   _doorAnim.SetBool("isOpenCasino", true);
 }

 private void OnTriggerExit(Collider other){
   _doorAnim.SetBool("isOpenCasino", false);
 }
    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
    }

   
}
