using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _playerposition;
    [SerializeField] private Vector3 _offset;
    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
    }
    private void Update()
    {
        _mainCamera.transform.position = _playerposition.transform.position + _offset;
       
    }

}
