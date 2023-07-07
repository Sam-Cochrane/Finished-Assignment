using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AttackAbility : MonoBehaviour
{
    public Image icon;

    public float baseCastTime;
    public float castTime;
    public float baseLevel;
    public float level;
    public float maxLevel;
    private float timeUntilNextCast;
    public AudioClip soundEffect;
    private float volume = 1;

    public GameObject projectile;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
      
    }

    public void Instantiate()
    {
        Debug.Log("Awake ability");
        timeUntilNextCast = castTime;
        level = baseLevel;
        castTime = baseCastTime;
    }
    // Update is called once per frame
    public void Update()
    {
        timeUntilNextCast -= Time.deltaTime;
        if (timeUntilNextCast <= 0)
        {
            Attack(pos);
            timeUntilNextCast = castTime;
        }
    }

    public void Attack(Vector3 pos)
    {
        Instantiate(projectile, pos, Quaternion.Euler(0.0f, GenerateAttackAngle() , 0.0f));
        AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume);
    }

    public void LevelUp()
    {
        if(level < maxLevel)
        {
            level = level + 1;
            castTime = castTime * 0.8f;
        }
        
    }

    private float GenerateAttackAngle()
    {
        float angle = Random.Range(0, 360);

        return angle;
    }
}
