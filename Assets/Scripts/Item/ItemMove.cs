using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : Interactable
{
	float positiony;
	
	private void Start()
	{
		positiony = this.transform.position.y;
	}
	
	public override void Interact()
	{
		this.gameObject.transform.position = new Vector3(this.transform.position.x,
											this.transform.position.y + 0.5f,
											this.transform.position.z);
	}
	
	public override void NoInteract()
	{
		this.gameObject.transform.position = new Vector3(this.transform.position.x,
											positiony,
											this.transform.position.z);
	}
}
