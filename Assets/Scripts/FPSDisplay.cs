/*
 * File: /Assets/Scripts/FPSDisplay.cs
 * Project: Greyville 2018
 * Created Date: Thursday July 12th 2018
 * Author: Neo Cortex
 * -----
 * Last Modified: Thursday July 12th 2018 6:34:52 am
 * Modified By: Neo Cortex
 * -----
 * Copyright (c) 2018 NeoGrid Space
 * -----
 * HISTORY:
 * 2018-11-16	NC	added file header
 */
using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(100, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        // string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        string text = string.Format("({0:0.} fps)", fps);
        GUI.Label(rect, text, style);
    }
}