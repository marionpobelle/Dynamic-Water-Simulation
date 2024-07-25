using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterObject : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] float _depthBeforeSubmerged = 1f;
    [SerializeField] float _displacementAmount = 3f;
    [SerializeField] int _floaterCount = 1;
    [SerializeField] float _waterDrag = 0.99f;
    [SerializeField] float _waterAngularDrag = 0.5f;

    private void FixedUpdate()
    {
        _rigidbody.AddForceAtPosition(Physics.gravity / _floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveHandler.Instance.GetWaveHeight(transform.position.x);
        if(transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / _depthBeforeSubmerged) * _displacementAmount;
            _rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            _rigidbody.AddForce(displacementMultiplier * -_rigidbody.velocity * _waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            _rigidbody.AddTorque(displacementMultiplier * -_rigidbody.angularVelocity * _waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }
    }
}
