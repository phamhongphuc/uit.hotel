using Realms;

namespace uit.hotel.Models
{
    public partial class Booking : RealmObject
    {
        public long TotalServicesDetails { get; set; }

        public void CalculateServicesDetails()
        {
            long total = 0;
            foreach (var s in ServicesDetails) total += s.Total;
            TotalServicesDetails = total;
        }
    }
}
