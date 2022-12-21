using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class QurbanArea : MonoBehaviour
{
    public GameObject Animal;

    [SerializeField] private HintPanel qurbanGUI;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject defaultMeadow;
    [SerializeField] private GameObject qurbanMeadow;
    
    
    private bool isReadyForQurban;

    private void Start()
    {
        SetQurbanMeadow(false);
    }

    public void PrepareQurban()
    {
        isReadyForQurban = true;
        GameObject animalGO = Instantiate(Animal, new Vector3(-0.855735779f,0.348999888f,-0.516059935f), Quaternion.Euler(new Vector3(0,90,90)));
        SetQurbanMeadow(true);
        table.SetActive(true);
    }

    private void SetQurbanMeadow(bool value)
    {
        qurbanMeadow.SetActive(value);
        defaultMeadow.SetActive(!value);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isReadyForQurban || !other.CompareTag("Player")) return;
        
        qurbanGUI.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isReadyForQurban || !other.CompareTag("Player")) return;
        
        qurbanGUI.enabled = false;
    }
}
