﻿using UnityEngine;

public class RotatePreview : MonoBehaviour
{
    private GameObject _buildPreview;
   public GameObject BuildPreview
    {
        get
        {
           return _buildPreview; 
        }
        set
        {
            _buildPreview = value;
            PreviewGameObjectChanged();
        }
    }

    private Transform _previewTransform; 
    private int _rotationX = 0, _rotationY = 0;
    private Vector3 _rotation;
    
    void PreviewGameObjectChanged()
    {
        _buildPreview.transform.rotation = Quaternion.Euler(0,0,0);
        _previewTransform = BuildPreview.transform;
        _rotationX = 0;
        _rotationY = 0;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            _rotation = new Vector3(_rotation.x + 90, _rotation.y, _rotation.z);
            _previewTransform.rotation = Quaternion.Euler(_rotation);
            _rotationX += 90;
        }        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _rotation = new Vector3(_rotation.x, _rotation.y+90, _rotation.z);
            _previewTransform.rotation = Quaternion.Euler(_rotation);
            _rotationY += 90;
        }
        
    }
}
