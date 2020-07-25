using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Texture2D fadeOutTexture; // the texture that will overlay the screen. 
    public float fadeSpeed = 0.8f;// the fading speed

    private int drawDepth = -1000; // the texture order in the draw hiercrchy
    private float alpha = 1.0f; // the texture alpha velue
    public int fadeDir = -1; // the direction to fade in = -1 out = 1
    // Start is called before the first frame update


    void OnGUI()
    {
        //fade out/in
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
