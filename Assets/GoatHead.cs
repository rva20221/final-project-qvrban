using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GoatHead : XRGrabInteractableTwoAttach
{
    [SerializeField] private GameObject neckHighlight;
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        neckHighlight.SetActive(true);
    }

    protected override void OnSelectExiting(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
        neckHighlight.SetActive(false);
    }
}
