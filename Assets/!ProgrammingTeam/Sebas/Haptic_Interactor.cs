using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0,1)]
        public float intensity;      // how strong the controller vibrates
        public float duration;       // how long the controller vibrates
        
        
    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);       // call on interact
        }
    }   
                              
    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
            controller.SendHapticImpulse(intensity, duration);  // call the vibration
    }
}

public class Haptic_Interactor : MonoBehaviour
{
    public Haptic hapticOnActivated;

    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
    }

    
}
