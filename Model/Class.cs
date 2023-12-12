using System.ComponentModel.DataAnnotations;

namespace BlazorLinq.Model
{
    public class Class
    {
        [Key]
        public int cid { get; set; }
        public string? name { get; set; }
        public int roomNo { get; set; }

        public virtual Faculty? faculty { get; set; }
        public virtual IList<Student>? students { get; set; }
    }
}
