using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
Animator _doorAnim;

private void OnTriggerEnter(Collider other){
   _doorAnim.SetBool("isOpening", true);
}

private void OnTriggerExit(Collider other){
   _doorAnim.SetBool("isOpening", false);
}

// Start is called before the first frane update
void Start()
{
   _doorAnim = this.transform.parent.GetComponent<Animator>();
}

}
