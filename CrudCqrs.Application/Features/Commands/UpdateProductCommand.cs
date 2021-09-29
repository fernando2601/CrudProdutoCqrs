using MediatR;



namespace crudcqrs.application.features.commands
{
    public class Updateproductcommand : IRequest<int>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public decimal buyingprice { get; set; }
        public decimal rate { get; set; }
        
    }
}
