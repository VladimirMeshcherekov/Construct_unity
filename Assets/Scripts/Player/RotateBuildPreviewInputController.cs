using System;
using UnityEngine;

public class RotateBuildPreviewInputController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private IRotatePreviewController _controlableObject;
    [SerializeField] private KeyCode _rotateXAxix, _rotateYAxix;
    
    private void Start()
    {
        _controlableObject = _player.GetComponent<IRotatePreviewController>();
        if (_controlableObject == null) throw new NullReferenceException("Player doesnt have IRotatePreviewController");
    }

    private void Update()
    {
        if (Input.GetKeyDown(_rotateXAxix))
        {
            _controlableObject.RotateXAxix();
        }
        else if (Input.GetKeyDown(_rotateYAxix))
        {
            _controlableObject.RotateYAxix();
        }
    }
}
