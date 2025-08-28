using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    [SerializeField]GameObject touchEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if(touchEffectPrefab != null && other.CompareTag("Touch"))
        {

            Instantiate(touchEffectPrefab, other.ClosestPoint(transform.position), Quaternion.identity);
            Debug.Log("TouchEffect instantiated at " + other.ClosestPoint(transform.position));
        }
    }
}
