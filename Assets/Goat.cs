using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    [SerializeField] private Collider[] invalidColliders;

    private void Start()
    {
        EventManager.AddListener("onQurbanSuccess", SuccessCut);
        EventManager.AddListener("onQurbanFailed", FailCut);
    }

    private void SuccessCut()
    {
        TurnOffScripts();
        // Do Success cut anim here
        Debug.Log("Success Cut");
    }

    private void FailCut()
    {
        TurnOffScripts();
        Debug.Log("Fail Cut");
    }

    private void TurnOffScripts()
    {
        foreach (var invalidCollider in invalidColliders)
        {
            InvalidArea invalidArea = invalidCollider.GetComponent<InvalidArea>();
            invalidArea.enabled = false;
        }
    }

}
