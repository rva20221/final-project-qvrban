using System;
using System.Collections;
using System.Collections.Generic;
using HintSystem;
using UI;
using UnityEngine;

public class QurbanArea : MonoBehaviour
{
    public GameObject Animal;
    public GameObject Knife;

    [SerializeField] private HintPanel qurbanGUI;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject defaultMeadow;
    [SerializeField] private GameObject qurbanMeadow;

    private bool isReadyForQurban;
    private GameObject currentAnimal;
    private GameObject currentKnife;

    private void Start()
    {
        SetQurbanEnvironment(false);
    }

    public void PrepareQurban()
    {
        if (isReadyForQurban) return;
        
        InstantiateResources();
        
        isReadyForQurban = true;
        SetQurbanEnvironment(true);
        qurbanGUI.OpenHint(HintManager.TryGetHintCollection("QurbanArea"));
    }

    public void ResetArea()
    {
        Destroy(currentAnimal);
        Destroy(currentKnife);
        
        isReadyForQurban = false;
        SetQurbanEnvironment(false);
        qurbanGUI.CloseHint();
    }

    private void InstantiateResources()
    {
        currentAnimal = Instantiate(Animal, transform);
        currentAnimal.transform.localPosition = new Vector3(-1.028f,0.342000008f,-1.04999995f);
        currentAnimal.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 90));
        
        currentKnife = Instantiate(Knife, transform);
        currentKnife.transform.localPosition = new Vector3(3.2140007f, 0.495000064f, -0.0850000381f);
        currentKnife.transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
    }

    private void SetQurbanEnvironment(bool value)
    {
        qurbanMeadow.SetActive(value);
        table.SetActive(value);
        defaultMeadow.SetActive(!value);
    }
}
