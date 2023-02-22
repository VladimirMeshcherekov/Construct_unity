using UnityEngine;
[RequireComponent(typeof(BuildPreviewPosition))]
public class PlayerRay : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    private BuildPreviewPosition _previewPosition;
   
    void Start()
    {
        _previewPosition = GetComponent<BuildPreviewPosition>();
    }
    void Update()
    {
        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward * 10);
        Debug.DrawRay(_playerCamera.transform.position, _playerCamera.transform.forward * 10, Color.cyan);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo))
        {
            GetFace(hit, _facesInfo);
            Debug.DrawRay(hit.point, hit.normal * 10, Color.yellow);
        }
    }

    void GetFace(RaycastHit hit, FacesInfo facesInfo)
    {
        //  0 = x (right), 1 = y (up), 2 = z (forward), 3 = -x  (-right), 4 = -y (-up), 5 = -z (-forward)
        
        GameObject hitGameObject = hit.collider.gameObject;
        Transform hitTransform = hitGameObject.transform;
      
        if (hit.normal == hitTransform.right)
        {
            _previewPosition.ShowPreview(hitTransform, 0,1);
            
        }  
        
        if (hit.normal == hitTransform.up)
        {
            _previewPosition.ShowPreview(hitTransform, 1,1);
            
        }  
        
        if (hit.normal == hitTransform.forward)
        {
            _previewPosition.ShowPreview(hitTransform, 2,1);
            
        }   
        
        if (hit.normal == -hitTransform.right)
        {
            _previewPosition.ShowPreview(hitTransform, 3,-1);
            
        }  
        
        if (hit.normal == -hitTransform.up)
        {
            _previewPosition.ShowPreview(hitTransform, 4,-1);
            
        }      
        
        if (hit.normal == -hitTransform.forward)
        {
            _previewPosition.ShowPreview(hitTransform, 5,-1);
            
        }    
        
    }
}
