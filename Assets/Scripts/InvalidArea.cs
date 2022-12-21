using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife && knife.enabled)
        {
            EventManager.TriggerEvent("onTriggerInvalidArea");
        }
    }
}
