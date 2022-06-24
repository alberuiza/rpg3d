using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
	public Item item;
	public AudioClip addClip;

	AudioSource audioSource;

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
		
	}

    public override void Interact()
	{

		Debug.Log("ItemPickUp-Interact");
		// Añadirlo al inventario;
		bool wasPickedUp = Inventory.instance.Add(item);

		// Está en el inventario y no en la escena;
		if (wasPickedUp)
		{
			audioSource.clip = addClip;
			audioSource.volume = 0.8f;
			audioSource.Play();
			// Oculto el mesh del objeto 
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.radio = 0.0f;
			// Espero dos segundos antes de destruir el objeto
			StartCoroutine(AudioControl());
		}
		
	}

	IEnumerator AudioControl()
    {
		yield return new WaitForSeconds(2.0f);
		Destroy(this.gameObject);
	}
	
}
