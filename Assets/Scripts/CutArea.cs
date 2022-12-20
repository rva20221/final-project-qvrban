using System;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

public class CutArea : MonoBehaviour
{
    public float cutDepth;
    private bool isBeingCut;

    private Vector3 contactPoint;
    

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

        float distance = Vector3.Distance(knife.Origin, contactPoint);
        Debug.Log(distance);

        if (distance > cutDepth)
        {
            isBeingCut = false;
            // Do cut animation here
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife == null || !knife.enabled)
            return;

        isBeingCut = false;

        Debug.Log("Trigger Cut Area Exit");
    }
}
