using UnityEngine;
[RequireComponent(typeof(RotatePreview))]
public class BuildPreviewPosition : MonoBehaviour
{
   [HideInInspector] public GameObject BuildPreview;
   
   public void ShowPreview(Transform dockerObject, int faceNum, int faceDirectionSign)
   {
      BuildPreview.GetComponent<MeshRenderer>().enabled = true;

      if(faceNum == 0 || faceNum == 3)
      {
         OnRight(dockerObject, faceDirectionSign);
      }
      
      if (faceNum == 2 || faceNum == 5)
      {
         OnForward(dockerObject, faceDirectionSign);
      } 
      
      if (faceNum == 1 || faceNum == 4)
      {
         OnUp(dockerObject, faceDirectionSign);
      }
   }
   void OnForward(Transform dockerObject, int faceDirectionSign)
   {
      BuildPreview.transform.position = dockerObject.transform.position + (faceDirectionSign * dockerObject.transform.forward);
   }
   
   void OnUp(Transform dockerObject, int faceDirectionSign)
   {
      BuildPreview.transform.position = dockerObject.transform.position + (faceDirectionSign * dockerObject.transform.up);
   }
   
   void OnRight(Transform dockerObject, int faceDirectionSign)
   {
      BuildPreview.transform.position = dockerObject.transform.position + (faceDirectionSign * dockerObject.transform.right);
   }
   
}
