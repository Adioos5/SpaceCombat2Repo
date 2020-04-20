using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelHandler : MonoBehaviour
{
    public GameObject fuelBar;
    private float startX;
    private float maxWidth;

    IEnumerator HandleFuel() {
        RectTransform rt = (RectTransform)fuelBar.transform;

        startX = fuelBar.transform.position.x;
        maxWidth = rt.rect.width;
     
        while (true) {
            while (transform.GetComponent<PlayerMovement>().isFlying) {


                if (rt.rect.width != 0f) {
                    rt.sizeDelta = new Vector2(rt.rect.width - 1f, rt.rect.height);
                    
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
       
    }

    public void RechargeFuel() {

    }

    // Start is called before the first frame update
    void Start() {  
        StartCoroutine(handleFuel());
    }


}
