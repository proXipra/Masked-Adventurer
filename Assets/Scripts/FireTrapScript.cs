using System.Collections;
using UnityEngine;

public class FireTrapScript : MonoBehaviour
{
    bool toggleFire = false;
    Animator animator;
    CapsuleCollider2D capsuleCollider;
    public float waitSecond = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(WaitForRealSeconds(waitSecond)); // 1-2 saniye arası bekle
            ToggleFire();
        }
    }

    IEnumerator WaitForRealSeconds(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < startTime + seconds)
        {
            yield return null;
        }
    }

    void ToggleFire()
    {
        Debug.Log("FireOn!");
        toggleFire = !toggleFire;
        capsuleCollider.enabled = toggleFire;
        animator.SetBool("FireTrigger", toggleFire);  
    }
}
