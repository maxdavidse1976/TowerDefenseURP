using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] Vector3 _rotationVector;
    [SerializeField] float _rotationSpeed;

    void Update()
    {
        float newRotationSpeed = _rotationSpeed * 100;
        transform.Rotate(_rotationVector * newRotationSpeed * Time.deltaTime);
    }

}
