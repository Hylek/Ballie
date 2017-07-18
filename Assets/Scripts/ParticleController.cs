using UnityEngine;

public class ParticleController : MonoBehaviour
{

    public static ParticleController Instance;

    public ParticleSystem smokeEffect;
    public ParticleSystem moverEffect;
    public ParticleSystem playerRIP;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }
       Instance = this;
    }

    public void Explosion(Vector3 position)
    {
        instantiate(smokeEffect, position);
    }
    public void MoverExplosion(Vector3 position)
    {
        instantiate(moverEffect, position);
    }
    public void PlayerDeath(Vector3 position)
    {
        instantiate(playerRIP, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        return newParticleSystem;
    }
}