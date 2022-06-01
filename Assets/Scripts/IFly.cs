using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFly 
{
    float XAngle { get; }
    public void Dive();
    public void Ascend();
}
