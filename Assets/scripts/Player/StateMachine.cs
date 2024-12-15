using UnityEngine;

public class StateMachine
{
    /// <summary>
    /// I could delete StartState and wrote this in ChangeState:
    /// _currentstate?.Exit();
    /// It didnt make much sense to look if there is a state every change of states.
    /// </summary>

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
