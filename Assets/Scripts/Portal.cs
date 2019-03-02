using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Portal : MonoBehaviour {

    public GameObject BrotherPortal;
    public float TransferDistance;
    public float CoolingTime;
    public Color BlinkColor;
    public float BlinkTime;
    
    private bool transferrable = true;
    private float coolTimer = 0f;

    private Material material;
    private Tweener colorTween;

    private void Start() {
        material = this.GetComponent<MeshRenderer>().material;
        colorTween = material.DOColor(BlinkColor, BlinkTime / 2);
        colorTween.Pause();
        colorTween.SetAutoKill(false);
    }


    void Update() {
        if (!transferrable) {
            coolTimer += Time.deltaTime;
        }
        if (coolTimer >= CoolingTime) {
            transferrable = true;
            coolTimer = 0f;
        }
    }


    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (Vector3.Distance(other.transform.position, transform.position) < TransferDistance) {
                BrotherPortal.SendMessage("Transfer", other.gameObject);
                transferrable = false;
                colorTween.PlayForward();
                colorTween.OnComplete(colorTween.PlayBackwards);
            }
        }
    }

    // 转移至此物体处
    public void Transfer(GameObject Object) {
        if (transferrable) {
            Object.transform.position = transform.position;
        }
    }
}
