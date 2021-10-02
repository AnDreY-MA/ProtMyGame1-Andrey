using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    //Текущее состояние
    public State currentState { get; private set; }

    //Установка первого состояни при запуске
    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    //Изменение состояния 
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}