using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem healthPickUp;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if(controller != null)
        {

            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                if (!healthPickUp.isPlaying) healthPickUp.Play();
                ParticleSystem pickUp = Instantiate(healthPickUp, transform.position, transform.rotation) as ParticleSystem;
                pickUp.Play();


                Destroy(pickUp.gameObject, healthPickUp.main.duration);
                Destroy(gameObject);
            }
        }
    }
}
