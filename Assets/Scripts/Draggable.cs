using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform returnParent = null;
	float returnDepth;
	GameObject placeholder = null;
	bool hovering = false;
	public Transform placeholderParent = null;

	public void OnBeginDrag(PointerEventData eventData) 
	{
		Debug.Log ("Drag Begin");

		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());
		this.transform.SetAsLastSibling ();

		returnParent = this.transform.parent;
		placeholderParent = returnParent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");

		this.transform.position = eventData.position;

		if (placeholder.transform.parent != placeholderParent)
			placeholder.transform.SetParent (placeholderParent);
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		Debug.Log ("OnEndDrag");

		this.transform.SetParent (returnParent);
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());

		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if (returnParent.tag == "Table") 
		{
			this.enabled = false;
		}

		Destroy (placeholder);
	}
}
