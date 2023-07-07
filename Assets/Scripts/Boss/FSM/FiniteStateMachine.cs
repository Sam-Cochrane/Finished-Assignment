using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> states;

    private BaseState currentState;

    public BaseState CurrentState
    {
        get
        {
            return currentState;
        }
        private set
        {
            currentState = value;
        }

    }

    public void SetStates(Dictionary<Type, BaseState> states)
    {
        Debug.Log("Setting states");

        this.states = states;

    }

    void Update()
    {
        if (states == null)
        {
            Debug.Log("NO STATES");
        }

        if (CurrentState == null)
        {
            CurrentState = states.Values.First();
        }
        else
        {
            var nextState = CurrentState.StateUpdate();

            if (nextState != null && nextState != CurrentState.GetType())
            {
                SwitchToState(nextState);
            }
        }
    }

    void SwitchToState(Type nextState)
    {
        CurrentState.StateExit();
        CurrentState = states[nextState];
        CurrentState.StateEnter();

    }
}
