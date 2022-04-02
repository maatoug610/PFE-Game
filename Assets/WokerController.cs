using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokerController : MonoBehaviour
{

    Animator am;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        am = this.transform.parent.GetComponent<Animator>();
       
    }

    private void OnTriggerEnter(Collider other){
        StartCoroutine("Counter");
        print("picked");
        am.SetBool("isPicked",true);
       
    }

    IEnumerator Counter(){
        while(count < 10){
            yield return new WaitForSeconds(1f);
            count ++;
            print(count);
        }
        am.SetBool("isPicked",false);
        count =0;

    }
}
