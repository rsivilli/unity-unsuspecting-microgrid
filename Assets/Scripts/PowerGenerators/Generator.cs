
using UnityEngine;


public class Generator : BaseGenerator
{

    public bool isEnabled = true;
    public double staticPower = 5;
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public double getPower(){
        return staticPower;
    }

    
}
