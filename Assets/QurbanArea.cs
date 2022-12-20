using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class QurbanArea : MonoBehaviour
{
    [SerializeField] private HintPanel QurbanGUI;

    private void OnTriggerEnter(Collider other)
    {
        QurbanGUI.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        QurbanGUI.enabled = false;
    }
}
