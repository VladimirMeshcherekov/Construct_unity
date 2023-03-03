using System;
using UnityEngine;

public class ControllInput : MonoBehaviour
{
    private IControllable _controlableObject;
    [SerializeField] GameObject _player;
    [SerializeField] private KeyCode _buildKey, _changeModeKey;
    private void Start()
    {
        _controlableObject = _player.GetComponent<IControllable>();
        if (_controlableObject == null) throw new NullReferenceException("Player doesnt have IComparable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_buildKey))
        {
            _controlableObject.Build();
        }
        else if (Input.GetKeyDown(_changeModeKey))
        {
            _controlableObject.ChangeMode();
        }
    }
}
