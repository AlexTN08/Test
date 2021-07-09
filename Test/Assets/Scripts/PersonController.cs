using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(CapsuleCollider))]
public class PersonController : MonoBehaviour
{
     private Animator _animator;
     public Animator Animator
     {
          get
          {
               if (_animator == null)
               {
                    _animator = GetComponent<Animator>();
               }
               return _animator;
          }
     }

     private float _speed = 5f;
     private float _rotationSpeed = 200f;

     private string _inputHorizontalAxis = "Horizontal";
     private string _inputVerticalAxis = "Vertical";

     private int _moveSpeedHash = Animator.StringToHash("MoveSpeed");
     private int _groundedHash = Animator.StringToHash("Grounded");

     void Update()
     {
          Animator.SetBool(_groundedHash, Physics.Raycast(transform.position, Vector3.down, 0.5f));

          float rotation = Input.GetAxis(_inputHorizontalAxis) * _rotationSpeed * Time.deltaTime;
          float translation = Input.GetAxis(_inputVerticalAxis) * _speed * Time.deltaTime;

          Animator.SetFloat(_moveSpeedHash, translation);

          transform.Translate(0, 0, translation);
          transform.Rotate(0, rotation, 0);
     }
}
