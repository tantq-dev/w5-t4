using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text currentPoint;
    public Text currentBalls;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPoint.text ="Point: "+ _gameManager.CurrentPoint.ToString();
        currentBalls.text ="Ball left: "+ _gameManager.CurrentCannonBalls.ToString();
    }
}
