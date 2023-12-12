using System.ComponentModel.DataAnnotations;

namespace BlazorLinq.Model
{
    public class Enrolled
    {
        [Key]
        public int eid { get; set; }
        public int cid { get; set; }
        public virtual IList<Student>? students { get; set; }
        public virtual IList<Class>? classes { get; set; }
    }
}
