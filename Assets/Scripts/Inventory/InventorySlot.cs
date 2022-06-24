using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	Item item;
	
	public Image icon;
	public Button removeButton;
	public Button itemButton;

	public AudioClip closeClip;
	public AudioClip useClip;

	AudioSource audioSource;

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }

	// Cuando se ha añadido un item al inventario -> añadirlo al slot
    public void AddItem(Item newItem)
	{
		
		item = newItem;
		
		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.gameObject.SetActive(true);
		itemButton.interactable = true;
	}

	// El usuario pulsa el botón de eliminar item y:
	// - lanzamos la función asociada en el item
	// - sonido asociado al cierre
	// - Llamamos a función Remove del inventario
	public void CloseItem()
    {
		if (item != null)
			item.RemoveFromInventory();

		audioSource.clip = closeClip;
		audioSource.volume = 1.0f;
		audioSource.Play();
		Inventory.instance.Remove(item);
	}

	// Eliminamos item del slot
	public void RemoveItem()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		removeButton.gameObject.SetActive(false);
		itemButton.interactable = false;
	}

	// Llamamos a función User del item
	public void UseItem()
	{
		if (item != null)
		{
			audioSource.clip = useClip;
			audioSource.volume = 1.0f;
			audioSource.Play();
			item.Use();
		}
	}

}
