using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Axis
{
    X,
    Y,
    Z
}

public class Laser : MonoBehaviour {

    public Axis axis;
    public Vector3 StartRotation;
    public Vector3 EndRotation;
    public float Duration;
    

    private void Start() {

        float angle = 0f,
            firstAngle = 0f,
            firstRotateTime;

        switch (axis) {
            case Axis.X:
                angle = EndRotation.x - StartRotation.x;
                firstAngle = EndRotation.x - transform.rotation.eulerAngles.x;
                break;
            case Axis.Y:
                angle = EndRotation.y - StartRotation.y;
                firstAngle = EndRotation.y - transform.rotation.eulerAngles.y;
                break;
            case Axis.Z:
                angle = EndRotation.z - StartRotation.z;
                firstAngle = EndRotation.z - transform.rotation.eulerAngles.z;
                break;
            default:
                break;
        }
        firstAngle %= 360;
        firstRotateTime = (firstAngle / angle) * (Duration / 2);

        transform.DOLocalRotate(EndRotation, firstRotateTime).SetEase(Ease.Linear).OnComplete(RotateBack);
    }

    private void Rotate() {
        transform.DOLocalRotate(EndRotation, Duration / 2).SetEase(Ease.Linear).OnComplete(RotateBack);
    }

    private void RotateBack() {
        transform.DOLocalRotate(StartRotation, Duration / 2).SetEase(Ease.Linear).OnComplete(Rotate);
    }

}
