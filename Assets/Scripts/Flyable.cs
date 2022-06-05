using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyable : MonoBehaviour,IFlyable
{
    public float XAngle => 45.0f;

    public float YAngle => throw new System.NotImplementedException();

    public float ZAngle => throw new System.NotImplementedException();

    public float smooth => 1.0f;

    [SerializeField] private GameObject _player;


    public void Ascend()
    {
        _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, Quaternion.Euler(-XAngle, _player.transform.localEulerAngles.y, _player.transform.localEulerAngles.z), smooth * Time.deltaTime);
    }

    public void Dive()
    {
        _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, Quaternion.Euler(XAngle, _player.transform.localEulerAngles.y, _player.transform.localEulerAngles.z), smooth * Time.deltaTime);
    }

}
