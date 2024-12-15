using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player_ : Entity_Unit
{

    #region States 

    public Player_Idle idle;
    public Player_Walk walk;
    public Player_Atack atack;
    public StateMachine stateMachine;

    #endregion

    public Animator _animator;

    void Start()
    {
        AnimSetUp();
        stateMachine.StartState(idle);
    }
    void Update()
    {
        stateMachine._currentState.Do();
    }
    void StateSelection()
    {

    }
    private void AnimSetUp()
    {
        stateMachine = new StateMachine();
        State[] states = GetComponentsInChildren<State>();
        foreach (var i in states)
        {
            i._animator = this._animator;
        }
    }
}
