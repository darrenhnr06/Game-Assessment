using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{   [SerializeField]
    private ParticleSystem vfxFume;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("model"))
        {
            animator = collision.gameObject.GetComponent<Animator>();
            vfxFume.gameObject.transform.position = collision.gameObject.transform.position;
            
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward);
            transform.position = initPos;
            rb.velocity = Vector3.zero;
            transform.GetChild(0).gameObject.SetActive(false);
            
            StartCoroutine(PlayIdleAnim(animator));
        }
    }

    IEnumerator PlayIdleAnim(Animator animator)
    {
        vfxFume.Play();
        animator.Play("Hit");
        yield return new WaitForSeconds(0.25f);
        vfxFume.Stop();
        yield return new WaitForSeconds(0.75f);
        animator.Play("Idle");
        
    }
}
