using UnityEngine;

public class ProximityAttackController : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private Transform firstCat;
    [SerializeField] private Transform secondCat;

    [Header("Attack Settings")]
    [SerializeField] private float attackDistance = 10.0f;
    

    private Animator firstAnimator;
    private Animator secondAnimator;
    

    private void Start()
    {
        firstAnimator = firstCat.GetComponent<Animator>();
        secondAnimator = secondCat.GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(
            firstCat.position,
            secondCat.position
        );

        bool isNear = distance <= attackDistance;
        Debug.Log("Distance: " + distance + " | isNear: " + isNear);
        firstAnimator.SetBool("isNear", isNear);
        secondAnimator.SetBool("isNear", isNear);
    }
}