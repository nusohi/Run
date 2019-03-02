using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchivePoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameManager.Instance.NewArchivePoint(this.gameObject);
        }
    }

}
