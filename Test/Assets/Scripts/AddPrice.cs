using UnityEngine;
using UnityEngine.UI;

public class AddPrice : MonoBehaviour
{
     [SerializeField]
     private Text _text;
     private Text tempTextBox;

     private Inventory _inventory;
     public Inventory Inventory
     {
          get
          {
               if (_inventory == null)
               {
                    _inventory = GetComponent<Inventory>();
               }
               return _inventory;
          }
     }

     public void TextPrice(int price)
     {
          tempTextBox.text = ($"Cost: {price}");
     }


     public void AddItem(GameObject currentItem)
     {

          for (int i = 0; i < Inventory.slots.Length; i++)
          {
               if (Inventory.isFull[i] == false)
               {
                    Inventory.isFull[i] = true;
                    GameObject parent= Instantiate(currentItem, Inventory.slots[i].transform, false) as GameObject;
                    InstantiateText(parent,i);
                    break;
               }
          }

     }
     private void InstantiateText(GameObject parent,int i)
     {
          Vector2 position = new Vector2(Inventory.slots[i].transform.position.x, Inventory.slots[i].transform.position.y - 37f);
          tempTextBox = Instantiate(_text, position, transform.rotation) as Text;
          tempTextBox.transform.SetParent(parent.transform,false);
          tempTextBox.transform.position = position;
          tempTextBox.transform.rotation = Quaternion.Euler(0, 0, 0);
     }
}
