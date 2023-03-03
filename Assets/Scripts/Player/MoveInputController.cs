using UnityEngine;
using System;

public class MoveInputController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private IMovePlayerController _controlableObject;
    [SerializeField] private KeyCode _jump;
    
    private void Start()
    {
        _controlableObject = _player.GetComponent<IMovePlayerController>();
        if (_controlableObject == null) throw new NullReferenceException("Player doesnt have IMovePlayerController");
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jump))
        {
            _controlableObject.Jump();
        }
        
        _controlableObject.HorizontalMove(Input.GetAxis("Horizontal"));
        _controlableObject.VerticalMove(Input.GetAxis("Vertical"));
        
    }
    
}
