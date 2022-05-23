using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : BaseGenerator
{
    // Start is called before the first frame update
    [SerializeField]
    double efficiency=.25;
    override protected void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override double getPower()
    {
        if(enabled){
            return efficiency*weatherManager.ActualWind;
        }else{
            return 0;
        }
        
    }
}
