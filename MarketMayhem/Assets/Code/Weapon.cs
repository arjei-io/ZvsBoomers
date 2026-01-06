using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player; // Player position
    [SerializeField] private GameObject bulletPrefab; // Bullet object
    //[SerializeField] private Transform firePoint;

    [Header("Settings")]
    [SerializeField] private Vector2 fireOffset = new Vector2(0.6f, 0.6f); // Offset default
    [SerializeField] private float fireRate = 0.3f; // Time between bullets in seconds

    private Vector2 shootInput; // Direction of input
    private Coroutine shootingCoroutine;


    public void Shoot(InputAction.CallbackContext context)
    {

        shootInput = context.ReadValue<Vector2>();

        if (Time.timeScale == 0f)
        {
            return;
        }

        if (context.started && shootInput != Vector2.zero)
        {
            shootingCoroutine = StartCoroutine(FireSpam());
        }

        else if (context.canceled && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    private IEnumerator FireSpam()
    {
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(fireRate);
        }

    }

    private void SpawnBullet()
    {
        if (shootInput == Vector2.zero) return;

        Vector2 offset = Vector2.zero;


        // Check left/right
        if (shootInput.x > 0)
        {
            offset.x = fireOffset.x;
        }        
        else if (shootInput.x < 0)
        {
            offset.x = -fireOffset.x;
        }

        // Check up/down
        if (shootInput.y > 0)
        {
            offset.y = fireOffset.y;
        }
        else if (shootInput.y < 0)
        {
            offset.y = -fireOffset.y;
        }

        Vector2 spawnPos = (Vector2)player.position + offset;

        float angle = Mathf.Atan2(shootInput.y, shootInput.x) * Mathf.Rad2Deg;

        Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0, 0, angle));

    }

}




