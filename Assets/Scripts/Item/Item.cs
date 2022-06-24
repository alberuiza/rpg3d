using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;
	public bool showInventory = true;
	public GameObject model;
	
	public void Use()
	{
		Debug.Log("Item.Use ");
	}
	
	public void RemoveFromInventory()
	{
		Debug.Log("Item.RemoveFromInventory ");

		// Buscamos transform del Player
		Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		// posición donde instanciar el item
		Vector3 positionPrefab = new Vector3(
			playerTransform.position.x + 2.0f,
			playerTransform.position.y + 2.0f,
			playerTransform.position.z
			);

		// Instanciamos el item
		GameObject itemPrefab =  Instantiate(model,
			positionPrefab,
			playerTransform.rotation);

		// Añadimos script ItemPickUp
		itemPrefab.AddComponent<ItemPickUp>();

		// Añadimos referencia el item
		itemPrefab.GetComponent<ItemPickUp>().item = this;

		// Añadimos referencia al transform del player
		itemPrefab.GetComponent<ItemPickUp>().player = GameObject.FindGameObjectWithTag("Player").transform;

		// Cargamos audio para pick up
		Debug.Log("Audio pickup");
		AudioClip addClip = Resources.Load("pick-up") as AudioClip;
		Debug.Log(addClip.name);
		itemPrefab.GetComponent<ItemPickUp>().addClip = addClip;

	}
}
