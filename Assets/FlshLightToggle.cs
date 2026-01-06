using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlshLightToggle : MonoBehaviour
{
    public Sprite flashlightOnSprite;  // Drag the "flashlight on" sprite here
    public Sprite flashlightOffSprite; // Drag the "flashlight off" sprite here

    private SpriteRenderer spriteRenderer;
    private bool flashlightOn = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = flashlightOffSprite;  // Start with flashlight off
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            flashlightOn = !flashlightOn;  // Toggle state
            spriteRenderer.sprite = flashlightOn ? flashlightOnSprite : flashlightOffSprite;
        }
    }
}
