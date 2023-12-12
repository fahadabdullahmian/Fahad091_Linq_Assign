using System.ComponentModel.DataAnnotations;

namespace BlazorLinq.Model
{
    public class Faculty
    {
        [Key]
        public int fid { get; set; }
        public string? fname { get; set; }
        public int depid { get; set; }
        public string? standing { get; set; }

        public virtual Enrolled? enroll { get; set; }
        public virtual IList<Class>? classes { get; set; }
    }
}
