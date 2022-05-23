using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarGenerator : BaseGenerator
{
    // Start is called before the first frame update
    [SerializeField]
    double efficiency=.25;
    
    override protected void Start()
    {
        base.Start();
        
    }
    public override double getPower()
    {
        if(enabled){
            return Generator.weatherManager.ActualSolar*efficiency;
        }else{
            return 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
