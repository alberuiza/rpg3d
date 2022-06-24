using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Transform itemsParent;
	
	Inventory inventory;
	
	InventorySlot[] slots;
	
	void OnDestroy()
	{
		Inventory.instance.onItemChangedCallback -= UpdateUI;	
	}
	
	void Start()
	{
		Inventory.instance.onItemChangedCallback += UpdateUI;
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	// Función para actualizar la UI del inventario cada vez que se añade o borra un elemento
	void UpdateUI()
	{
		for(int i=0; i  < slots.Length; i++)
		{
			if ( i < Inventory.instance.items.Count)
			{
				slots[i].AddItem( Inventory.instance.items[i]);
			}
			else
			{
				slots[i].RemoveItem();
			}
		}
		
	}

}
