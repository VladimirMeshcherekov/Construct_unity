using UnityEngine;
[RequireComponent(typeof(CheckToPlacePreview))]
public class BuildPreview : MonoBehaviour
{
    [SerializeField] private GameObject _toBuild;
    private CheckToPlacePreview _checkToPlace;
    void Start()
    {
        _checkToPlace = GetComponent<CheckToPlacePreview>();
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && _checkToPlace._result == true)
        { 
            Quaternion toRotate = Quaternion.Euler(transform.rotation.eulerAngles); 
            Instantiate(_toBuild, transform.position, toRotate);
        }
    }
}
