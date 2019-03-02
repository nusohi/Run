using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShrinkNeedles : MonoBehaviour
{
    public float DownValue = 0f;
    public float Duration = 0.5f;
    public Transform[] Needles;

    void Shrink() {
        foreach (Transform needle in Needles) {
            if (needle != null) {
                needle.DOLocalMoveY(DownValue, Duration);
                Destroy(needle.gameObject, Duration);
            }
        }
    }

}
