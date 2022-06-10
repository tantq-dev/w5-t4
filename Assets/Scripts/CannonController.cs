using UnityEngine;
using UnityEngine.Serialization;

public class CannonController : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Transform cannonBody;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject cannonBall;
    public float maxPower;
    public float currentPower;
    private GameManager _gameManager;
    private void Start()
    {
        _cam = Camera.main;
        currentPower = 0;
        -_gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        LookAtTarget();
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            GetPower();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            Debug.Log(currentPower);
            FireCannonBall();
        }
    }

    private void LookAtTarget()
    {
        Ray mouseRay = _cam.ScreenPointToRay(Input.mousePosition);
        float midPoint = (-cannonBody.transform.position - _cam.transform.position).magnitude * 0.5f;
        transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);
    }

    private void GetPower()
    {
        if (currentPower < maxPower)
        {
            currentPower += 5 * Time.deltaTime;
        }
    }

    private void FireCannonBall()
    {
        
        var newCannonBall = Instantiate(cannonBall, firePoint.position, Quaternion.identity);
        newCannonBall.GetComponent<Rigidbody>().AddForce(firePoint.up * currentPower, ForceMode.Impulse);
        currentPower = 0;
        
    }
}