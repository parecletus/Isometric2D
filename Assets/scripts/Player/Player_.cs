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
        AnimSetUp(_animator);
        stateMachine.StartState(idle);
    }
    void Update()
    {
        stateMachine._currentState.Do();

        if (Input.GetKeyDown(KeyCode.E))
        {
            GlobalEvents<bool>.tiles.Execute(false);
        }
    }
    void StateSelection(Vector2 sa)
    {

    }

    public void Wheneventrised()
    {

    }
    public void AnimSetUp(Animator animator)
    {
        stateMachine = new StateMachine();
        State[] states = GetComponentsInChildren<State>();
        foreach (var i in states)
        {
            i._animator = this._animator;
        }
    }
}
