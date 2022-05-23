
using UnityEngine;


abstract public class BaseGenerator : MonoBehaviour, PowerGenerator
{
    static protected WeatherManager weatherManager;
    static protected PowerManager powerManger;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        if(weatherManager == null){
            weatherManager = WeatherManager.Instance;
        }
        if(powerManger == null){
            powerManger = PowerManager.Instance;
        }
        powerManger.addGenerator(this);
        
    }
    public abstract double getPower();

    // Update is called once per frame
    void Update()
    {
        
    }
    

    
}
