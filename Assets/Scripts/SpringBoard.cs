using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpringBoard : MonoBehaviour {

    public float ForwardForce = 1f;
    public float UpForce = 5f;
    public float BlinkTime = 0.4f;
    public Color BlinkColor = Color.white;

    private Vector3 mixedForce;
    private Material material;
    private Tweener colorTween;

    private void Start() {
        material = this.GetComponent<MeshRenderer>().material;
        colorTween = material.DOColor(BlinkColor, BlinkTime / 2);
        colorTween.Pause();
        colorTween.SetAutoKill(false);
        colorTween.SetEase(Ease.Linear);

        mixedForce = transform.forward * ForwardForce + new Vector3(0, UpForce, 0);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            collision.rigidbody.AddForce(mixedForce, ForceMode.Impulse);
            colorTween.PlayForward();
            colorTween.OnComplete(colorTween.PlayBackwards);
        }
    }

}
