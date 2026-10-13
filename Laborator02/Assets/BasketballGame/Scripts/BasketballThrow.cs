
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class BasketballThrow : MonoBehaviour
{
    [Header("Throw Settings")]
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float upwardForce = 5f;
    [SerializeField] private Transform playerCamera;

    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    public Vector3 ThrowPosition { get; private set; }
    public bool HasBeenThrown { get; set; } = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;
    }

    
    private void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("SPACE pressed!");

            Debug.Log("Ball grabbed: " + grabInteractable.isSelected);

            Debug.Log("Camera assigned: " + (playerCamera != null));

            if (grabInteractable.isSelected && playerCamera != null)
            {
                ThrowBall();
            }
        }
    }


    private void ThrowBall()
    {
       
        var manager = grabInteractable.interactionManager;
        var interactor = grabInteractable.firstInteractorSelecting;

        if (manager == null || interactor == null)
            return;
        ThrowPosition = playerCamera.position;
        HasBeenThrown = true;
        manager.SelectExit(interactor, grabInteractable);

      
        Vector3 direction = playerCamera.forward;
        Vector3 velocity = direction * throwForce + Vector3.up * upwardForce;

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.linearVelocity = velocity;
    }

    


}
