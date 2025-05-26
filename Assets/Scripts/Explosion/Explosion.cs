using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        float animDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, animDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
