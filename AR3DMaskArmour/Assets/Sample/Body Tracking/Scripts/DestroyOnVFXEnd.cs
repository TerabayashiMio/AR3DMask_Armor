using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class DestroyOnVFXEnd : MonoBehaviour
{
    private VisualEffect vfx;

    void Awake()
    {
        vfx = GetComponent<VisualEffect>();
    }

    void Update()
    {
        // パーティクルがすべて消え、かつ停止している場合
        if (vfx.aliveParticleCount == 0 && !vfx.HasAnySystemAwake())
        {
            Destroy(gameObject);
        }
    }
}
