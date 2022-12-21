using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    [SerializeField] private GameObject NeckHighlight;
    [SerializeField] private Collider[] invalidArea;

    private void Start()
    {
        NeckHighlight.SetActive(false);
        foreach (var invalidCollider in invalidArea)
        {
            invalidCollider.enabled = true;
            if (invalidCollider.GetComponent<InvalidArea>() == null)
            {
                invalidCollider.gameObject.AddComponent<InvalidArea>();
            }
        }
    }


}
