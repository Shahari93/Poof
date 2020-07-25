
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class DemoScriptImage : MonoBehaviour
    {
        public FingersImageGestureHelperComponentScript ImageScript;
        public ParticleSystem MatchParticleSystem;
        public AudioSource AudioSourceOnMatch;
        public float imageTimer = 0f;
        private void LinesUpdated(object sender, System.EventArgs args)
        {
           // Debug.LogFormat("Lines updated, new point: {0},{1}", ImageScript.Gesture.FocusX, ImageScript.Gesture.FocusY);
        }

        private void LinesCleared(object sender, System.EventArgs args)
        {
          //  Debug.LogFormat("Lines cleared!");
        }

        private void Start()
        {
            ImageScript.LinesUpdated += LinesUpdated;
            ImageScript.LinesCleared += LinesCleared;
        }

        void Update()
        {

           
            if (!FingersScript.singleton.IsTouching)
            {
                imageTimer += Time.deltaTime;
            }
           

 
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ImageScript.Reset();
                imageTimer = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.Space)||imageTimer>=1f)
            {
                
                ImageGestureImage match = ImageScript.CheckForImageMatch();

                if (match != null)
                {
                    //Debug.Log("Found image match: " + match.Name);
                    MatchParticleSystem.Play();
                    AudioSourceOnMatch.Play();
                    imageTimer = 0f;
                    imageTimer += Time.deltaTime;
                   
                    
                }
                else
                {
                    //Debug.Log("No match found!");
                    ImageScript.Reset();
                    imageTimer = 0f;
                }
                

            }
           // print(imageTimer);
        }
    }
}
