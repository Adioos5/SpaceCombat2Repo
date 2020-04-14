using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

  public class AudioManager : MonoBehaviour{

        public AudioSource pistolSound;

        void Awake() {
            
        }

        public void PlayShotSound() {
            AudioSource playShot = Instantiate(pistolSound) as AudioSource;
            playShot.Play();
        }

    }

