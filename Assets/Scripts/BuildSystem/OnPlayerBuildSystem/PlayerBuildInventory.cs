using UnityEngine;

public class PlayerBuildInventory : MonoBehaviour, ISelectInventoryControllable
{
    [SerializeField] private GameObject[] _previewCubes = new GameObject[3];
    [SerializeField] private GameObject[] _buildCubes = new GameObject[3];
    private int _activeCube;

    private BuildPreviewPosition _previewPosition;
    private RotatePreview _rotatePreview;

    private void Start()
    {
        _previewPosition = GetComponent<BuildPreviewPosition>();
        _rotatePreview = GetComponent<RotatePreview>();
        ActiveCubeChanged();
    }

    public GameObject GetActiveCubePreview()
    {
        return _previewCubes[_activeCube];
    }

    public GameObject GetActiveCubeToBuild()
    {
        return _buildCubes[_activeCube];
    }

    void ActiveCubeChanged()
    {
        ChangeActive();
        _previewPosition.BuildPreview = GetActiveCubePreview();
        _rotatePreview.BuildPreview = GetActiveCubePreview();
    }
    
    void ChangeActive()
    {
        for (int i = 0; i < _previewCubes.Length; i++)
        {
             _previewCubes[i].SetActive(false);
             if (_activeCube == i)
             {
                 _previewCubes[i].SetActive(true);
             }
        }
    }

    public void SelectNext()
    { 
        if (_activeCube < _previewCubes.Length-1)
        {
            _activeCube++;
            ActiveCubeChanged();
        }
    }

    public void SelectPrevious()
    {
        if (_activeCube > 0)
        {
            _activeCube--;
            ActiveCubeChanged();
        }
    }
}

