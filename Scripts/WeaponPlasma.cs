using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlasma : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] typePlasma;
    public int powerWeapon = 1;
    public GameObject spawnPoint;
    private float timeBtwShots;
    public float deltaTime = 0.3f;
    public float speed = 10f;
    public float deltaX = 10f;
    
    //int i = 1;
    //private int[,] matrixWeapon = new int[3, 3] { { 0, 1, 2 }, { 3, 4,5 }, { 3, 4, 5 } };
    private int[,] matrixWeapon = new int[15, 5] {
        { 0,0,1,0,0 },
        { 0,0,2,0,0 },
        { 0,0,3,0,0 },
        { 0,1,2,1,0 },
        { 0,1,3,1,0 },
        { 0,2,2,2,0 },
        { 0,2,3,2,0 },
        { 1,2,2,2,1 },
        { 1,2,3,2,1 },
        { 1,3,2,3,1 },
        { 1,3,3,3,1 },
        { 2,3,2,3,2 },
        { 2,3,3,3,2 },
        { 3,3,2,3,3 },
        { 3,3,3,3,3 },
    };


  
    public void setPowerWeapon(int p) // положительное добавит отрицательное убавит
    {
        if (powerWeapon > 0 && p < 0)
            powerWeapon += p;
        else if (powerWeapon < 15 && p > 0)
            powerWeapon += p;
    }

    void Update()
    {
        //if (weaponActiv)
            if (timeBtwShots <= 0 && Input.GetButton("Fire1"))
            {
                //weaponBullet.whoShot = "Player";          
                timeBtwShots = deltaTime;
                GenerationBullet();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

    }


    public void GenerationBullet()
    {

        for (int i = 0; i < 5; i++)
        {

            if (matrixWeapon[powerWeapon, i] > 0)
            {
                float j = (i - 2) / deltaX; //данная хрень нужна лдля смещения выстрела от центра. пока лучше данного костыля не придумал
                //позиция появления 
                Vector3 bulletPosition = spawnPoint.transform.position;

                float x = spawnPoint.transform.position.x + j - transform.position.x;
                float y = spawnPoint.transform.position.y - transform.position.y;

                Vector2 bulletForce = new Vector2(x, y);
                //из i вычтем 1 потому что массив typePlasma начинаетьтся от нуля, и матрица matrixWeapon от нуля. в итоге чтобы при нуле 
                //не происходил выстрел из значения выше была проверка i > 0. А при выстреле брался typeWeapon -1;
                //а видеть в матрицеОружия отрицательные значения мне неохота
                //темболее там int
                GameObject createBullet = Instantiate(typePlasma[matrixWeapon[powerWeapon, i] - 1], bulletPosition, transform.rotation) as GameObject;
                createBullet.GetComponent<Rigidbody2D>().AddForce(bulletForce * speed, ForceMode2D.Impulse);
                //делает объект дочерним стреляющего и перемещаем на его Layer
                //createBullet.transform.SetParent(gameObject.transform); ///отключил так как при смене оружия онор становится не активным и пули вместе с ним
                createBullet.layer = gameObject.layer;
              
            }
        }

    }

}
