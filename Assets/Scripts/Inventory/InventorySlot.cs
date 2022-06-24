using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	Item item;
	
	public Image icon;
	public Button removeButton;
	
	public void AddItem(Item newItem)
	{
		item = newItem;
		
		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.gameObject.SetActive(true);
	}
	
	public void RemoveItem()
	{
		//item.RemoveFromInventory();
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		removeButton.gameObject.SetActive(false);
	}
	
	public void UseItem()
	{
		if( item != null)
			item.Use();
	}

}
