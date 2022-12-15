using System;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;

public class AreaKnifeSliceable : KnifeSliceableAsync
{
    [SerializeField] private CutArea validCutArea;
    public BzKnife bzKnife;

    protected override void OnTriggerEnter(Collider other)
    {
        var knife = other.gameObject.GetComponent<BzKnife>();
        if (knife == null || !knife.enabled)
            return;

        bzKnife = knife;
        
        if (validCutArea.bzKnife == null)
        {
            Debug.Log("Not Valid");
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var knife = other.gameObject.GetComponent<BzKnife>();
        if (knife == null || !knife.enabled)
            return;
        
        
        bzKnife = null;
    }
}
