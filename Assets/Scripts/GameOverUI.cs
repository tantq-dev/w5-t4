using UnityEngine;
using UnityEngine.UI;
public class GameOverUI : MonoBehaviour
{
    public Text gameOverText;
    public Text finalPoint;
    public Text currentPoint;
    public Text ballLeft;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_gameManager.CanFire || _gameManager.ClearTarget)
        {
            UpdateFinalPoint();
        }
    }

    private void UpdateFinalPoint()
    {
        int point = _gameManager.CurrentPoint;
        int balls = _gameManager.CurrentCannonBalls;
        int final = balls * 10 + point;
        currentPoint.text ="Point: "+ point.ToString();
        ballLeft.text ="Ball left: "+ balls.ToString();
        finalPoint.text = "Final Point: " + final.ToString() +" ( Bonus: "+balls*10 +" )";
    }
}
