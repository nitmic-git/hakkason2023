using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitMane : MonoBehaviour
{
    [SerializeField] float speed;
    
    [SerializeField] GameObject unit;
    [SerializeField] GameObject ground;
    [SerializeField] stageMane stageMane;
    [SerializeField] Image hpBar;
    [SerializeField] Image mpBar;
    [SerializeField] float maxMp = 30;
    [SerializeField] float addMpInterval=2;

    public Animator animator; // InspectorでAnimatorをアサインする
    public string targetAnimationName = "YourAnimationClipName";

    private int section=0;
    private Vector3 direction;
    private bool end = false;
    private int oldSection;
    private int maxHp;
    private int mp=0;

    private void Start()
    {
        maxHp = GameMane.playerHp;
        mpBar.fillAmount = 0;
        unit.transform.position = stageMane.path[0];
        StartCoroutine(AddMp());
    }

    private void Update()
    {
        Debug.Log(GameMane.playerHp);
        BarMane();
        //groundGene();
        if (stageMane.path[section].x<=unit.transform.position.x&&section< stageMane.path.Length-1)
        {
            section++;
            
        }

        if (stageMane.path[stageMane.path.Length - 1].x < unit.transform.position.x&&!end)
        {
            end = true;
            Debug.Log("道中終了");
        }

        if (!end)
        {
           
            direction = (stageMane.path[section] - stageMane.path[section - 1]).normalized;

            unit.transform.position += direction * speed*GameMane.playerSpeed/10*Time.deltaTime;
        }

        
        if(section!=oldSection)
        {
            

            Vector3 lookDirection = stageMane.path[section]- stageMane.path[section - 1];
           

            // 方向ベクトルから角度を計算
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // Z軸を使って回転を適用
            unit.transform.rotation = Quaternion.Euler(0, 0, angle);
           
            oldSection = section;
        }

        if (animator != null)
        {
            // アニメーションクリップの速度を変更
            animator.speed = GameMane.playerSpeed/10f;

            
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            GameMane.playerSpeed++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameMane.playerSpeed--;
        }

    }

    public void BarMane()
    {
        hpBar.fillAmount = (float)GameMane.playerHp / (float)maxHp;
        mpBar.fillAmount = (float)mp / (float)maxMp;
    }

    public IEnumerator  AddMp()
    {
        while (true)
        {


            yield return new WaitForSeconds(addMpInterval);
            if(mp<=maxMp-1)
            {
                mp++;
            }
            
           
        }
    }

    public void groundGene()
    {
        SpriteRenderer sp = ground.GetComponent<SpriteRenderer>();
        if(Input.GetMouseButton(0))
        {
            ground.transform.localScale = new Vector3(2, 1, 1);
        }
    }
}
