using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatable : MonoBehaviour,IAnimatable
{
    [SerializeField] public Animator _animator;

    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Walk()
    {
        _animator.SetBool("IsWalking", true);
    }

    public void TakeOff()
    {
        _animator.SetFloat("VelocityY", 1);
    }

    public void Idle()
    {
        _animator.SetBool("IsWalking", false);
    }

    public void FlyForward()
    {
        _animator.SetBool("IsFlying", true);
    }

   
}
