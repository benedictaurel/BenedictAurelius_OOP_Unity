using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    UIDocument document;
    Button button;
    float timer;
    float animationSpeed = 4f;
    float currentScale = 1f;
    float targetScale = 1.25f;

    WeaponPickup[] weaponPickup;
    
    void Awake() {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("StartButton") as Button;
        button.RegisterCallback<ClickEvent>(OnGameStart);
        weaponPickup = FindObjectsOfType<WeaponPickup>();
    }

    void Update() 
    {
        currentScale = Mathf.Lerp(currentScale, targetScale, Time.deltaTime * animationSpeed);
        button.style.scale = new Scale(Vector2.one * currentScale);

        if (Mathf.Abs(currentScale - targetScale) < 0.01f) 
        {
            targetScale = (targetScale == 1f) ? 1.25f : 1f;
        }
    }

    void OnDisable() {
        button.UnregisterCallback<ClickEvent>(OnGameStart);
    }

    void OnGameStart(ClickEvent evt) {
        foreach(var pickup in weaponPickup) {
            pickup.EnablePickup();
        }
        
        document.rootVisualElement.style.display = DisplayStyle.None;
    }
}
