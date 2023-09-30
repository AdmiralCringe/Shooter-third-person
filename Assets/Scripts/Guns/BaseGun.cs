using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseGun
{
   public int currentMagazineSize;
   
   public int magazineSize;
   protected float reloadTime;
   protected float nextFireTime;
   protected float fireRate;
   protected bool isRedyToShoot = true;
   protected bool isReloading;
   
   protected GameObject bulletPrefab;
   protected GameObject gunPrefab;
   protected Transform firePoint;
   
   private RaycastHit hit;
   public GameObject pointer;
   private float size = 0.01f;
   


   public BaseGun(int magazineSize, float reloadTime, float fireRate, GameObject bulletPrefab, GameObject gunPrefab)
   {
      this.magazineSize = magazineSize;
      this.fireRate = fireRate;
      this.reloadTime = reloadTime;
      this.bulletPrefab = bulletPrefab;
      firePoint = gunPrefab.transform.Find("firePoint");
      currentMagazineSize = this.magazineSize;
   }
   
   public void Start(GameObject pointer)
   {
      this.pointer = pointer;
   }
   
   public abstract void Shoot();

   public void ChangeAmmo(int val)
   {
      currentMagazineSize += val;
      if (currentMagazineSize <= 0)
      {
         Reload();
      }
   }
   public async void Reload()
   {
      if (currentMagazineSize < magazineSize && !isReloading)
      {
         isReloading = true;
         isRedyToShoot = false;
         
         await Task.Delay((int) (reloadTime * 1000));
         currentMagazineSize = magazineSize;
         
         isReloading = false;
         isRedyToShoot = true;
      }
   }
   // public void Aim()
   // {
   //   
   //    if (Physics.Raycast(firePoint.transform.position, firePoint.forward * 100f, out hit))
   //    {
   //       if (hit.collider.gameObject != null)
   //       {
   //          pointer.GetComponent<MeshRenderer>().enabled = true;
   //          pointer.transform.position = hit.point;
   //          float scale = Vector3.Distance(pointer.transform.position, firePoint.position);
   //          pointer.transform.localScale = Vector3.one * (size * scale);
   //       }
   //       else
   //       {
   //          pointer.GetComponent<MeshRenderer>().enabled = false;
   //       }
   //    }
   // }

   
   public void Update()
   {
      // Aim();
   }
}
