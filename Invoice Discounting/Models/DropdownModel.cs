using System.ComponentModel.DataAnnotations;

namespace Invoice_Discounting.Models
{
    public class DropdownModel
    {
        public int Value { get; set; }
        //[Required]
        public string Text { get; set; }
    }
    public class DropdownTextModel
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
