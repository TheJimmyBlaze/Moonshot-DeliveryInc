using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the turret, shooting, and animations associated with them.
/// </summary>
public class SpaceshipTurret : MonoBehaviour
{
    public GameObject Bullet;           //The bullet object the turret will spawn.
    public GameObject MuzzleFlash;      //The muzzle flash object that will spawn when shooting.
    public GameObject ShellCasing;      //The shell casing object that will be ejected from the turret after each shot.

    public float FireInterval = 5f;     //The time between shots.
    private float lastShot;             //The last time a bullet was shot.

    private Transform bulletParent;                 //This transform will parent the bullet stuff, this prevents the bullets from following the spaceship.
    private Transform flashParent;                  //This transform will parent muzzle flashes, this is just for cleanlyness.

    // Start is called before the first frame update
    void Start()
    {
        bulletParent = transform.parent.parent.Find("BulletObjects");
        flashParent = transform.Find("FlashObjects");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        Shoot();
    }

    // Shoot shoots bullets, derp.
    private void Shoot()
    {
        if (Input.GetAxis("Shooting") > 0)
        {
            if (Time.time > lastShot + FireInterval)
            {
                lastShot = Time.time;

                Vector3 bulletSpawnLocation = transform.Find("BulletSpawn").position;
                Vector3 shellCasingSpawnLocation = transform.Find("ShellCasingSpawn").position;

                Instantiate(Bullet, bulletSpawnLocation, Quaternion.identity, bulletParent);
                Instantiate(MuzzleFlash, bulletSpawnLocation, Quaternion.identity, flashParent);
                Instantiate(ShellCasing, shellCasingSpawnLocation, Quaternion.identity, bulletParent);

                AudioSource shotSound = transform.Find("ShotSound").GetComponent<AudioSource>();
                shotSound.Play();
            }
        }
    }
}
