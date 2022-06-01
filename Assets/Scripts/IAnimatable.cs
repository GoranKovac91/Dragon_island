using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatable 
{
    public void Walk();
    public void TakeOff();
    public void Idle();
    public void FlyForward();
}
