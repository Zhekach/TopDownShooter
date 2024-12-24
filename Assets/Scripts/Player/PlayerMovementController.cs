using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float movementSpeed = 5f; // Скорость перемещения персонажа

        private Rigidbody2D _rigidbody;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            if (_rigidbody == null)
            {
                Debug.LogError("PlayerController: Rigidbody2D не найден на объекте.");
            }
        }

        void Update()
        {
            // Обработка поворота персонажа в сторону курсора мыши
            RotateTowardsMouse();
        }

        void FixedUpdate()
        {
            // Обработка перемещения персонажа
            MoveCharacter();
        }

        // Метод для перемещения персонажа
        private void MoveCharacter()
        {
            // Получаем ввод от пользователя по осям (WASD или стрелки)
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Создаем вектор движения на основе ввода
            Vector2 movement = new Vector2(horizontal, vertical).normalized;

            // Применяем движение к Rigidbody2D
            _rigidbody.linearVelocity = movement * movementSpeed;
        }

        // Метод для поворота персонажа в сторону курсора мыши
        private void RotateTowardsMouse()
        {
            // Получаем позицию мыши в мировых координатах
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Вычисляем направление от персонажа к мыши
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Вычисляем угол поворота персонажа
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Устанавливаем угол поворота для персонажа
            _rigidbody.rotation = angle;
        }
    }
}
