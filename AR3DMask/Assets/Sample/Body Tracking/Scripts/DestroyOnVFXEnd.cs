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
        // �p�[�e�B�N�������ׂď����A����~���Ă���ꍇ
        if (vfx.aliveParticleCount == 0 && !vfx.HasAnySystemAwake())
        {
            Destroy(gameObject);
        }
    }
}
