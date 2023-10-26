using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField] protected TimeSystem _timeSys;
    [Range(0, 86400)] public float timeday;//los segundos en un dia
    private void Start()
    {
        timeday = 25200;//los segundos si fueran las 7am
    }
    private void Update()
    {
        if (Preset == null) return;
        
        if(Application.isPlaying)
        {
            timeday += _timeSys.multipltime * Time.deltaTime;
            timeday %= 86400;
            UpdatingLight(timeday/86400f);
        }
        else
        {
            UpdatingLight(timeday/86400f);
        }
    }
    private void UpdatingLight(float timerPercent)
    {
        RenderSettings.ambientLight = Preset.ambientColor.Evaluate(timerPercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timerPercent);
        if(DirectionalLight!=null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timerPercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timerPercent * 360f) - 90f, 170, 0));
        }
    }
    private void OnValidate()
    {
        if (DirectionalLight != null)  return; 
        if (RenderSettings.sun != null) 
        {
            DirectionalLight = RenderSettings.sun; 
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light _light in lights)
            {
                if(_light.type==LightType.Directional)
                {
                    DirectionalLight = _light;
                    return;
                }
            }
        }
    }
}
