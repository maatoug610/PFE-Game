using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 touchStart;
    public Camera cam;
    public float groundZ = 0;
// Use this for initialization
void Start () {
}
void Update (){
    if (Input.GetMouseButtonDown(0)){
       touchStart = GetWorldPosition(groundZ);
    }
    if (Input.GetMouseButton(0)){
       Vector3 direction = touchStart - GetWorldPosition(groundZ);
        Camera.main.transform.position += direction;
    }
}

private Vector3 GetWorldPosition(float z){
    float distance;

    Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
    Plane ground = new Plane (Vector3.forward, new Vector3(0,0,z));
    ground.Raycast(mousePos, out distance);
    
    return mousePos.GetPoint(1);       
}
}