using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : MonoBehaviour {
    
    public float DelayTime = 1f;
    public float DelayTimer = 0f;
    public float OverlapEnhance = 0.5f;

    private CapsuleCollider freezeCollier;
    private NavMeshAgent agent;
    private GameObject player;


    void Awake () {
        freezeCollier = this.GetComponent<CapsuleCollider>();
        agent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
	}
	

	void Update () {
        Vector3 target = player.transform.position;
        DelayTimer += Time.deltaTime;
        if (DelayTimer >= DelayTime) {
            agent.SetDestination(player.transform.position);
            DelayTimer = 0;
        }
	}


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "IcePlayer") {
            freezeCollier.radius += OverlapEnhance;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "IcePlayer") {
            freezeCollier.radius -= OverlapEnhance;
        }
    }

}
