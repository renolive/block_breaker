using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    int LEFT_BUTTON = 0;

    public delegate void ButtonClick();
    public static event ButtonClick OnLeftButtonClick;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_BUTTON)) {
            OnLeftButtonClick?.Invoke();
        }
    }
}
