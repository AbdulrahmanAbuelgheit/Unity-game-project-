using UnityEngine;

public class Attack : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public LayerMask CollisionLayer;
    public float radius = 1f;
    public float damage = 2f;
    public bool is_Player, is_Enemy;
    public GameObject hit_FX_Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit=Physics.OverlapSphere(transform.position,radius,CollisionLayer);
         if(hit.Length > 0)
        {
            if (is_Player)
            {
                Vector3 hitFX_Pos = hit[0].transform.position;
               hitFX_Pos.y += 1.3f;
               if (hit[0].transform.forward.x > 0)
                {
                   hitFX_Pos.x += 0.3f;
                }else if (hit[0].transform .forward.x < 0)
               {
                   hitFX_Pos.x -= 0.3f;
                }
                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);
                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG)
                ||gameObject.CompareTag(Tags.LEFT_LEG_TAG)){
                  hit[0].GetComponent<HealthScript>().ApplyDamage(damage,true);
                }
                else {
                  hit[0].GetComponent<HealthScript>().ApplyDamage(damage,false);
                }
            }
            if(is_Enemy){
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage,false);
            }
           gameObject.SetActive(false);
            // print("we hit The" + hit[0].gameObject.name);
        }
    }
}
