using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviorScript : MonoBehaviour
{
    private float lifeTime = 3;

    private float explosionForce = 300f;
    public Rigidbody rb;

    private float radius = 2.0F;
    private float throwPower = 5F;

    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitForTime(lifeTime));
        Explosion = transform.GetChild(1).gameObject;
        rb.AddForce(transform.forward * throwPower, ForceMode.Impulse);

    }
    IEnumerator WaitForTime(float time)
    {
        yield return new WaitForSeconds(time);
        Explode(explosionForce);
        Explosion.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    void Explode(float explosionForce)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionForce, explosionPos, radius, 1.0F);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
