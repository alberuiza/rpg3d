using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Singleton
	public static Inventory instance;
	private void Awake()
	{
		instance = this;
	}
	#endregion
	
	#region Variables
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;
	
	public List<Item> items = new List<Item>();
	public int inventorySize;
	
	#endregion
	
	#region Functions
	public bool Add(Item item)
	{
		 if( item.showInventory )
		 {
			 if( items.Count >= inventorySize  )
			 {
				 return false;
			 }
			 items.Add(item);
			 
			 if(onItemChangedCallback != null) onItemChangedCallback();
			 
			 return true;
		 }
		 return false;		 
	}		
	
	public void Remove(Item item)
	{
		items.Remove(item);
		if(onItemChangedCallback != null) onItemChangedCallback();
	}
	
	#endregion
}
