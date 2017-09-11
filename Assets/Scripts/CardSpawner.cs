using UnityEngine;
using UnityEngine.Networking;

public class CardSpawner : MonoBehaviour {

    public GameObject CardPrefab;

    public void SpawnCard(Card card, Transform parent, bool isLocalPlayer)
    {
        GameObject go = (GameObject)Instantiate(CardPrefab, parent);
        go.GetComponent<UICard>().cardInfo = card;
        go.transform.SetParent(parent, false);
        NetworkServer.Spawn(go);

        if (!isLocalPlayer)
            go.GetComponent<Draggable>().enabled = false;
    }
}
