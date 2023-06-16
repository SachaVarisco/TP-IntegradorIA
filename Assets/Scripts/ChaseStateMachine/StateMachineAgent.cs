using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineAgent : MonoBehaviour
{
    public MonoBehaviour patrollState;
    public MonoBehaviour chaseState;
    public MonoBehaviour alertState;
    public MonoBehaviour startState;

    [HideInInspector]
    public MonoBehaviour actualState;


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

