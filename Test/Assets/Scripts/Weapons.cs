using UnityEngine;

public class Weapons : MonoBehaviour
{
     [SerializeField]
     private GameObject _objectParent;

     private float _speed = 50f;
     private bool _isChild = false;

     void Update()
     {
          if (!_isChild)
          {
               RotateObject();
          }
     }

     public void transformPosOnPick()
     {
          transform.position = new Vector3(-0.005f, 0, 0);
          transform.rotation = Quaternion.Euler(-90, 0, 160);
          transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
          transform.SetParent(_objectParent.transform, false);
          _isChild = true;
     }

     private void RotateObject()
     {
          transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
     }
}
