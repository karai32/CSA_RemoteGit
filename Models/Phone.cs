using System.Xml.Linq;

namespace KlientServ.Models
{
    public class Phone
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Firm { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string Camera { get; set; }
        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(Firm)) validationResult.Append($"Firm cannot be empty");
            if (string.IsNullOrWhiteSpace(Model)) validationResult.Append($"Model cannot be empty");
            if (!(0 < Price && Price < 100000)) validationResult.Append($"Price {Price} is out of range (0..100000)");
            if (!string.IsNullOrEmpty(Firm) && !char.IsUpper(Firm.FirstOrDefault())) validationResult.Append($"Firm {Firm} should start from capital letter");
            if (!string.IsNullOrEmpty(Model) && !char.IsUpper(Model.FirstOrDefault())) validationResult.Append($"Model {Model} should start from capital letter");
            return validationResult;
        }

        public override string ToString()
        {
            return $"{Firm} {Model} | {Camera}-{Price}";
        }
    }
}
