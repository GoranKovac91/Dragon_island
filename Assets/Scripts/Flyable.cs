using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyable : MonoBehaviour, IFlyable
{
    public Vector2 lookInput { get; private set; }

    public Vector2 screenCenter { get; private set; }

    public Vector2 mouseDistance { get; private set; }

    [SerializeField] private GameObject _player;
    private void Awake()
    {
        screenCenter = new Vector2(Screen.width*.5f,Screen.height*.5f);
    
    }
    private void Update()
    {
        lookInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mouseDistance = new Vector2((lookInput.x - screenCenter.x) / screenCenter.y, (lookInput.y - screenCenter.y) / screenCenter.y);
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);
    }


    public void Fly()
    {
        _player.transform.Rotate(-mouseDistance.y * 90.0f * Time.deltaTime, mouseDistance.x * 90 * Time.deltaTime, 0, Space.Self);
    }
}
