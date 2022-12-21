using System;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer.Samples;
using HintSystem;
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
        if (knife == null || !knife.isReady || !enabled)
            return;

        contactPoint = knife.Origin;
        isBeingCut = true;


        Debug.Log("Trigger Cut Area Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isBeingCut || !enabled) return;
        
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife == null || !knife.isReady)
            return;
        

        currentDistance = Vector3.Distance(knife.Origin, contactPoint);
        Debug.Log(currentDistance);
        
        if (currentDistance >= cutDepth)
        {
            isBeingCut = false;
            EventManager.TriggerEvent("onQurbanSuccess");
            EventManager.TriggerHintEvent("onFinishQurbanHint", new HintEventData(HintManager.TryGetHintCollection("QurbanSuccess")));
            Debug.Log("Success Cut");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var knife = other.gameObject.GetComponent<Knife>();
        if (knife == null || !knife.isReady || !enabled)
            return;
        
        isBeingCut = false;
        if (currentDistance < cutDepth)
        {
            // Try again
        }

        Debug.Log("Trigger Cut Area Exit");
    }

    // private void DisableRenderer()
    // {
    //     GetComponentInParent<MeshRenderer>().enabled = false;
    // }
}
