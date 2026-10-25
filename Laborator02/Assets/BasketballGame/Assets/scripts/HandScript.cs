using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationInput : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;
    [SerializeField] private InputActionReference grabAction;
    [SerializeField] private InputActionReference triggerAction;

    private void Awake()
    {
        if (handAnimator == null)
            handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (grabAction != null && grabAction.action != null)
            grabAction.action.Enable();

        if (triggerAction != null && triggerAction.action != null)
            triggerAction.action.Enable();
    }

    private void Update()
    {
        if (handAnimator == null)
            return;

        bool grab = grabAction != null
                    && grabAction.action != null
                    && grabAction.action.IsPressed();

        bool trigger = triggerAction != null
                       && triggerAction.action != null
                       && triggerAction.action.IsPressed();

        handAnimator.SetBool("GrabPressed", grab);
        handAnimator.SetBool("TriggerPressed", trigger);
    }
}