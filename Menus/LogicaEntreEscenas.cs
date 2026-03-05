using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicaEntreEscenas : MonoBehaviour
{
    public GameObject settingsScreen;

    private void Awake()
    {
        var dontDestroyBetweenScenes = FindObjectsOfType<LogicaEntreEscenas>();
        if (dontDestroyBetweenScenes.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}