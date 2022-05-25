using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public float speed = 5f;
  
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            print("Down: "+transform.position.x);
            
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
             0.0f, 0);
             if(transform.position.x <0 || transform.position.x >= 56){
                 transform.position = new Vector3(35,
             23, -13);
             }
            
            
        }
        else if(Input.GetMouseButton(0)){
            print("Button: "+transform.position.x);
           
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 
            0.0f, 0);
            if(transform.position.x <0 || transform.position.x >= 56){
                 transform.position = new Vector3(35,
              23, -13);
             }
          
        }
    }

   
}