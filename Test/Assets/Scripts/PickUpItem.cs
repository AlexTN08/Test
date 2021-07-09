using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PickUpItem : MonoBehaviour
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
     private AddPrice _addPrice;
     public AddPrice AddPrice
     {
          get
          {
               if (_addPrice == null)
               {
                    _addPrice = GetComponent<AddPrice>();
               }
               return _addPrice;
          }
     }


     private Weapons _currentWeapon;
     private int _pickUpHash = Animator.StringToHash("Pickup");
     private int _curreentPrice;

     private void OnTriggerEnter(Collider other)
     {
          Weapons weapons = other.GetComponent<Weapons>();
          if (weapons == null || weapons == _currentWeapon) return;
          if (_currentWeapon != null)
          {
               Destroy(_currentWeapon.gameObject);
          }
          Animator.SetBool(_pickUpHash, true);
          weapons.transformPosOnPick();
          _currentWeapon = weapons;

          GreatAxe greatAxe = other.GetComponent<GreatAxe>();
          if (greatAxe != null)
          {
               _curreentPrice = greatAxe.price;
               
               AddPrice.AddItem(greatAxe.item);
               AddPrice.TextPrice(_curreentPrice);

          }

          Axe axe = other.GetComponent<Axe>();
          if (axe != null)
          {
               _curreentPrice = axe.price;

               AddPrice.AddItem(axe.item);
               AddPrice.TextPrice(_curreentPrice);

          }

          Mace mace = other.GetComponent<Mace>();
          if (mace != null)
          {
               _curreentPrice = mace.price;

               AddPrice.AddItem(mace.item);
               AddPrice.TextPrice(_curreentPrice);
          }
     }
}

