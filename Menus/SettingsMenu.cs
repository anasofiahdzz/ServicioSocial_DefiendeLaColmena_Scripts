using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Propiedades para el ajuste de volumen
    public Slider sliderVolumen;
    public float sliderVolumenValue;
    public Image imagenMute;

    //Propiedades para el ajuste de brillo
    public Slider sliderBrillo;
    public float sliderBrilloValue;
    public Image panelBrillo;

    // Propiedades para la pantalla completa
    public Toggle togglePantallaCompleta;

    // Propiedades para el ajuste de calidad
    public TMP_Dropdown dropdownCalidad;
    public int valorCalidad;

    // Prorpiedades para el ajuste de resolucion
    public TMP_Dropdown resolucionDropdown;
    Resolution[] resoluciones;

    private void Start()
    {
        // Ajustes de inicio del volumen
        sliderVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderVolumen.value;
        CheckMute();

        //Ajustes de inicio del brillo
        sliderBrillo.value = PlayerPrefs.GetFloat("brilloPantalla", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrillo.value);

        // Ajustes de inicio de pantalla completa
        togglePantallaCompleta.isOn = Screen.fullScreen;

        // Ajustes de inicio de calidad
        valorCalidad = PlayerPrefs.GetInt("calidad", 3);
        dropdownCalidad.value = valorCalidad;
        SetQuality();

        // Ajustes de inicio de resolucion
        CheckResolution();
    }

    public void ChangeSliderVolumen(float value)
    {
        sliderVolumenValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderVolumenValue);
        AudioListener.volume = sliderVolumen.value;
        CheckMute();
    }

    public void ChangeSliderBrillo(float value)
    {
        sliderBrilloValue = value;
        PlayerPrefs.SetFloat("brilloPantalla", sliderBrilloValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderBrilloValue);
    }

    public void CheckMute()
    {
        imagenMute.enabled = sliderVolumenValue == 0 ? true : false;
    }

    public void PutOnFullScreen(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        //PlayerPrefs.SetInt("pantallaCompleta", pantallaCompleta ? 1 : 0);
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropdownCalidad.value);
        PlayerPrefs.SetInt("calidad", dropdownCalidad.value);
        valorCalidad = dropdownCalidad.value;
    }


    private void CheckResolution()
    {
        resoluciones = Screen.resolutions;
        resolucionDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActualIndex = 0;

        for (int i = 0; i< resoluciones.Length; i++)
        {
            // Esto se utiliza para llenar el dropdown de resoluciones
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            if(opciones.IndexOf(opcion) == -1)
                opciones.Add(opcion);

            if (Screen.fullScreen 
                && resoluciones[i].width == Screen.currentResolution.width 
                && resoluciones[i].height == Screen.currentResolution.height)
                    resolucionActualIndex = i;
        }
        resolucionDropdown.AddOptions(opciones);
        resolucionDropdown.value = resolucionActualIndex;
        resolucionDropdown.RefreshShownValue();
        resolucionDropdown.value = PlayerPrefs.GetInt("resolucionIndice", 0);
    }

    public void ChangeResolution(int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolucionIndice", resolucionDropdown.value);
    }
}