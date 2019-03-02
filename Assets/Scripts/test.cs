using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour {

    private NavMeshAgent agent;

    private GameObject player;


    [SerializeField]
    private float delayTime = 1f;

    [SerializeField]
    private float delayTimer = 0f;
    

    void Awake() {
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }


    void Update() {
        delayTimer += Time.deltaTime;
        if (delayTimer >= delayTime) {
            agent.SetDestination(player.transform.position);
            delayTimer = 0;
        }
    }
}
