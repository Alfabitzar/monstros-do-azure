using System;

namespace Alfabitzar.SampleDb
{
    public class SalesLTCustomer
    {
        internal Guid rowguid;

        public int CustomerID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool NameStyle { get; internal set; }
    }
}