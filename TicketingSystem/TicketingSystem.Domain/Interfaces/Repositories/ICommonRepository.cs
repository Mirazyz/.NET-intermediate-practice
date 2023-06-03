namespace TicketingSystem.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public ICustomerRepository Customer { get; }
        public IEventRepository Event { get; }
        public IOfferRepository Offer { get; }
        public IPriceRepository Price { get; }
        public IPurchaseRepository Purchase { get; }
        public ISeatRepository Seat { get; }
        public IVenueRepository Venue { get; }

        public Task SaveChangesAsync();
    }
}
