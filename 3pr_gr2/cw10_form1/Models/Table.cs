using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw10_form1.Models;

public class Table
{
    [DisplayName("Ilość wierszy")]
    [Required(ErrorMessage = "Musisz podać liczbę")]
    public int? Rows { get; set; } = 10;
    
    [DisplayName("Ilość kolumn")]
    [Required(ErrorMessage = "Musisz podać liczbę")]
    public int? Columns { get; set; } = 10;
}
