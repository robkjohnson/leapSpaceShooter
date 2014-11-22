using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundry boundry;
	public float tilt;

    public float moveHorizontal;
    public float moveVertical;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

    void Awake ()
    {
        
    }

	void Update()
	{
        if (GameObject.Find("palm"))
        {
            if ((GameObject.Find("palm").transform.rotation.x > .2) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                audio.Play();
            }
        }
        else
        {
            if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                audio.Play();
            }
        }
	}

	void FixedUpdate()
	{

        if (GameObject.Find("palm"))
        {
            moveHorizontal = GameObject.Find("palm").transform.position.x;
            moveVertical = GameObject.Find("palm").transform.position.z;
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundry.xMin, boundry.xMax),
				0.0f,
				Mathf.Clamp (rigidbody.position.z, boundry.zMin, boundry.zMax)
			);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
