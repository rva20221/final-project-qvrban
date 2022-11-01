using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer;
using UnityEngine;

public class Slicer : BzSliceableObjectBase
{
    [HideInInspector] [SerializeField] private int _sliceId;
    [HideInInspector] [SerializeField] private float _lastSliceTime = float.MinValue;

    public float delayBetweenSlices = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
