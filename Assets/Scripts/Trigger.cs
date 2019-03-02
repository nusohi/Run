using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType
{
    Trigger,
    Collider,
}

public class Trigger : MonoBehaviour {

    public TriggerType type = TriggerType.Trigger;
    public string ObjectTag;
    public GameObject CallObject;
    public string CallFunc;

    private void OnTriggerEnter(Collider other) {
        if (type == TriggerType.Trigger && other.tag == ObjectTag) {
            if (CallObject == null)
                other.gameObject.SendMessage(CallFunc);
            else
                CallObject.SendMessage(CallFunc);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (type == TriggerType.Collider && collision.gameObject.tag == ObjectTag) {
            if (CallObject == null)
                collision.gameObject.SendMessage(CallFunc);
            else
                CallObject.SendMessage(CallFunc);
        }
    }

}
