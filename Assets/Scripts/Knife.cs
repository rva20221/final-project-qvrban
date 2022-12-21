using System;
using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Knife : MonoBehaviour
{
    public bool isReady;

    private Vector3 _prevPos;
    private Vector3 _pos;
    
    [SerializeField]
    private Vector3 _origin = Vector3.down;
    
    public Vector3 Origin
    {
        get
        {
            Vector3 localShifted = transform.InverseTransformPoint(transform.position) + _origin;
            return transform.TransformPoint(localShifted);
        }
    }
    public Vector3 MoveDirection { get { return (_pos - _prevPos).normalized; } }

    private XRBaseController activeController;
    // Start is called before the first frame update
    private void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerSliceEvent);
        interactable.deactivated.AddListener(StopSliceEvent);
    }
    
    private void FixedUpdate()
    {
        _prevPos = _pos;
        _pos = transform.position;
    }

    private void StopSliceEvent(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            StopSlice(controllerInteractor.xrController);
        }
    }

    private void TriggerSliceEvent(BaseInteractionEventArgs eventArgs)
    {
        
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            
            TriggerSlice(controllerInteractor.xrController);
        }
    }

    private void TriggerSlice(XRBaseController controller)
    {
        isReady = true;
        activeController = controller;
    }

    private void StopSlice(XRBaseController controller)
    {
        isReady = false;
        activeController = null;
    }
    

    private void OnTriggerStay(Collider other)
    {
        bool isCutAreaExists = other.GetComponent<CutArea>() && other.GetComponent<CutArea>().enabled;
        
        if (isCutAreaExists && isReady)
        {
            activeController.SendHapticImpulse(0.5f, .1f);
        }
    }
    
}
