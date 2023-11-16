using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ModifiResolution : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private const string claveAncho = "AnchoResolucion";
    private const string claveAlto = "AltoResolucion";
    private int anchoPorDefecto = 1920;
    private int altoPorDefecto = 1080;
    void Start()
    {
        if (PlayerPrefs.HasKey("TextoGuardado"))
        {
            texto.text = PlayerPrefs.GetString("TextoGuardado");
        }
        int anchoGuardado = PlayerPrefs.GetInt(claveAncho, anchoPorDefecto);
        int altoGuardado = PlayerPrefs.GetInt(claveAlto, altoPorDefecto);
    }
    public void CambiarResolucionAncho(int ancho)//weight
    {
        int altoActual = Screen.height;
        EstablecerResolucion(ancho, altoActual);
        PlayerPrefs.SetInt(claveAncho, ancho);
        PlayerPrefs.Save();
    }

    public void CambiarResolucionAlto(int alto)//hight
    {
        int anchoActual = Screen.width;
        EstablecerResolucion(anchoActual, alto);
        PlayerPrefs.SetInt(claveAlto, alto);
        PlayerPrefs.Save();
    }
    public void CambiarTextoBoton(string nuevoTexto)
    {
        // Cambiar el texto
        texto.text = nuevoTexto;
        PlayerPrefs.SetString("TextoGuardado", nuevoTexto);
        PlayerPrefs.Save();
    }
    private void EstablecerResolucion(int ancho, int alto)
    {
        // Establecer la resolución
        Screen.SetResolution(ancho, alto, Screen.fullScreen);
    }
}
