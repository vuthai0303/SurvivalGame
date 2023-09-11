using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public Vector3 playerInitPosition = new Vector3();
    public bool isLoading = false;

    StateGameMachine mGameState = new StateGameMachine();
    public GameObject mUICanvas;
    public GameObject mPauseCanvas;
    public GameObject mLevelUpCanvas;
    public GameObject mEndGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameState GameLoop = new GameLoop((int)GameStateIds.GameLoop, mGameState, mUICanvas);
        GameState PauseGame = new PauseGame((int)GameStateIds.PauseGame, mGameState, mPauseCanvas, mUICanvas);
        GameState LevelUp = new LevelUp((int)GameStateIds.LevelUp, mGameState, mLevelUpCanvas, mUICanvas);
        GameState EndGame = new EndGame((int)GameStateIds.EndGame, mGameState, mEndGameCanvas, mUICanvas);
        mGameState.addState((int)GameStateIds.GameLoop ,GameLoop);
        mGameState.addState((int)GameStateIds.PauseGame, PauseGame);
        mGameState.addState((int)GameStateIds.LevelUp, LevelUp);
        mGameState.addState((int)GameStateIds.EndGame, EndGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoading) return;
        Time.timeScale = 0f;
        GameManager GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if(GameManager)
        {
            isLoading = true;
            GameObject Config = GameObject.FindGameObjectWithTag("Config");
            Instantiate(Config.GetComponent<GameResource>().getPlayerPrefab(GameManager.playerIds), playerInitPosition, Quaternion.identity);
            mGameState.setCurrentState(mGameState.getState((int)GameStateIds.GameLoop));
            Time.timeScale = 1f;
        }
    }

    public void onBackHome()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void onEndGame() 
    {
        Time.timeScale = 0f;
        mGameState.setCurrentState(mGameState.getState((int)GameStateIds.EndGame));
    }

    public void onLevelUp()
    {
        Time.timeScale = 0f;
        mGameState.setCurrentState(mGameState.getState((int)GameStateIds.LevelUp));
    }

    public void onClickPauseBtn()
    {
        Time.timeScale = 0f;
        mGameState.setCurrentState(mGameState.getState((int)GameStateIds.PauseGame));
    }

    public void onClickResumeBtn()
    {
        Time.timeScale = 1.0f;
        mGameState.setCurrentState(mGameState.getState((int)GameStateIds.GameLoop));
    }
}
