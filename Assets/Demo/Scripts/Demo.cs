using System.Collections;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private bool _canShootMany = true;
    private Transform _weaponTransform = null;

    [SerializeField]
    private GameObject _weaponPrefab = null;
    [SerializeField]
    private GameObject _projectile = null;
    [SerializeField]
    private float _fireRate = 0.1f;

    private void Start()
    {
        var player = GameObject.FindWithTag("Player");
        player.AddComponent<Player>();

        var camTransform = Camera.main.transform;

        var weapon = Instantiate(_weaponPrefab, camTransform);
        _weaponTransform = weapon.GetComponent<Transform>();
        _weaponTransform.localPosition = new Vector3(0.3f, -0.22f, 0.4f);
    }

    private void Update()
    {
        if (Input.GetButton("Fire2") && _canShootMany)
            StartCoroutine(ShootMany());

        else if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private IEnumerator ShootMany()
    {
        _canShootMany = false;

        Shoot();

        yield return new WaitForSeconds(_fireRate);

        _canShootMany = true;
    }

    private void Shoot()
    {
        var sphere = Instantiate(_projectile);
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.transform.position = _weaponTransform.position;
        sphere.transform.rotation = _weaponTransform.rotation;
        sphere.transform.Translate(0, 0, 1);

        var rb = sphere.GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, 25, ForceMode.Impulse);
    }
}
