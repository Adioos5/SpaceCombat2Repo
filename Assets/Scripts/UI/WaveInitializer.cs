using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveInitializer : MonoBehaviour
{
    public Text waveCounter;
    public Text waveTimer;
    public AliensSpawner aliensSpawner;
    public SuppliesSpawner suppliesSpawner;

    private int spawningLimitInt = 15;
    private int waveNumber = 1;
    private int waveTimeInSec = 30;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start() 
    { 
        coroutine = handleWaveCounter();
        StartCoroutine(coroutine);
    }

    private IEnumerator handleWaveCounter() {
        while(true) {

            waveCounter.text = $"Prepare for wave {waveNumber}!";
            waveTimer.text = "";

            yield return new WaitForSeconds(5);
            waveCounter.text = "3";
            yield return new WaitForSeconds(1);
            waveCounter.text = "2";
            yield return new WaitForSeconds(1);
            waveCounter.text = "1";
            yield return new WaitForSeconds(1);

            for (int i = 0; i < 5; i++) {
                aliensSpawner.SpawnAnAlien();
            }

            if (waveNumber == 1) 
                suppliesSpawner.LaunchDroppingSuppliesSystem();
            

            waveCounter.text = "Start!";
            yield return new WaitForSeconds(1);


            waveCounter.text = $"Wave {waveNumber}";

            for(int i = 0; i <= waveTimeInSec; i++) {

                int x = Random.Range(0, 30);
               
                if (x < spawningLimitInt) {
                    aliensSpawner.SpawnAnAlien();
                }

                if(waveTimeInSec - i>=10) waveTimer.text = $"00:{waveTimeInSec - i}";
                else waveTimer.text = $"00:0{waveTimeInSec - i}";

                yield return new WaitForSeconds(1);

            }
            waveNumber++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
