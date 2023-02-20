using UnityEngine;
[RequireComponent(typeof(BuildPreviewController))]
public class PlayerRay : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    private BuildPreviewController _previewController;
   
    void Start()
    {
        _previewController = GetComponent<BuildPreviewController>();
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
        bool faceState;
       
        if (hit.normal == hitTransform.right)
        {
            faceState = facesInfo._facesInfo[0];
            _previewController.ShowPreview(hitTransform, 0,1, faceState);
            
        }  
        
        if (hit.normal == hitTransform.up)
        {
            faceState = facesInfo._facesInfo[1];
            _previewController.ShowPreview(hitTransform, 1,1, faceState);
            
        }  
        
        if (hit.normal == hitTransform.forward)
        {
            faceState = facesInfo._facesInfo[2];
            _previewController.ShowPreview(hitTransform, 2,1, faceState);
            
        }   
        
        if (hit.normal == -hitTransform.right)
        {
            faceState = facesInfo._facesInfo[3];
            _previewController.ShowPreview(hitTransform, 3,-1, faceState);
            
        }  
        
        if (hit.normal == -hitTransform.up)
        {
            faceState = facesInfo._facesInfo[4];
            _previewController.ShowPreview(hitTransform, 4,-1, faceState);
            
        }      
        
        if (hit.normal == -hitTransform.forward)
        {
            faceState = facesInfo._facesInfo[5];
            _previewController.ShowPreview(hitTransform, 5,-1, faceState);
            
        }    
        
    }
}
