using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform returnParent = null;
	float returnDepth;

	public void OnBeginDrag(PointerEventData eventData) 
	{
		Debug.Log ("Drag Begin");

		returnParent = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");

		this.transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		Debug.Log ("OnEndDrag");

		this.transform.SetParent (returnParent);

		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if (returnParent.tag == "Table")
			this.enabled = false;
	}

	public void OnMouseOver()
	{
		Debug.Log ("Mouse Over");
		returnDepth = this.transform.position.z;
		returnParent = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -5);
	}

	public void OnMouseExit()
	{
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, returnDepth);
		this.transform.SetParent (returnParent);
	}
}
