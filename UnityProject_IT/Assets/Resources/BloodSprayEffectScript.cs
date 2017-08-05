using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSprayEffectScript : MonoBehaviour 
{
    private static BloodSprayEffectScript instance;
    public ParticleSystem explosionEffect;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () 
    {
         if (explosionEffect == null)
      Debug.LogError("Missing Explosion Effect!");
		
	}
    public static ParticleSystem MakeExplosion(Vector3 position)
    {
        if (instance == null)
        {
            Debug.LogError("There is no SpecialEffectsScript in the scene!");
            return null;
        }

        ParticleSystem effect = Instantiate(instance.explosionEffect) as ParticleSystem;
        effect.transform.position = position;

        // Program destruction at the end of the effect
        Destroy(effect.gameObject, effect.duration);

        return effect;
    }
}
