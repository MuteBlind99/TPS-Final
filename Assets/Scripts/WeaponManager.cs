using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] float fireRate;
    float _fireRateTimer;
    [SerializeField] bool semiAutomatic;
    private Coroutine _coroutine;
    bool _canshoot = true;
    [SerializeField] Transform aimPosition;
    [SerializeField] private float aimSmoothSpeed = 10f;
    [SerializeField] LayerMask aimLayer;
    [SerializeField] private float damageRate = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenCenter = new Vector3(0.5f, 0.5f, Camera.main.farClipPlane);
        Ray ray = Camera.main.ViewportPointToRay(screenCenter);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimLayer))
        {
            aimPosition.position = Vector3.Lerp(aimPosition.position, hit.point, aimSmoothSpeed * Time.deltaTime);
            //aimPosition.position = hit.point;
        }

        if (Input.GetMouseButton(1))
        {
            if (_canshoot)
            {
                if (hit.collider.TryGetComponent(out Target target))
                {
                    target.TakeDamage(damageRate);
                }

                _canshoot = false;
                
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine("Fire");
            }
        }

        _fireRateTimer -= Time.deltaTime;
        // if (ShouldFire())
        // {
        //     Fire();
        // }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(fireRate);
        _canshoot = true;
    }

    // bool ShouldFire()
    // {
    //     if (_fireRateTimer < fireRate) return false;
    //     if (semiAutomatic && Input.GetMouseButtonDown(0)) return true;
    //     if (!semiAutomatic && Input.GetMouseButton(0)) return true;
    //     return false;
    // }

    // void Fire()
    // {
    //     _fireRateTimer = 0;
    //     Debug.Log("Fire");
    // }
}