using System;
using UnityEngine;

public class RotatePlayerInputController : MonoBehaviour
{ 
    [SerializeField] GameObject _player;
    private IRotatePlayerController _controlableObject;
    
    private void Start()
    {
        _controlableObject = _player.GetComponent<IRotatePlayerController>();
        if (_controlableObject == null) throw new NullReferenceException("Player doesnt have IRotatePlayerController");
    }

    private void Update()
    {
        _controlableObject.HorizontalRotate(Input.GetAxis("Mouse X"));
        _controlableObject.VerticalRotate(Input.GetAxis("Mouse Y"));
    }
}
