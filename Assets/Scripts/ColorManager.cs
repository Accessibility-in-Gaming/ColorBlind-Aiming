using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{

    public Color deutHighlight = Color.yellow;
    public Color protHighlight = Color.yellow;
    public Color tritHighlight = Color.magenta;
    public Color deutCrosshair = Color.cyan;
    public Color protCrosshair = Color.cyan;
    public Color tritCrosshair = Color.green;
    public Color defHighlight = Color.clear;
    public Color defCrosshair = Color.red;
    
    public Color OutlineColor{
        get{return outlineColor;}
        set{
            outlineColor = value;
            UpdateOutlineColor();
        }
    }

    public Color ImageColor{
        get{return imageColor;}
        set{
            imageColor = value;
            UpdateImageColor();
        }
    }

    [SerializeField]
    private Color outlineColor = Color.red;

    [SerializeField]
    private Color imageColor = Color.white;

    void Awake(){
        UpdateImageColor();
    }

    void UpdateOutlineColor(){
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ColorElementOutlineCS");

        foreach(GameObject gameObject in gameObjects){
            Outline objectOutline = gameObject.GetComponent<Outline>();
            objectOutline.OutlineColor = outlineColor;
        }
    }

    void UpdateImageColor(){
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("CrosshairImage");

        foreach (GameObject gameObject in gameObjects){
            
            if (gameObject.TryGetComponent<Image>(out var image))            {
                image.color = imageColor;
            }
        }
    }
}
