using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationControl : MonoBehaviour
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

     private int _axeAtackHash = Animator.StringToHash("Axe");
     private int _greatAxeAtackHash = Animator.StringToHash("GreatAxe");
     private int _maceAtackHash = Animator.StringToHash("Mace");
     private int _hash;

     private void Update()
     {
          bool down = Input.GetKeyDown(KeyCode.Space);

          if (down)
          {
               AtackAnimation();
          }
     }

     private void OnTriggerEnter(Collider other)
     {
          GreatAxe greatAxe = other.GetComponent<GreatAxe>();
          if (greatAxe != null)
          {
               _hash = _greatAxeAtackHash;
          }

          Axe axe = other.GetComponent<Axe>();
          if (axe != null)
          {
               _hash = _axeAtackHash;
          }

          Mace mace = other.GetComponent<Mace>();
          if (mace != null)
          {
               _hash = _maceAtackHash;
          }
     }

     private void AtackAnimation()
     {
          Animator.SetBool(_hash, true);
     }
}
