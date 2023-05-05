using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGraveSkin : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Sprite[] skins;
    public int GraveSkin;


    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSkin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSkin()
    {
        GraveSkin = Random.Range(0, 4);

        if (GraveSkin < skins.Length)
        {
            spriteRenderer.sprite = skins[GraveSkin];
        }
    }
}
