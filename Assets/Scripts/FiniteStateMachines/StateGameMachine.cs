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

public class GameLoop : GameState
{
    GameObject UIGameCanvas;

    public GameLoop(int stateIDs, StateGameMachine stateGameMachine, GameObject uIGameCanvas) : base(stateIDs, stateGameMachine)
    {
        UIGameCanvas = uIGameCanvas;
    }

    public override void Enter()
    {
        base.Enter();
        UIGameCanvas.SetActive(true);
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

public class LevelUp : GameState
{
    GameObject LevelUpCanvas;
    GameObject UIGameCanvas;

    public LevelUp(int stateIDs, StateGameMachine stateGameMachine, GameObject levelUpCanvas, GameObject uIgameCanvas) : base(stateIDs, stateGameMachine)
    {
        LevelUpCanvas = levelUpCanvas;
        UIGameCanvas = uIgameCanvas;
    }

    public override void Enter()
    {
        base.Enter();
        UIGameCanvas.SetActive(false);
        LevelUpCanvas.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        UIGameCanvas.SetActive(true);
        LevelUpCanvas.SetActive(false);
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

public class PauseGame : GameState
{
    readonly protected string MENU_SCENE_NAME = "GameMenu";
    GameObject PauseCanvas;
    GameObject UIGameCanvas;

    public PauseGame(int stateIDs, StateGameMachine stateGameMachine, GameObject pauseCanvas, GameObject uIgameCanvas) : base(stateIDs, stateGameMachine)
    {
        PauseCanvas = pauseCanvas;
        UIGameCanvas = uIgameCanvas;
    }

    public override void Enter()
    {
        base.Enter();
        PauseCanvas.SetActive(true);
        UIGameCanvas.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
        PauseCanvas.SetActive(false);
        UIGameCanvas.SetActive(true);
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

public class EndGame : GameState
{
    readonly protected string MENU_SCENE_NAME = "GameMenu";
    GameObject EndGameCanvas;
    GameObject UIGameCanvas;

    public EndGame(int stateIDs, StateGameMachine stateGameMachine, GameObject endGameCanvas, GameObject uIGameCanvas) : base(stateIDs, stateGameMachine)
    {
        EndGameCanvas = endGameCanvas;
        UIGameCanvas = uIGameCanvas;
    }

    public override void Enter()
    {
        base.Enter();
        EndGameCanvas.SetActive(true);
        UIGameCanvas.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
        EndGameCanvas.SetActive(false);
        UIGameCanvas.SetActive(true);
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
