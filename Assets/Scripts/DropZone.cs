using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log ("OnDrop to " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) 
		{
			d.returnParent = this.transform;
		}
	}
}
