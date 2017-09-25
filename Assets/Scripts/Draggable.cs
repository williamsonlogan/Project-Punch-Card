using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Draggable : Photon.MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform returnParent = null; //Parent that a card will return to
	float returnDepth;
	GameObject placeholder = null; //Card that holds an empty space in the hand
	bool hovering = false;
	public Transform placeholderParent = null; //Parent of the placeholder
    int cardIndex;

	public void OnBeginDrag(PointerEventData eventData) 
	{
		Debug.Log ("Drag Begin");

        //Network translation
        cardIndex = this.gameObject.transform.GetSiblingIndex();

		//Spawn placeholder and set its parent to the cards parent
		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());
		this.transform.SetAsLastSibling ();

		//Set return parent
		returnParent = this.transform.parent;
		placeholderParent = returnParent;
		this.transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag (PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");

		//Make card follow mouse, magnify its scale for readability
		this.transform.position = eventData.position;
		this.transform.localScale = new Vector2 (1.25f, 1.25f);

		if (placeholder.transform.parent != placeholderParent) //Safeguard to be sure parents are correct
			placeholder.transform.SetParent (placeholderParent);
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		Debug.Log ("OnEndDrag");

		this.transform.localScale = new Vector3 (1, 1, 1); //Reset scale to no longer be magnified

		this.transform.SetParent (returnParent); //Sets its parent to the appropriate container
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ()); //Sets the order in the container

		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		//Disables dragging after its placed on a tablezone
		if (returnParent.tag == "Table") {
            Player localPlayer = GameObject.FindWithTag("Local Player").GetComponent<Player>();
            localPlayer.UpdateOppHand(cardIndex, returnParent);
			this.enabled = false;
		}

		Destroy (placeholder); //Destroys blank space placeholder
	}
}
