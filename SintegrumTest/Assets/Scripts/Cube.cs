using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed;
    public List<Material> materials;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private MeshRenderer _meshRenderer;
    private GameObject _bullet;

    private Material _standartMaterial;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _standartMaterial = _meshRenderer.material;
    }

    private void CubeMove(Vector3 dir)
    {
        _rigidbody.velocity = dir.normalized * speed;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CubeMove(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CubeMove(Vector3.back);
        }
        else
        {
            CubeMove(Vector3.zero);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            _bullet = other.gameObject;
            _bullet.GetComponent<MeshRenderer>().enabled = false;
            _meshRenderer.material = materials[Random.Range(0, materials.Count)];
            _animator.SetTrigger("IsCollision");
            EventAgregator.updateUI.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _meshRenderer.material = _standartMaterial;
        _bullet.GetComponent<MeshRenderer>().enabled = true;
    }
}
