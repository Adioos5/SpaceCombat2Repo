using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuppliesSpawner : MonoBehaviour
{

    private IEnumerator coroutine;
    public Text timeText;
    private int time;
    public GameObject spawningMother;
    public List<GameObject> spawningAreas;

    [HideInInspector]
    public bool isSupplyGrounded = false;
    [HideInInspector]
    public bool isSupplyOpened = false;

    public void SpawnSupply() {

        GameObject supplies = Instantiate(spawningMother) as GameObject;

        supplies.transform.parent = transform;

        supplies.transform.localPosition = spawningAreas[Random.Range(0, spawningAreas.Count)].transform.localPosition;

        supplies.SetActive(true);
      

    }


    private IEnumerator KeepDroppingSupplies() {
        while (true) {
           
            for(int i = 0; i <= time; i++) {
                if (time - i < 10) {
                    timeText.text = $"Next drop in 00:0{time - i}";
                } else {
                    timeText.text = $"Next drop in 00:{time - i}";
                }
                yield return new WaitForSeconds(1);
            }

            timeText.text = "Drop incoming!";
            SpawnSupply();
            while (!isSupplyGrounded) {
                yield return new WaitForSeconds(0.1f);
                //waiting
            }
            timeText.text = "Drop awaiting";
            while (!isSupplyOpened) {
                yield return new WaitForSeconds(0.1f);
                //waiting
            }

            isSupplyGrounded = false;
            isSupplyOpened = false;

            timeText.text = "Drop received";

            yield return new WaitForSeconds(2);
        }
    }

    public void LaunchDroppingSuppliesSystem() {
        StartCoroutine(coroutine);
    } 

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Next drop in 00:00";
        time = 10;
        coroutine = KeepDroppingSupplies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
