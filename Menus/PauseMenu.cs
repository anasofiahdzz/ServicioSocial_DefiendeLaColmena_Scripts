using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public LogicaEntreEscenas panelOpciones;
    void Start()
    {
        //panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<LogicaEntreEscenas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MostrarOpciones();
    }

    public void MostrarOpciones()
    {
        panelOpciones.settingsScreen.SetActive(true);
    }
}