using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInput : MonoBehaviour
{
    private AudioSource iAS;
    public AudioClip[] burpClips;
    public AudioClip jumplClip;
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        iAS = GetComponentInChildren<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (rb.velocity.y > -0.3 && rb.velocity.y < 0.3)
            {
                iAS.PlayOneShot(jumplClip);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            iAS.PlayOneShot(burpClips[UnityEngine.Random.Range(0, burpClips.Length)]);
        }
    }
}
