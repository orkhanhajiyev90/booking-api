namespace BookingApi.Core.Models.Response
{
    public class BaseListResponse<TEntity>
    {
        public string Success { get; set; } = "OK";
        public List<TEntity> Homes { get; set; }

        public BaseListResponse()
        {
        }

        public BaseListResponse(List<TEntity> homes)
        {
            Homes = homes;
        }
    }
}
