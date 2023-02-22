using UnityEngine;

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
            _previewTransform.rotation = Quaternion.Euler(_previewTransform.rotation.x + _rotationX, _previewTransform.rotation.y, _previewTransform.rotation.z);
            _rotationX += 90;
        }        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _previewTransform.rotation = Quaternion.Euler(_previewTransform.rotation.x, _previewTransform.rotation.y + _rotationY, _previewTransform.rotation.z);
            _rotationY += 90;
        }
        
    }
}
