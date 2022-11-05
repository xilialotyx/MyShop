namespace ShopManagement.Domain.Services
{
    public interface IShopUserAcl
    {
        (string name, string mobile) GetUserBy(long id);
    }
}
