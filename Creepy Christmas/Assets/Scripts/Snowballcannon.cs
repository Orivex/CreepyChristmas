using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowballcannon : Item
{
    [SerializeField] GameObject snowballPrefab;
    [SerializeField] Transform shootPos;
    [SerializeField] float snowballSpeed;
    [SerializeField] float fireRate;
    [SerializeField] float nextShot;

    [SerializeField] Transform drum;
    [SerializeField] float nextRotation;
    [SerializeField] float rotateSpeed;

    [SerializeField] Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isEquiped == true && nextShot <= 0f)
            Use();
        else if(nextShot > 0f)
            nextShot -= Time.deltaTime;
    }

    public override void Use()
    {
        base.Use();
        Shoot();
    }

    void Shoot()
    {
        animator.SetTrigger("shoot");
        GameObject snowball = Instantiate(snowballPrefab, shootPos.position, Quaternion.identity);
        Rigidbody rb = snowball.GetComponent<Rigidbody>();
        rb.AddForce(shootPos.forward * snowballSpeed);

        nextShot = fireRate;

        nextRotation += 90f;
    }
}
