using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//  0 = x (right), 1 = y (up), 2 = z (forward), 3 = -x  (-right), 4 = -y (-up), 5 = -z (-forward)
public class CheckToPlacePreview : MonoBehaviour
{
    bool[] _resultCheck = new bool[6];
    public bool _result = false;
    private bool[] _thisFacesInfo = new bool[6];
    [SerializeField] private Material _ableMaterial, _unableMaterial;
    
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
            if (_thisFacesInfo[2] == false)
            {
                _resultCheck[2] = false;
            }
        }        
        
        if (Physics.Raycast(rayPositiveRight, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo0) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo0, 0);
            if (_thisFacesInfo[0] == false)
            {
                _resultCheck[0] = false;
            }
        }        
        if (Physics.Raycast(rayNegativeRight, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo3) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo3, 3);
            if (_thisFacesInfo[3] == false)
            {
                _resultCheck[3] = false;
            }
        }
        
        if (Physics.Raycast(rayNegativeForward, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo5) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f )
        {
            GetCheck(hit, _facesInfo5, 5);
            if (_thisFacesInfo[5] == false)
            {
                _resultCheck[5] = false;
            }
        }        
        
        if (Physics.Raycast(rayNegativeUp, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo4) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude <  1.1f)
        {
            GetCheck(hit, _facesInfo4, 4);
            if (_thisFacesInfo[4] == false)
            {
                _resultCheck[4] = false;
            }
        }       
        
        if (Physics.Raycast(rayPositiveUp, out hit) && hit.collider.gameObject.TryGetComponent(out FacesInfo _facesInfo1) &&  (hit.collider.gameObject.transform.position-gameObject.transform.position).magnitude < 1.1f)
        {
            GetCheck(hit, _facesInfo1, 1);
            if (_thisFacesInfo[1] == false)
            {
                _resultCheck[1] = false;
            }
        }

        for (int i = 0; i < _resultCheck.Length; i++)
        {
            if (_resultCheck[i] == false)
            {
                _result = false;
                break;
            }

            _result = true;
        }

        if (_result == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = _ableMaterial;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = _unableMaterial;
        }
    }

    void GetCheck(RaycastHit hit, FacesInfo _dockerFacesInfo, int rayFaceNum)
    {
        Transform hitTransform = hit.collider.gameObject.transform;
        if (hit.normal == hitTransform.forward)
        {
            _resultCheck[rayFaceNum] = _dockerFacesInfo._facesInfo[2];
            
        }  
        if (hit.normal == -hitTransform.forward)
        {
            _resultCheck[rayFaceNum] = _dockerFacesInfo._facesInfo[5];
            
        }
        if (hit.normal == hitTransform.right)
        {
            _resultCheck[rayFaceNum] = _dockerFacesInfo._facesInfo[0];
            
        }
        if (hit.normal == -hitTransform.right)
        {
            _resultCheck[rayFaceNum] = _dockerFacesInfo._facesInfo[3];
            
        }        
        if (hit.normal == hitTransform.up)
        {
            _resultCheck[rayFaceNum] = _dockerFacesInfo._facesInfo[1];
            
        }        
        if (hit.normal == -hitTransform.up)
        {
            _resultCheck[rayFaceNum] = _dockerFacesInfo._facesInfo[4];
            
        }
        
    }

}
