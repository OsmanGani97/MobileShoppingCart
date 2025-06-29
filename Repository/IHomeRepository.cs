namespace DMobileSite
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Mobile>> GetMobiles(string sTerm = "", int brandId = 0);
        Task<IEnumerable<Brand>> Brands();
    }
}