using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBattery : MonoBehaviour,PowerStore
{
    // Start is called before the first frame update
    public double powerStored = 0;
    public double powerCapacity = 0;
    private static PowerManager powerManager;
    void Start()
    {
        if (powerManager == null){
            powerManager = PowerManager.Instance;
        }
        powerManager.addStore(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public double getAvailablePower(){

        return powerStored;
    }
    public void storePower(double power){
        this.powerStored = Mathf.Min((float)(power+this.powerStored),(float)this.powerCapacity);
    }
    public double getPower(double power){
        double powerRemoved = Mathf.Min((float)power,(float)this.powerStored);
        this.powerStored -= powerRemoved;
        return powerRemoved;
    }

}
