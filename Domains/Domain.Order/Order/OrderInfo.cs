using Ardalis.GuardClauses;
using Domain.Base;

namespace Domain.Order
{
    public class OrderInfo : AggregateRoot
    {
        public IList<OrderDetail> Details { get; protected set; }
        public Address Address { get; protected set; }
        public PersonContact Receiver { get; protected set; }
        public PersonContact Sender  { get; protected set; }

        public OrderInfo(int id)
        {
            Id = id;
        }
        public OrderInfo(int id, IList<OrderDetail> details) : this(id)
        {
            Details = details;
        }
        public void AddDetail(OrderDetail detail)
        {
            if (CheckIfDetailExist(detail))
            {
                throw new ArgumentNullException(nameof(detail));
            }
            Details.Add(detail);
        }
        public void RemoveDetail(OrderDetail detail)
        {
            if (!CheckIfDetailExist(detail))
            {
                throw new ArgumentNullException(nameof(detail));
            }
            Details.Remove(detail);
        }
        public bool CheckIfDetailExist(OrderDetail detail)
        {
            Guard.Against.Null(detail);
            return Details.Any(x => x.Id == detail.Id);
        }
        public bool CheckIfGoodExist(OrderDetail detail)
        {
            Guard.Against.Null(detail);
            return Details.Any(x => x.GoodId == detail.GoodId);
        }
        public void SetSender(PersonContact contact) 
        {
            Guard.Against.Null(contact);
            Sender = contact;
        }
        public void SetReceiver(PersonContact contact) 
        {
            Guard.Against.Null(contact);
            Receiver = contact;
        }

    }

    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public Address() { }

        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
    public class PersonContact : ValueObject
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }

        public PersonContact() { }

        public PersonContact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Phone;

        }
    }
    public class OrderDetail : Entity
    {
        public OrderDetail(int id, int goodId, double price)
        {
            Id = id;
            GoodId = goodId;
            //TODO:优惠折扣计算后的价格？
            Price = price;
        }
        public int GoodId { get; protected set; }
        public double Price { get; protected set; }
    }
}
