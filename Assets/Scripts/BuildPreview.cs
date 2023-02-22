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
           GameObject spawned = Instantiate(_toBuild, transform.position,
                Quaternion.identity);
           spawned.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        }
    }
}
