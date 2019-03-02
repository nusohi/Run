using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour {

    public GameObject Target;
    public float SmoothTime = 0.2f;
    public float UpViewRotationX = 55f;
    public Vector3 UpViewOffset;
    public float ViewChangeTime = 0.5f;

    private Vector3 NormalViewOffset;
    private float NormalViewRotationX;
    private Vector3 offset;
    private Vector3 velocity;


	void Start () {
        NormalViewRotationX = transform.rotation.eulerAngles.x;
        NormalViewOffset = transform.position - Target.transform.position;
        offset = NormalViewOffset;
    }
	

	void FixedUpdate () {
        //transform.position = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, Target.transform.position + offset
            , ref velocity, SmoothTime);
	}

    void UpView() {
        DOTween.To(() => offset, x => offset = x, UpViewOffset, ViewChangeTime);
        transform.DOLocalRotate(new Vector3(UpViewRotationX, 0, 0), ViewChangeTime).SetEase(Ease.Linear);
    }

    void NormalView() {
        DOTween.To(() => offset, x => offset = x, NormalViewOffset, ViewChangeTime);
        transform.DOLocalRotate(new Vector3(UpViewRotationX, 0, 0), ViewChangeTime).SetEase(Ease.Linear);
    }
}
