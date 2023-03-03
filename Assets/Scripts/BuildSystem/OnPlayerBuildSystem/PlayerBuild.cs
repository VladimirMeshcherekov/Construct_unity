using UnityEngine;

public class PlayerBuild : MonoBehaviour, IControllable
{
    private PlayerBuildInventory _inventory;
    private void Start()
    {
        _inventory = GetComponent<PlayerBuildInventory>();
    }
   
    public void Build()
    {
        GameObject previewCube = _inventory.GetActiveCubePreview().GetComponent<CheckToPlacePreview>().gameObject;
        if (previewCube.GetComponent<CheckToPlacePreview>()._result == true)
        {
            
            Quaternion toRotate = Quaternion.Euler(previewCube.transform.rotation.eulerAngles); 
            Instantiate(_inventory.GetActiveCubeToBuild(), previewCube.transform.position, toRotate);
            return;
        }
    }
    public void ChangeMode()
    { }
}
