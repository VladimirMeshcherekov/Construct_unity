﻿using UnityEngine;

public class BuildPreviewController : MonoBehaviour
{
   public GameObject BuildPreview;
   [SerializeField] private Material _ableToBuild, _unableToBuild;

   public void ShowPreview(Transform dockerObject, int faceNum, int faceDirectionSign, bool faceState)
   {
      BuildPreview.GetComponent<MeshRenderer>().enabled = true;
      ChangePreviewMaterial(faceState);

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

   void ChangePreviewMaterial(bool faceState)
   {
      if (faceState == true)
      {
         BuildPreview.GetComponent<MeshRenderer>().material = _ableToBuild;
      }
      else
      {
         BuildPreview.GetComponent<MeshRenderer>().material = _unableToBuild;
      }

   }

   void OnForward(Transform dockerObject, int faceDirectionSign)
   {
      BuildPreview.transform.position =
         new Vector3(dockerObject.position.x, dockerObject.transform.position.y, dockerObject.transform.position.z +
            faceDirectionSign * (dockerObject.localScale.z / 2 + BuildPreview.transform.localScale.z / 2));
   }
   
   void OnUp(Transform dockerObject, int faceDirectionSign)
   {
      BuildPreview.transform.position =
         new Vector3(dockerObject.position.x,
            dockerObject.transform.position.y + faceDirectionSign * (dockerObject.localScale.y / 2 + BuildPreview.transform.localScale.y / 2), 
                  dockerObject.transform.position.z);
   }
   
   void OnRight(Transform dockerObject, int faceDirectionSign)
   {
      BuildPreview.transform.position =
         new Vector3(dockerObject.position.x +  faceDirectionSign * (dockerObject.localScale.x / 2 + BuildPreview.transform.localScale.x / 2), 
            dockerObject.transform.position.y, dockerObject.transform.position.z);
   }
   
}