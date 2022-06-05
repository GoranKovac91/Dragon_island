using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{
    [SerializeField] private GameObject _flameThrowerInstance;
    [SerializeField] private GameObject _flameThrowerPrefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _player;
    private void Awake()
    {
        PlayerControls.OnFire += FlameThrower;
    }
    public void FlameThrower()
    {
        _flameThrowerInstance = Instantiate(_flameThrowerPrefab, _shootPosition.position + Vector3.forward * Time.deltaTime, _player.transform.rotation);
        _flameThrowerInstance.transform.parent = _player.transform;
    }
}
