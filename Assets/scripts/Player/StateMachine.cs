using UnityEngine;

public class StateMachine
{
    public State _currentState;

    public void StartState(State _state)
    {
        _currentState = _state;
        _currentState.Enter();
    }
    public void ChangeState(State _state)
    {
        _currentState.Exit();
        _currentState = _state;
        _currentState.Enter();
    }
}
