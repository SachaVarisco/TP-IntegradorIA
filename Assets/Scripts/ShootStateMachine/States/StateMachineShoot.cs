using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineShoot : MonoBehaviour
{
    public MonoBehaviour waitState;
    public MonoBehaviour shotState;
    public MonoBehaviour startState;

    [HideInInspector]
    public MonoBehaviour actualState;



    private void Start()
    {
        ActivateState(startState);
    }



    public void ActivateState(MonoBehaviour newState){
        if (actualState != null)
        {
            actualState.enabled = false; 
        }
        actualState = newState;
        actualState.enabled = true; 
       
    }
}
