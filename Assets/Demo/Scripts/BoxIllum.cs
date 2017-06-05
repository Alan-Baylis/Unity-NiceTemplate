using System.Collections;
using UnityEngine;

public class BoxIllum : MonoBehaviour
{
    private bool _locked = false;

    [SerializeField]
    private Material[] _illumMaterials = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_locked && collision.collider.tag == "Sphere")
            StartCoroutine(ToggleIllum());
    }

    private IEnumerator ToggleIllum()
    {
        _locked = true;
        var renderer = GetComponent<Renderer>();
        var stock = renderer.material;
        renderer.material = _illumMaterials[Random.Range(0, _illumMaterials.Length)];
        yield return new WaitForSeconds(2.5f);
        renderer.material = stock;
        _locked = false;
    }
}
