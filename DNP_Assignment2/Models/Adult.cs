using System.ComponentModel.DataAnnotations;

namespace DNP_Assignment2.Models {
public class Adult : Person {
    public Job JobTitle { get; set; }
}
}