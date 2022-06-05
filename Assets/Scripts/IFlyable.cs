using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlyable 
{
    float XAngle { get; }
    float YAngle { get; }
    float ZAngle { get; }
    float smooth { get; }
    public void Dive();
    public void Ascend();
}
