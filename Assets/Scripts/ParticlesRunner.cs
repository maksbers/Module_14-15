using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesRunner : MonoBehaviour
{
    public void RunParticles(ParticleSystem particles, Transform transform)
    {
        ParticleSystem particlesInstance = Instantiate(particles, transform.position, transform.rotation);
        particlesInstance.Play();
    }

    public void RunParticles(ParticleSystem particles, Vector3 position)
    {
        ParticleSystem particlesInstance = Instantiate(particles, position, Quaternion.identity);
        particlesInstance.Play();
    }
}
