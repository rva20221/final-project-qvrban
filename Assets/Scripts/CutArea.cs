using System;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

public class CutArea : MonoBehaviour
{
    public BzKnife bzKnife;
    public float cutDepth;
    
    private AreaKnifeSliceable baseArea;
    private bool isBeingCut;

    private Vector3 contactPoint;

    private void Start()
    {
        baseArea = GetComponentInParent<AreaKnifeSliceable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (baseArea.bzKnife)
        {
            Debug.Log("Raise cut invalid error : Harus langsung ke valid area ,gabole lewat samping");
            return; 
        }

        var knife = other.gameObject.GetComponent<BzKnife>();
        if (knife == null || !knife.enabled)
            return;

        contactPoint = knife.Origin;
        isBeingCut = true;

        Debug.Log("Trigger Cut Area Enter");
        
        bzKnife = knife;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isBeingCut) return;
        
        var knife = other.gameObject.GetComponent<BzKnife>();
        if (knife == null || !knife.enabled)
            return;

        float distance = Vector3.Distance(knife.Origin, contactPoint);
        Debug.Log(distance);

        if (distance > cutDepth)
        {
            isBeingCut = false;
            StartCoroutine(baseArea.Slice(knife));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (baseArea.bzKnife)
        {
            Debug.Log("Raise cut invalid error : Lurus kebawah gaboleh kiri kanan cutnya");
            isBeingCut = false;
            bzKnife = null;
            return; 
        }
        
        var knife = other.gameObject.GetComponent<BzKnife>();
        if (knife == null || !knife.enabled)
            return;

        isBeingCut = false;

        Debug.Log("Trigger Cut Area Exit");

        bzKnife = null;
    }
}
