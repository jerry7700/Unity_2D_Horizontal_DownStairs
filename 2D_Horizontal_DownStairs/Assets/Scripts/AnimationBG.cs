using UnityEngine;

public class AnimationBG : MonoBehaviour
{
    Material material;
    Vector2 movement;

    public Vector2 speed;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        movement += speed * Time.deltaTime;
        material.mainTextureOffset = movement;
    }
}
