using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
	public Item item;
	
	public override void Interact()
	{
		Debug.Log("ItemPickUp");
		// Añadirlo al inventario;
		bool wasPickedUp = Inventory.instance.Add(item);
		
		// Está en el inventario y no en la escena;
		if(wasPickedUp)
			Destroy(this.gameObject);
		
	}
	
}
