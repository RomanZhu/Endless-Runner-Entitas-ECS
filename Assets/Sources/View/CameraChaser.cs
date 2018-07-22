using UnityEngine;

public class CameraChaser : MonoBehaviour
{
	public Vector3 Offset;
	public Vector3 LookOffset;
	public Vector3 LookNoise;

	public float MoveSpeed = 10f;
	public float RotationSpeed = 10f;
	public float NoiseChangeDelay = 10f;

	[SerializeField]
	private Transform _target;
	private Transform _transform;
	private Vector3 _lookNoise;

	private float _nextNoiseChange;

	private void Start()
	{
		_transform = transform;
	}

	private void FixedUpdate ()
	{
		if (Time.realtimeSinceStartup > _nextNoiseChange)
		{
			_nextNoiseChange = Time.realtimeSinceStartup + NoiseChangeDelay;
			_lookNoise = new Vector3(Random.Range(-LookNoise.x, LookNoise.x),Random.Range(-LookNoise.y, LookNoise.y),Random.Range(-LookNoise.z, LookNoise.z));
		}
		
		if (Vector3.Distance(_transform.position, _target.position + Offset) < 10f)
		{
			_transform.position = Vector3.Lerp(_transform.position, _target.position + Offset + _lookNoise, MoveSpeed * Time.fixedDeltaTime);
		}
		else
		{
			_transform.position = _target.position + Offset;
		}
		
		_transform.rotation = Quaternion.Slerp(_transform.rotation,
			Quaternion.LookRotation(_target.position + LookOffset - _transform.position, Vector3.up),
			RotationSpeed * Time.fixedDeltaTime);
	}
}
