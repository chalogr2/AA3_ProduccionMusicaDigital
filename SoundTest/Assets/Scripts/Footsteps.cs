using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip[] mudClips;
    [SerializeField]
    private AudioClip[] grassClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        switch (terrainTextureIndex)
        {
            case 3:
                return stoneClips[UnityEngine.Random.Range(0, stoneClips.Length)];
            case 2:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 1:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 0:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];

            default:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
        }

    }
}