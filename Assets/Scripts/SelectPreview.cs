using UnityEngine;
[RequireComponent(typeof(BuildPreview), typeof(RotatePreview))]
public class SelectPreview : MonoBehaviour
{
    [SerializeField] private GameObject[] _previewTypes = new GameObject[3];
    private int _selected = 0;
    private RotatePreview _rotatePreview;
    private BuildPreviewPosition _buildPreviewPosition;

    private void Start()
    {
        _rotatePreview = gameObject.GetComponent<RotatePreview>();
        _buildPreviewPosition = gameObject.GetComponent<BuildPreviewPosition>();
        
        _rotatePreview.BuildPreview = _previewTypes[0];
        _buildPreviewPosition.BuildPreview = _previewTypes[0];
        
        for (int i = 1; i < _previewTypes.Length; i++)
        {
            _previewTypes[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            if (_selected == 0)
            {
                _previewTypes[_selected].SetActive(false);
                _selected = _previewTypes.Length-1;
                _previewTypes[_selected].SetActive(true);
            }
            else
            {
                _previewTypes[_selected].SetActive(false);
                _selected--;
                _previewTypes[_selected].SetActive(true);
            }
            ChangePreview();
        }       
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            if (_selected == _previewTypes.Length-1)
            {
                _previewTypes[_selected].SetActive(false);
                _selected = 0;
                _previewTypes[_selected].SetActive(true);
            }
            else
            {
                _previewTypes[_selected].SetActive(false);
                _selected++;
                _previewTypes[_selected].SetActive(true);
            }
            ChangePreview();
        }
    }

    void ChangePreview()
    {
        _rotatePreview.BuildPreview = _previewTypes[_selected];
        _buildPreviewPosition.BuildPreview = _previewTypes[_selected];
    }
}
