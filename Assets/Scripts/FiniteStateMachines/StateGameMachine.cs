using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameMachine
{
    protected Dictionary<int, GameState> mGameStates;
    protected GameState mCurrentState;

    public StateGameMachine()
    {
        mGameStates = new Dictionary<int, GameState>();
        mCurrentState = null;
    }

    public StateGameMachine(Dictionary<int, GameState> states, GameState currentState)
    {
        mGameStates = states;
        mCurrentState = currentState;
    }

    public void addState(GameState state)
    {
        mGameStates.Add(state.stateIDs, state);
    }

    public void addState(int ids, GameState state)
    {
        mGameStates.Add(ids, state);
    }

    public GameState getState(int id)
    {
        return mGameStates[id];
    }

    public void setCurrentState(GameState state)
    {
        if(mCurrentState != null)
        {
            mCurrentState.Exit();
        }
        mCurrentState = state;
        if(mCurrentState != null)
        {
            mCurrentState.Enter();
        }
    }

    public GameState getCurrentState()
    {
        return mCurrentState;
    }

    public void Update()
    {
        if(mCurrentState != null)
        {
            mCurrentState.Update();
        }
    }

    public void FixedUpdate()
    {
        if (mCurrentState != null)
        {
            mCurrentState.FixedUpdate();
        }
    }
}

public class GameState
{
    public int stateIDs;
    protected StateGameMachine StateGameMachine;

    public GameState(int stateIDs, StateGameMachine stateGameMachine)
    {
        this.stateIDs = stateIDs;
        StateGameMachine = stateGameMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void FixedUpdate() { }
    public virtual void Update() { }
}

public class MenuState : GameState
{
    readonly protected string GAME_LOOP_SCENE_NAME = "GamePlay";

    public MenuState(int stateIDs, StateGameMachine stateGameMachine) : base(stateIDs, stateGameMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}