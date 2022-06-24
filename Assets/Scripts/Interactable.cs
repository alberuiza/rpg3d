using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public float radio = 1.0f;
	public Transform player;
	bool hasInteracted = false;
	
	
	public virtual void Interact()
	{
		//Debug.Log(" Interacting with: " + transform.name);
	}
	
	public virtual void NoInteract()
	{
		//Debug.Log(" NO Interacting with: " + transform.name);
	}
	
	private void Update()
	{
		float distance = Vector3.Distance( transform.position, player.position );
		
		if( (distance < radio) && (!hasInteracted) )
		{
			Interact();
			hasInteracted = true;
		} 
		else if( distance >= radio )
		{
			NoInteract();
			hasInteracted = false;
		}
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radio);
	}

}
