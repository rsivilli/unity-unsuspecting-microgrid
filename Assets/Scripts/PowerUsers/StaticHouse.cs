using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticHouse : MonoBehaviour,PowerUser
{
    // Start is called before the first frame update
    double static_load = 5;
    static PowerManager powerManager;
    void Start()
    {
        if(powerManager == null){
            powerManager = PowerManager.Instance;
        }
        powerManager.addUser(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public double getIdealLoad(){
        return static_load;
    }
    public void usePower(double power){
        if(power< static_load && power>0){
            Debug.Log("Experiencing brownout");
        }
        if(power<=0){
            Debug.Log("Experiencing blackout");
        }
        
    }
}
