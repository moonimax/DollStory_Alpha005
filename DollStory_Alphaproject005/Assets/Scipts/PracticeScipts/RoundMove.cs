using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundMove : MonoBehaviour
{
    Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    //public Transform Projectile;
    //private Transform myTransform;

    Vector3 nextpos;

    bool forward;
    void Awake()
    {
        //yTransform = GetComponentInParent<Transform>().transform;
    }

    void Start()
    {

    }

    private void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            forward = true;
        
        }
        if(forward == true)
        {
            StartCoroutine(SimulateProjectile());
            forward = false;

        }

    }

    IEnumerator SimulateProjectile()
    {
            nextpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3f);
        // Short delay added before Projectile is thrown
        //yield return new WaitForSeconds(0.2f);

        // Move projectile to the position of throwing object + add some offset if needed.
       // Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(transform.position, nextpos);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // 날아가는 시간.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        transform.rotation = Quaternion.LookRotation(nextpos - transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}

