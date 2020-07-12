using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager manager;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("xSpeed", manager.xSpeed);
        animator.SetFloat("ySpeed", manager.ySpeed);

        if(manager.hasAttacked)
        {
            animator.SetTrigger("Attack");
            manager.hasAttacked = false;
        }

        if (manager.hasBlocked)
        {
            animator.SetTrigger("Block");
            manager.hasBlocked = false;
        }
    }
}
