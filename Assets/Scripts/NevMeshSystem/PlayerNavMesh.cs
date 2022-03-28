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
    }

    private void Update(){
        navMeshAgent.destination = movePositionTransform.position;
    }
}
