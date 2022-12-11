using BzKovSoft.ObjectSlicer.Samples;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Knife : MonoBehaviour
{
    private BzKnife bzKnife;
    private XRGrabInteractableTwoAttach interactableTwoAttach;

    private bool isReady;

    private XRBaseController activeController;
    // Start is called before the first frame update
    void Start()
    {
        bzKnife = GetComponent<BzKnife>();
        interactableTwoAttach = GetComponent<XRGrabInteractableTwoAttach>();
        bzKnife.enabled = false;
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerSliceEvent);
        interactable.deactivated.AddListener(StopSliceEvent);
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
        bzKnife.enabled = true;
        isReady = true;
        activeController = controller;
    }

    private void StopSlice(XRBaseController controller)
    {
        bzKnife.enabled = false;
        isReady = false;
        activeController = null;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.GetComponent<KnifeSliceableAsync>() && isReady)
        {
            activeController.SendHapticImpulse(0.5f, .1f);
        }
    }
}
