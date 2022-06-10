using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Transform cannonBody;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject cannonBall;
    public float maxForce;
    public float currentForce;
    private GameManager _gameManager;
    public Slider forceBar;

    private void Start()
    {
        _cam = Camera.main;
        currentForce = 0;
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        forceBar.maxValue = maxForce;
        forceBar.minValue = 0;
    }

    private void Update()
    {
        forceBar.value = currentForce;
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            GetPower();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            Debug.Log(currentForce);
            FireCannonBall();
        }
    }

    private void FixedUpdate()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        Ray mouseRay = _cam.ScreenPointToRay(Input.mousePosition);
        float midPoint = (-cannonBody.transform.position - _cam.transform.position).magnitude * 0.5f;
        transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);
    }

    private void GetPower()
    {
        if (currentForce < maxForce)
        {
            currentForce += 5 * Time.deltaTime;
        }
    }

    private void FireCannonBall()
    {
        if (_gameManager.CanFire)
        {
            var newCannonBall = Instantiate(cannonBall, firePoint.position, Quaternion.identity);
            newCannonBall.GetComponent<Rigidbody>().AddForce(firePoint.up * currentForce, ForceMode.Impulse);
            currentForce = 0;
            _gameManager.CurrentCannonBalls--;
        }
    }
}