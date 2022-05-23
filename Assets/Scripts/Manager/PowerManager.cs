using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerManager : Singleton<PowerManager> 
{
    [SerializeField]
    List<PowerGenerator> powerGenerators = new List<PowerGenerator>();
    
    [SerializeField]
    List<PowerUser> powerUsers = new List<PowerUser>();
    [SerializeField]
    List<PowerStore> powerStores = new List<PowerStore>();
    PowerManager powerManger;
    // Start is called before the first frame update

    private double powerGen, powerDesired,powerAvailable,powerSold,powerDiff,desiredPowerSold;
    public double PowerGenerated{
        get{
            return powerGen;
        }
    }
    public double PowerDesired{
        get{
            return powerDesired;
        }
    }
    public double PowerAvailable{
        get{
            return PowerAvailable;
        }
    }
    public double PowerSold{
        get{
            return powerSold;
        }
    }
    public double PowerDifference{
        get{
            return powerDiff;
        }
    }
    public double DesiredPowerSold{
        get{
            return desiredPowerSold;
        }
    }
    void Start()
    {
        Debug.Log("Power Manager has started");


        

        
    }
    public void updatePower(){

            powerGen = calcPowerGen();
            powerDesired = calcPowerDesired();
            powerAvailable = calcAvailablePower();
            desiredPowerSold = getDesiredSell();
            powerSold = Mathf.Min((float)powerGen+(float)powerAvailable,(float)desiredPowerSold);
            powerDiff = powerGen-powerDesired-powerSold;
            
            double capSplit = powerDiff/powerStores.Count;
            if(capSplit>=0){
                Debug.Log("Capacitor Split is positive, adding to batteries");
                
                foreach(PowerStore store in powerStores){
                    store.storePower(capSplit);
                }
                foreach(PowerUser user in powerUsers){
                    user.usePower(user.getIdealLoad());
                }

            }else{
                Debug.Log("Capacitor Split is negative, removing from batteries");
                foreach(PowerStore store in powerStores){
                    powerGen += store.getPower(-1.0*capSplit);
                }
                double allocatedPower = Mathf.Min((float)(powerGen/powerDesired),1.0f);
                foreach(PowerUser user in powerUsers){
                    float val = Mathf.Min(new float[] {(float)allocatedPower*(float)user.getIdealLoad(),(float)powerGen});
                    user.usePower(val);
                    powerGen = Mathf.Max((float)(powerGen-val),0);
                }

            }
            
        
    }

    // Update is called once per frame
    void Update()
    {
        

        // #update power generation
        // #calculate load
        // #if load is higher than generation, pull from storage
        // #if if storage is 
        // #if load is less than 

    }

    private double calcPowerGen(){
        double sum = 0;
        foreach (PowerGenerator gen in powerGenerators){
            sum += gen.getPower();
        }
        return sum;
    }
    private double calcPowerDesired(){
        double sum = 0;
        foreach(PowerUser user in powerUsers){
            sum+= user.getIdealLoad();
        }
        return sum;
    }
    private double getDesiredSell(){
        return 0;
    }
    private double calcAvailablePower(){
        double sum = 0;
        foreach(PowerStore store in powerStores){
            sum += store.getAvailablePower();
        }
        return sum;
    } 
    public void addGenerator(PowerGenerator generator){
        this.powerGenerators.Add(generator);
    }
    public void addStore(PowerStore store){
        this.powerStores.Add(store);
    }
    public void addUser(PowerUser user){
        this.powerUsers.Add(user);
    }

}
