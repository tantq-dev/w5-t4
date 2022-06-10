using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField]private int currentPoint;
    [SerializeField]private int currentCannonBalls;
    public int maxCannonBalls;
    [FormerlySerializedAs("goals")] public GameObject targets;
    [SerializeField]private bool canFire;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    private bool clearTarget;
  
    

    public bool ClearTarget => clearTarget;
    public int CurrentPoint
    {
        get => currentPoint;
        set => currentPoint = value;
    }

    public bool CanFire => canFire;
    
    public int CurrentCannonBalls
    {
        get => currentCannonBalls;
        set => currentCannonBalls = value;
    }
    void Start()
    {
        inGameUI.SetActive(true);
        gameOverUI.SetActive(false);
        currentCannonBalls = maxCannonBalls;
    }

    // Update is called once per frame
    void Update()
    {
        canFire = currentCannonBalls > 0;
        clearTarget = targets.transform.childCount == 0;
        GameOver();
    }
    
    void GameOver()
    {
        if (!canFire && !clearTarget)
        {
           
            gameOverUI.GetComponent<GameOverUI>().gameOverText.text = "GAME OVER";
            inGameUI.SetActive(false);
            gameOverUI.SetActive(true);
        }
        else if (clearTarget)
        {
            gameOverUI.GetComponent<GameOverUI>().gameOverText.text = "FINISH";
            inGameUI.SetActive(false);
            gameOverUI.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
