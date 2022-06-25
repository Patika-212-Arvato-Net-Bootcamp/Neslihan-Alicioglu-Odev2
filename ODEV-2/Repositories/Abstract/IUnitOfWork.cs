namespace ODEV_2.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        //Veritabanına yapılan işlemleri tek bir transaction üzerinden yapmamızı sağlayacak 
        //SaveChanges methodunu çağırılmadığı için repository de şu an yapılan işlemler memory de tutuluyor.
        //UnifOfWork sayesinde bu işlemler SaveChanges edilerek database e aktarılacak.
        //Bu sayede SaveChange ler beraber yapılacağı için içlerinden biri başarısız ise diğerleri de rollback yapılır.

        Task CommitAsync();//SaveChangeAsync
        void Commit();     //SaveChange methodları implemente edilecek
    }
}
