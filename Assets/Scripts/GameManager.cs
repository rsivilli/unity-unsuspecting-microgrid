using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    WeatherManager weatherManager;
    PowerManager powerManager;
    [SerializeField]
    private int hour = 12;
    void Start()
    {
        Debug.Log("Start of Gamemanager");
        weatherManager =WeatherManager.Instance;
        powerManager = PowerManager.Instance;
        StartCoroutine(setUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator setUpdate(){
        hour = 12;
        while(true){
            weatherManager.updateWeather(hour);
            powerManager.updatePower();
            

            hour++;
            if(hour>=24){
                hour = 0;
            }
            yield return new WaitForSeconds(1.0f);

        }
    }
}
