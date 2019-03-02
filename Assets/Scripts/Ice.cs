using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ice : MonoBehaviour {

    private bool meltable = true;
    private bool melting = false;

    private bool freezable = true;
    private bool freezing = false;


    [SerializeField]
    private float decreaseScale = 0.2f;

    [SerializeField]
    private float increaseScale = 0.2f;

    [SerializeField]
    private float meltDuration = 1f;

    [SerializeField]
    private float freezeDuration = 1f;

    [SerializeField]
    private float minScale = 0.001f;

    [SerializeField]
    private float maxScale = 0.999f;


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (!melting && meltable && !freezing) {
                // 状态修正
                melting = true;
                freezable = true;
                if (transform.localScale.x - decreaseScale <= minScale) {
                    meltable = false;
                }
                // 融化动画
                float scale = transform.localScale.x - decreaseScale;
                scale = scale < 0f ? 0f : scale;
                transform.DOScale(scale, meltDuration).SetEase(Ease.InOutBounce).OnComplete(MeltOver);
            }
        }
        else if (other.gameObject.tag == "IcePlayer") {
            if (!freezing && freezable && !melting) {
                // 状态修正
                freezing = true;
                meltable = true;
                if (transform.localScale.x + decreaseScale >= maxScale) {
                    freezable = false;
                }
                // 冰冻动画
                float scale = transform.localScale.x + increaseScale;
                scale = scale > 1f ? 1f : scale;
                transform.DOScale(scale, freezeDuration).SetEase(Ease.InOutBounce).OnComplete(FreezeOver);
            }
        }
    }

    // 冰块融化结束回调
    private void MeltOver() {
        melting = false;
        if (!meltable) {
            Destroy(this.gameObject);
        }
    }
    // 冰块冰冻结束回调
    private void FreezeOver() {
        freezing = false;
    }

}
