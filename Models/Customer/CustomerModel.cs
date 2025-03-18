namespace Susteni.Models.Customer
{

    public class CustomerModel
    {

        public CustomerItem Customer { get; set; }

        public CustomerModel() { 
            Customer = new CustomerItem();        
        }


    }



}
