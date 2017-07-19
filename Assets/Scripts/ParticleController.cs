using UnityEngine;
/* Copyright @ 2017 Daniel Cumbor */
public class ParticleController : MonoBehaviour
{
    // Variables
    public static ParticleController Instance;
    public ParticleSystem fallerEffect;
    public ParticleSystem moverEffect;
    public ParticleSystem playerRIP;

    void Awake()
    {
       Instance = this;
    }

    public void FallerExplosion(Vector3 position)
    {
        instantiate(fallerEffect, position);
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
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
        return newParticleSystem;
    }
}