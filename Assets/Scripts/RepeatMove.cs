using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum VHType
{
    UpDown,
    LeftRight,
}

public class RepeatMove : MonoBehaviour {

    public VHType type;
    
    public float Up;
    public float Down;
    public float Left;
    public float Right;
    public float Duration = 3f;


    void Start() {
        float start =
            type == VHType.UpDown
            ? transform.position.y
            : transform.position.x;

        float firstUpTime =
            type == VHType.UpDown
            ? ((Up - start) / (Up - Down)) * Duration / 2
            : ((Right - start) / (Right - Left)) * Duration / 2;

        if(type == VHType.UpDown) {
            transform.DOMoveY(Up, firstUpTime).SetEase(Ease.Linear).OnComplete(MoveDown);
        }
        else {
            transform.DOMoveX(Right, firstUpTime).SetEase(Ease.Linear).OnComplete(MoveLeft);
        }
    }

    void MoveUp() {
        transform.DOMoveY(Up, Duration / 2).SetEase(Ease.Linear).OnComplete(MoveDown);
    }

    void MoveDown() {
        transform.DOMoveY(Down, Duration / 2).SetEase(Ease.Linear).OnComplete(MoveUp);
    }

    void MoveLeft() {
        transform.DOMoveX(Left, Duration / 2).SetEase(Ease.Linear).OnComplete(MoveRight);
    }

    void MoveRight() {
        transform.DOMoveX(Right, Duration / 2).SetEase(Ease.Linear).OnComplete(MoveLeft);
    }

}
