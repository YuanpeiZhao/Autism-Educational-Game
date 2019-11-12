using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }
    public void walk()
    {
        animator.SetBool("walk", true);
        animator.SetBool("sit", false);
    }

    public void idle()
    {
        animator.SetBool("walk", false);
        animator.SetBool("sit", false);
    }

    public void sit()
    {
        animator.SetBool("walk", false);
        animator.SetBool("sit", true);
    }
}
