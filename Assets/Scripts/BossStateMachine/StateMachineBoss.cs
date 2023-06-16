using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public MonoBehaviour startState;
    public MonoBehaviour idleState;
    public MonoBehaviour shootState;
    public MonoBehaviour meleeState;
    public MonoBehaviour deathState;

    private MonoBehaviour actualState;


    // Start is called before the first frame update
    private void Start()
    {
        ActivateState(startState);
    }

    // Update is called once per frame 

    public void ActivateState(MonoBehaviour newState){
        if (actualState != null)
        {
            actualState.enabled = false; 
        }
        actualState = newState;
        actualState.enabled = true; 
       
    }
    
}
