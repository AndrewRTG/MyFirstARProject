
using UnityEngine;

public class BasketballScore : MonoBehaviour
{
    [Header("Basket Settings")]
    [SerializeField] private Transform basketCenter;
    [SerializeField] private float threePointDistance = 6.75f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ball = other.attachedRigidbody;

        if (ball == null || !ball.CompareTag("Basketball"))
            return;

       
        if (ball.linearVelocity.y >= 0f)
            return;

       
        BasketballThrow basketballThrow =
            ball.GetComponent<BasketballThrow>();

        if (basketballThrow == null || !basketballThrow.HasBeenThrown)
            return;

        
        Vector3 throwPosition = basketballThrow.ThrowPosition;
        Vector3 basketPosition = basketCenter != null
            ? basketCenter.position
            : transform.position;

        throwPosition.y = 0f;
        basketPosition.y = 0f;

        float distance = Vector3.Distance(
            throwPosition,
            basketPosition
        );

       
        int points = distance > threePointDistance ? 3 : 2;

        Debug.Log(
            $"BASKET! +{points} points | Distance: {distance:F2}m"
        );

        
        basketballThrow.HasBeenThrown = false;
    }
}
