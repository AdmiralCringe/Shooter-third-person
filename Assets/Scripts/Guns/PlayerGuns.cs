using TMPro;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform gunPoint;
    [SerializeField] private GunParams pistol;
    [SerializeField] private GunParams automat;
    [SerializeField] private GameObject pointer;
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI ammoCount;


    private GameObject currentGun;
    private BaseGun _baseGun;
    void Start()
    {
        currentGun = Instantiate(gunPrefab, gunPoint.position, gunPoint.transform.rotation, gunPoint.transform);
        _baseGun = new Pistol(pistol.magazineSize, pistol.reloadTime,pistol.fireRate , pistol.bulletPrefab, currentGun);
        // _baseGun.Start(pointer);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _baseGun.currentMagazineSize > 0)
        {
            _baseGun.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _baseGun.Reload();
        }
        _baseGun.Update();
        ChangeGun();
    }

    private void ChangeGun()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(currentGun);
            currentGun = Instantiate( pistol.gunPrefab, gunPoint.position, gunPoint.transform.rotation, gunPoint.transform);
            _baseGun = new Pistol(pistol.magazineSize, pistol.reloadTime,pistol.fireRate , pistol.bulletPrefab, currentGun);
            FindObjectOfType<SoundManager>().Play("SwipePistol");
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGun);
            currentGun = Instantiate( automat.gunPrefab, gunPoint.position, gunPoint.transform.rotation, gunPoint.transform);
            _baseGun = new AutomaticGun(automat.magazineSize, automat.reloadTime,automat.fireRate , automat.bulletPrefab, currentGun);
            FindObjectOfType<SoundManager>().Play("SwipeAutomat");
            animator.SetLayerWeight(2, 1);
            animator.SetLayerWeight(1, 0);
        }
        ammoCount.text = _baseGun.currentMagazineSize + " / " + _baseGun.magazineSize;
    }
}
