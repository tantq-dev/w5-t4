using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    public int point;
    public Text textPoint;
    private GameManager _gameManager;

    void Start()
    {
        textPoint.text = point.ToString();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Debug.Log("Hit");
            HitByCannonBall();
        }
    }


    void HitByCannonBall()
    {
        _gameManager.CurrentPoint += point;
        Debug.Log("Hit cannon ball");
        Destroy(gameObject);
    }
}
