using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform target;
     public Vector3 _offset;
     private float _smoothSpeed = 0.125f;

     private void Update()
     {
          Vector3 possitions = target.position + target.TransformDirection(_offset);

          Vector3 smoothedPossition = Vector3.Lerp(transform.position, possitions, _smoothSpeed);
          transform.position = smoothedPossition;

          transform.LookAt(target);
     }
}