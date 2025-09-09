using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizAnimate : MonoBehaviour
{

    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetTrigger("StopAttack");
        }

    }
}

