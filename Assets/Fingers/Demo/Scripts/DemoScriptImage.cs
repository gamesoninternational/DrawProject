using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    /// <summary>
    /// Demo script that matches a drawn image
    /// </summary>
    public class DemoScriptImage : MonoBehaviour
    {
        /// <summary>
        /// Image script
        /// </summary>
        [Tooltip("Image gesture helper component script")]
        public FingersImageGestureHelperComponentScript ImageScript;

        /// <summary>
        /// Match particle system
        /// </summary>
        [Tooltip("Matched particle system")]
        public ParticleSystem MatchParticleSystem;

        /// <summary>
        /// Match audio source
        /// </summary>
        [Tooltip("Match audio source")]
        public AudioSource AudioSourceOnMatch;

        private void LinesUpdated(object sender, System.EventArgs args)
        {
            //Debug.LogFormat("Lines updated, new point: {0},{1}", ImageScript.Gesture.FocusX, ImageScript.Gesture.FocusY);
        }

        private void LinesCleared(object sender, System.EventArgs args)
        {
            Debug.LogFormat("Lines cleared!");
        }

        private void Start()
        {
            ImageScript.LinesUpdated += LinesUpdated;
            ImageScript.LinesCleared += LinesCleared;
        }

        void Update()
        {
            // Check if there are touches on the screen
            if (Input.touchCount > 0)
            {
                // Get the first touch (you can also handle multiple touches if needed)
                Touch touch = Input.GetTouch(0);

                // Check the touch phase
                switch (touch.phase)
                {
                    // Finger just touched the screen
                    case UnityEngine.TouchPhase.Began:
                        OnTapDown(touch.position);
                        break;

                    // Finger lifted off the screen
                    case UnityEngine.TouchPhase.Ended:
                        OnTapUp(touch.position);
                        break;
                }
            }

            // Additionally, handle mouse input for testing in the editor
            if (Input.GetMouseButtonDown(0))
            {
                OnTapDown(Input.mousePosition);
                Debug.Log("Masih Gambar");
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnTapUp(Input.mousePosition);
                Debug.Log("Beres Gambar");
            }
        }

        // Function called when a tap begins
        void OnTapDown(Vector2 position)
        {
            Debug.Log("Tap Down at position: " + position);
            // Add your logic here for what should happen when the screen is tapped
        }

        // Function called when a tap ends
        void OnTapUp(Vector2 position)
        {
            Debug.Log("Tap Up at position: " + position);
            // Add your logic here for what should happen when the tap is released
            HandleImageCheck();
        }

        private void LateUpdate()
        {
            // No need to call HandleImageCheck here, as it is already called in OnTapUp
        }

        private void HandleImageCheck()
        {
            ImageGestureImage match = ImageScript.CheckForImageMatch();
            if (match != null)
            {
                Debug.Log("Found image match: " + match.Name);
                MatchParticleSystem.Play();
                AudioSourceOnMatch.Play();
                //====================================================================================HorizontalLine
                if (match.Name == "Horizontal Line"){
                    Debug.Log("Musuh Horizontal Mati");
                    // Mencari GameObject dengan tag "HorizontalLine"
                    GameObject DrawObject = GameObject.FindGameObjectWithTag("HorizontalLine");
                    
                    // Jika GameObject ditemukan, hancurkan
                    if (DrawObject != null)
                    {
                        DrawObject.SetActive(false);
                        
                    }
                    else
                    {
                        
                    }
                }
                //====================================================================================VerticalLine
                if (match.Name == "Vertical Line"){
                    Debug.Log("Musuh Horizontal Mati");
                    // Mencari GameObject dengan tag "HorizontalLine"
                    GameObject DrawObject = GameObject.FindGameObjectWithTag("VerticalLine");
                    
                    // Jika GameObject ditemukan, hancurkan
                    if (DrawObject != null)
                    {
                        DrawObject.SetActive(false);
                        
                    }
                    else
                    {
                        
                    }
                }
                //====================================================================================DiagonalLeft
                if (match.Name == "Diagonal Line /"){
                    Debug.Log("Musuh Horizontal Mati");
                    // Mencari GameObject dengan tag "HorizontalLine"
                    GameObject DrawObject = GameObject.FindGameObjectWithTag("Diagonal Left");
                    
                    // Jika GameObject ditemukan, hancurkan
                    if (DrawObject != null)
                    {
                        DrawObject.SetActive(false);
                        
                    }
                    else
                    {
                        
                    }
                }
                //====================================================================================DiagonalRight
                if (match.Name == "Diagonal Line \\"){
                    Debug.Log("Musuh Horizontal Mati");
                    // Mencari GameObject dengan tag "HorizontalLine"
                    GameObject DrawObject = GameObject.FindGameObjectWithTag("Diagonal Right");
                    
                    // Jika GameObject ditemukan, hancurkan
                    if (DrawObject != null)
                    {
                        DrawObject.SetActive(false);
                        
                    }
                    else
                    {
                        
                    }
                }
                //====================================================================================LetterL
                if (match.Name == "LetterL"){
                    Debug.Log("Musuh Horizontal Mati");
                    // Mencari GameObject dengan tag "HorizontalLine"
                    GameObject DrawObject = GameObject.FindGameObjectWithTag("LetterL");
                    
                    // Jika GameObject ditemukan, hancurkan
                    if (DrawObject != null)
                    {
                        DrawObject.SetActive(false);
                        
                    }
                    else
                    {
                        
                    }
                }

                if (match.Name == "Square"){
                    Debug.Log("Musuh Square Mati");
                }
            }
            else
            {
                Debug.Log("No match found!");
                ImageScript.Reset();
            }

            // TODO: Do something with the match
            // You could get a texture from it:
            // Texture2D texture = FingersImageAutomationScript.CreateTextureFromImageGestureImage(match);
        }
    }
}
