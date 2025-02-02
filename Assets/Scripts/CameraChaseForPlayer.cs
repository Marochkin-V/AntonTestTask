using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChaseForPlayer : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1.5f;
    [SerializeField] private float distance = 4f;
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 8;
    [SerializeField] private float height = 4f;

    private float rotationY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Вращение камеры вокруг игрока
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        player.Rotate(Vector3.up, mouseX); // Синхронизация поворота игрока с вращением камеры
        transform.RotateAround(player.position, Vector3.up, mouseX);

        // Поворот камеры по оси Y
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -45, 45);
        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0); // Инвертируем rotationY

        // Определяем точку на указанной дистанции от игрока
        Vector3 position = player.position - transform.forward * distance;
        position = new Vector3(position.x, player.position.y + height, position.z); // Корректировка высоты

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}