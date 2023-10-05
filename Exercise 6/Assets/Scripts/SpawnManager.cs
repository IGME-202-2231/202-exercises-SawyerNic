using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    SpriteRenderer animalPrefab;

    [SerializeField]
    List<Sprite> animalSprites = new List<Sprite>();

    List<SpriteRenderer> animals = new List<SpriteRenderer>();

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // Start is called before the first frame update
    void Start()
    {
        animalPrefab.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private SpriteRenderer SpawnAnimal()
    {
        return Instantiate(animalPrefab, transform);
    }

    public void Spawn()
    {
        DestroyAnimals();

        //Exercise: spawn in a random number of animals
        for(int i = 0; i < animalSprites.Count; i++)
        {
            animals.Add(SpawnAnimal());

            //Exercise: spawn in gaussian distributed points
            Vector2 newPosition = new Vector2(
                Random.Range(-5, 5), Random.Range(-4, 4)
            );

            animals[i].transform.position = newPosition;


            //color randomization\
            animals[i].color = Random.ColorHSV(0,1,1,1,1,1);

            
            float randValue = Random.value;
            if (randValue < .5f) { animals[i].sprite = animalSprites[1]; }
            else if(randValue < .7f) { animals[i].sprite = animalSprites[2]; }
            else { animals[i].sprite = animalSprites[3]; }

        }
    }

    private void DestroyAnimals()
    {
        foreach(SpriteRenderer animal in animals)
        {
            Destroy(animal.gameObject);
        }
        
        animals.Clear();
    }
}
