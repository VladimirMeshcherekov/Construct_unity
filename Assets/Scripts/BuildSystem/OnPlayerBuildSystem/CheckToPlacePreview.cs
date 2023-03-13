using UnityEngine;

//  0 = x (right), 1 = y (up), 2 = z (forward), 3 = -x  (-right), 4 = -y (-up), 5 = -z (-forward)
public class CheckToPlacePreview : MonoBehaviour
{
    bool[] _resultCheck = new bool[6];
    public bool AbleToPlace = false;
    private bool[] _thisFacesInfo = new bool[6];
    [SerializeField] private Material _ableMaterial, _unableMaterial;
    private bool _isConnetedToDocker = false;
    private void Start()
    {
        _thisFacesInfo = gameObject.GetComponent<FacesInfo>()._facesInfo;
        
    }

    private void Update()
    {
        for (int i = 0; i < _resultCheck.Length; i++)
        {
            _resultCheck[i] = true;
        }
        Ray rayPositiveForward = new Ray(transform.position, transform.forward);
        Ray rayNegativeForward = new Ray(transform.position, -transform.forward);
         
        Ray rayPositiveRight = new Ray(transform.position, transform.right);
        Ray rayNegativeRight = new Ray(transform.position, -transform.right);
        
        Ray rayPositiveUp = new Ray(transform.position, transform.up);
        Ray rayNegativeUp = new Ray(transform.position, -transform.up);
        
        RaycastHit hit;

     
        
        if (Physics.Raycast(rayPositiveForward, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo2) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo2, 2);
        }        
        
        if (Physics.Raycast(rayPositiveRight, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo0) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo0, 0);
        }        
        if (Physics.Raycast(rayNegativeRight, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo3) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo3, 3);
        }
        
        if (Physics.Raycast(rayNegativeForward, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo5) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f )
        {
            GetCheck(hit, _facesInfo5, 5);
        }        
        
        if (Physics.Raycast(rayNegativeUp, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo4) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo4, 4);
        }       
        
        if (Physics.Raycast(rayPositiveUp, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo1) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude < 1.1f)
        {
            GetCheck(hit, _facesInfo1, 1);
        }

        for (int i = 0; i < _resultCheck.Length; i++)
        {
            if (_resultCheck[i] == false)
            {
                AbleToPlace = false;
                break;
            }

            AbleToPlace = true;
        }

        if (_isConnetedToDocker == false)
        {
            AbleToPlace = false;
        }

        if (AbleToPlace == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = _ableMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = _unableMaterial;
        }

        _isConnetedToDocker = false;
    }

    void GetCheck(RaycastHit hit, FacesInfo _dockerFacesInfo, int rayFaceNum)
    {
        Transform hitTransform = hit.collider.gameObject.transform;
        
        if (hit.normal == hitTransform.forward) //checking direction
        {
            if (_dockerFacesInfo._facesInfo[2] == _thisFacesInfo[rayFaceNum]) //checking ability to build (false == false or true == true but not false == true)
            {
                _resultCheck[rayFaceNum] = true;
               
                if (_thisFacesInfo[rayFaceNum] && _isConnetedToDocker == false) //checking for ability to connect (required minimum 1 place to connect)
                {
                    _isConnetedToDocker = true;
                }
                return;
            }
            else
            {
                _resultCheck[rayFaceNum] = false;
                return;
            }
        }  
        if (hit.normal == -hitTransform.forward)
        {
            if (_dockerFacesInfo._facesInfo[5] == _thisFacesInfo[rayFaceNum])
            {
                _resultCheck[rayFaceNum] = true;
               
                if (_thisFacesInfo[rayFaceNum] && _isConnetedToDocker == false)
                {
                    _isConnetedToDocker = true;
                }
                return;
            }
            else
            {
                _resultCheck[rayFaceNum] = false;
                return;
            }
        }
        
        if (hit.normal == hitTransform.right)
        {
            if (_dockerFacesInfo._facesInfo[0] == _thisFacesInfo[rayFaceNum])
            {
                _resultCheck[rayFaceNum] = true;
                
                if (_thisFacesInfo[rayFaceNum] && _isConnetedToDocker == false)
                {
                    _isConnetedToDocker = true;
                }
                return;
            }
            else
            {
                _resultCheck[rayFaceNum] = false;
                return;
            }
        }
        
        if (hit.normal == -hitTransform.right)
        {
            if (_dockerFacesInfo._facesInfo[3] == _thisFacesInfo[rayFaceNum])
            {
                _resultCheck[rayFaceNum] = true;
               if (_thisFacesInfo[rayFaceNum] && _isConnetedToDocker == false)
                {
                    _isConnetedToDocker = true;
                }
                return;
            }
            else
            {
                _resultCheck[rayFaceNum] = false;
                return;
            }
        }     
        
        if (hit.normal == hitTransform.up)
        {
            if (_dockerFacesInfo._facesInfo[1] == _thisFacesInfo[rayFaceNum])
            {
                _resultCheck[rayFaceNum] = true;
                if (_thisFacesInfo[rayFaceNum] && _isConnetedToDocker == false)
                {
                    _isConnetedToDocker = true;
                }
                return;
            }
            else
            {
                _resultCheck[rayFaceNum] = false;
                return;
            }
        }  
        
        if (hit.normal == -hitTransform.up)
        {
            if (_dockerFacesInfo._facesInfo[4] == _thisFacesInfo[rayFaceNum])
            {
               
                _resultCheck[rayFaceNum] = true;
                if (_thisFacesInfo[rayFaceNum] && _isConnetedToDocker == false)
                {
                    _isConnetedToDocker = true;
                }
                return;
            }
            else
            { 
                _resultCheck[rayFaceNum] = false;
                return;
            }

        }
        
    }

}
