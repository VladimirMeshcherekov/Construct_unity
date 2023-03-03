using System;
using UnityEngine;

public class ControllInventoryInput : MonoBehaviour
{
    private ISelectInventoryControllable _controlableObject;
    [SerializeField] GameObject _player;
    [SerializeField] private KeyCode _selectNext, _selectPrevious;
    private void Start()
    {
        _controlableObject = _player.GetComponent<ISelectInventoryControllable>();
        if (_controlableObject == null) throw new NullReferenceException("Player doesnt have IComparable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_selectNext) == true)
        {
            _controlableObject.SelectNext();
        }
        else if (Input.GetKeyDown(_selectPrevious) == true)
        {
            _controlableObject.SelectPrevious();
        }
    }
}
