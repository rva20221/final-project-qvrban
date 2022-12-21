using System;
using System.Collections;
using System.Collections.Generic;
using HintSystem;
using UnityEngine;

public class InvalidArea : MonoBehaviour
{
    private void Start()
    {
        EventManager.AddListener("onQurbanSuccess", delegate
        {
            enabled = false;
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife && knife.isReady && enabled)
        {
            Debug.Log("Invalid Area");
            EventManager.TriggerEvent("onQurbanFailed");
            EventManager.TriggerHintEvent("onFinishQurbanHint", new HintEventData(HintManager.TryGetHintCollection("QurbanFailed")));
        }
    }
}
