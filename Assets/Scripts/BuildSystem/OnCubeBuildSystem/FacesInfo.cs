using UnityEngine;

public class FacesInfo : MonoBehaviour
{
    [Header( "5 -> -z")]
    [Header("4 -> -y")]
    [Header("3 -> -x")]
    [Header("2 -> z")]
    [Header("1 -> y")]
    [Header("0 -> x")]
    [SerializeField] public bool[] _facesInfo = new bool[6];
}
