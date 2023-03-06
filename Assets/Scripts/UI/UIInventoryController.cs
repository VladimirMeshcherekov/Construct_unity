using System;
using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [SerializeField] private GameObject[] _selectedItems = new GameObject[3];

    [SerializeField] private PlayerBuildInventory _mainInventoreLogic;

    private void OnEnable()
    {
        if(_mainInventoreLogic == null) throw new NullReferenceException("UI inventory does have logic part of inventory");
        _mainInventoreLogic.SelectedItemChanged += SelectedItemChanged;
    }

    private void OnDisable()
    {
        _mainInventoreLogic.SelectedItemChanged -= SelectedItemChanged;
    }
    
    void SelectedItemChanged(int newItemNum)
    {
        for (int i = 0; i < _selectedItems.Length; i++)
        {
            _selectedItems[i].gameObject.SetActive(false);
            if (i == newItemNum)
            {
                _selectedItems[i].gameObject.SetActive(true);
            }
        }
    }
}
