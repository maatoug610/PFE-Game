using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    Animator anim;
    
    private void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start(){
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking",true);
    }

    private void Update(){
        navMeshAgent.destination = movePositionTransform.position;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "RestoCash"){
            anim.SetBool("isWalking",false);
            
        } 
        else if(other.gameObject.tag == "TargetWC"){
            anim.SetBool("isWalking",false);
        }
        
    }
    

}
