using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly TicketingDbContext _context;

        private ICustomerRepository _customer;
        public ICustomerRepository Customer
        {
            get
            {
                _customer ??= new CustomerRepository(_context);
                return _customer;
            }
        }

        private IEventRepository _event;
        public IEventRepository Event
        {
            get
            {
                _event ??= new EventRepository(_context);
                return _event;
            }
        }

        private IOfferRepository _offer;
        public IOfferRepository Offer
        {
            get
            {
                _offer ??= new OfferRepository(_context);
                return _offer;
            }
        }

        private IPriceRepository _price;
        public IPriceRepository Price
        {
            get
            {
                _price ??= new PriceRepository(_context);
                return _price;
            }
        }

        private IPurchaseRepository _purchase;
        public IPurchaseRepository Purchase
        {
            get
            {
                _purchase ??= new PurchaseRepository(_context);
                return _purchase;
            }
        }

        private ISeatRepository _seat;
        public ISeatRepository Seat
        {
            get
            {
                _seat ??= new SeatRepository(_context);
                return _seat;
            }
        }

        private IVenueRepository _venue;
        public IVenueRepository Venue
        {
            get
            {
                _venue ??= new VenueRepository(_context);
                return _venue;
            }
        }

        public CommonRepository(TicketingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _customer = new CustomerRepository(context);
            _event = new EventRepository(context);
            _offer = new OfferRepository(context);
            _price = new PriceRepository(context);
            _purchase = new PurchaseRepository(context);
            _seat = new SeatRepository(context);
            _venue = new VenueRepository(context);

        }
    }
}
