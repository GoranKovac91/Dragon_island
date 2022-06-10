using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlyable
{
    public Vector2 lookInput { get; }
    public Vector2 screenCenter { get; }
    public Vector2 mouseDistance { get; }
    public void Fly();


}
