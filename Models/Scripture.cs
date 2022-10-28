using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ScriptureId { get; set; } 
        public string Book { get; set; }
        public string Chapter {get; set;}
        public string Verses {get; set;}
        public string Notes {get;set;}
        
        [DataType(DataType.Date), Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}