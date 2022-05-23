using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : Singleton<WeatherManager>
{
    // Start is called before the first frame update
    [SerializeField]
    float actualTemperature;
    [SerializeField]
    float predictedTemperature;
    [SerializeField]
    float actualWind;
    [SerializeField]
    float predictedWind;
    [SerializeField]
    float actualSolar;
    [SerializeField]
    float predictedSolar;
    public float ActualSolar{
        get{
            return actualSolar;
        }
    }
    public float ActualWind{
        get{
            return actualWind;
        }
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateWeather(int hour){
        updateTemp(hour);
        updateSolar(hour);
        updateWind(hour);

    }
    public void updateTemp(int hour ){
        this.actualTemperature = 20*Mathf.Sin(hour*2.0f*3.14f/24.0f+12.0f*3.14f*2.0f)+32;
    }
    public void updateSolar(int hour){
        this.actualSolar = Mathf.Max(10*Mathf.Sin(hour*2.0f*3.14f/24.0f+12.0f*3.14f*2.0f),0.0f);

    } 
    public void updateWind(int hour){
        this.actualWind = 0;
    }
}
