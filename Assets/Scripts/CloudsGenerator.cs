using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsGenerator : MonoBehaviour
{

    [Header("Set in Inspector")]
    public List<GameObject> cloudPrefabs;
    public int numCloudsMin = 6;
    public int numCloudsMax = 10;
    public float scaleMin = 0.5f;
    public float scaleMax = 2f;
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public Vector3 cloudPosMin = new Vector3(-50,-5,10);
    public Vector3 cloudPosMax = new Vector3(150,100,10);
    public float cloudSpeedMult = 0.5f;

    private List<GameObject> clouds;

    // Start is called before the first frame update
    void Start()
    {
        clouds = new List<GameObject>();
        int num = Random.Range(numCloudsMin, numCloudsMax); // c
        for (int i = 0; i < num; i++)
        {
            GameObject cloud = Instantiate<GameObject>(cloudPrefabs[Random.Range(0, cloudPrefabs.Count)]);
            clouds.Add(cloud);
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(scaleMin, scaleMax, scaleU);
            // Меньшие облака (с меньшим значением scaleU) должны быть ближе
            // к земле
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);
            // Меньшие облака должны быть дальше
            cPos.z = 100 - 90 * scaleU;
            // Применить полученные значения координат и масштаба к облаку
            cloud.transform.position = cPos;
            cloud.transform.localScale = Vector3.one * scaleVal;
        }
     }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            // Получить масштаб и координаты облака
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            // Увеличить скорость для ближних облаков
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
            // Если облако сместилось слишком далеко влево...
            if (cPos.x <= cloudPosMin.x)
            {
                // Переместить его далеко вправо
                cPos.x = cloudPosMax.x;
            }
            // Применить новые координаты к облаку
            cloud.transform.position = cPos;
        }
    }

    void Restart()
    {
        // Удалить старые сферы, составляющие облако
        foreach (GameObject sp in clouds)
        {
        Destroy(sp);
        }
        Start();
    }
}
