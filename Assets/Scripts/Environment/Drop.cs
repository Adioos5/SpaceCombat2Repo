using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Drop : MonoBehaviour
{

    public List<GameObject> listOfDrops;
    public GameObject player;
    public Camera mainCamera;
    public GameObject inscription;
    private bool hasInitialized = false;
    private GameObject sign;
    private GameObject drop;
    public Text pixelText;

    public void ShowDropUp() {

        int x = Random.Range(0, listOfDrops.Count);

        drop = Instantiate(listOfDrops[x]) as GameObject;

        drop.transform.parent = transform;

        drop.transform.localPosition = listOfDrops[x].transform.localPosition;

        drop.SetActive(true);

        sign = Instantiate(inscription) as GameObject;
        //sign = new GameObject("player_label");
        sign.transform.rotation = mainCamera.transform.rotation; // Causes the text faces camera.
        sign.transform.position = new Vector3(drop.transform.position.x-0.18f, drop.transform.position.y+0.7f, drop.transform.position.z);
        //sign.transform.parent = drop.transform;
        sign.SetActive(true);

       /* TextMesh tm = sign.AddComponent<TextMesh>();
        tm.text = "Pick (E)";
        tm.color = new Color(0.8f, 0.8f, 0.8f);
        tm.fontStyle = pixelText.fontStyle;
        tm.font = pixelText.font;
        tm.alignment = TextAlignment.Center;
        tm.anchor = TextAnchor.MiddleCenter;
        tm.characterSize = 0.065f;
        tm.fontSize = 10;
        */
        hasInitialized = true;
    }

    private void Update() {
        if (hasInitialized) {
            drop.transform.LookAt(player.transform);

            sign.transform.rotation = mainCamera.transform.rotation;
            sign.transform.position = new Vector3(drop.transform.position.x - 0.18f, drop.transform.position.y + 0.7f, drop.transform.position.z);

            if (Vector3.Distance(drop.transform.position, player.transform.position) < 5f) {
                sign.active = true;
            } else {
                sign.active = false;
            }
        }
    }

}
