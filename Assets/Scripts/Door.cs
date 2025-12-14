using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private string doorAnimationParameter = "IsOpen";
    private bool isPlayerInside = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FirstPersonController>(out FirstPersonController player))
        {
            if (!isPlayerInside)
            {
                isPlayerInside = true;
                animator.SetBool(doorAnimationParameter, true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FirstPersonController>(out FirstPersonController player))
        {
            isPlayerInside = false;
            animator.SetBool(doorAnimationParameter, false);
        }
    }
}