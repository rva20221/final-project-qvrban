using System;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

public class CutArea : MonoBehaviour
{
    private float cutDepth;
    private bool isBeingCut;

    private Vector3 contactPoint;
    private float currentDistance = 0;

    private void Start()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        cutDepth = bounds.center.y - bounds.min.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife == null || !knife.enabled)
            return;

        contactPoint = knife.Origin;
        isBeingCut = true;

        Debug.Log("Trigger Cut Area Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isBeingCut) return;
        
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife == null || !knife.enabled)
            return;

        currentDistance = Vector3.Distance(knife.Origin, contactPoint);
        Debug.Log(currentDistance);

        if (currentDistance >= cutDepth)
        {
            isBeingCut = false;
            // Do cut animation here
            EventManager.TriggerEvent("onFinishCut");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife == null || !knife.enabled)
            return;
        
        isBeingCut = false;
        if (currentDistance < cutDepth)
        {
            // Try again
        }

        Debug.Log("Trigger Cut Area Exit");
    }
}
