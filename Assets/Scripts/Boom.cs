using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {

    public float Force = 10f;
    public float Radius = 3f;


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Vector3 point = collision.contacts[0].point;
            collision.rigidbody.AddExplosionForce(Force, point, Radius, 3f);
        }
    }
}
