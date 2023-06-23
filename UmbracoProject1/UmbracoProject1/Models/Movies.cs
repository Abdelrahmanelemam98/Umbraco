using Lucene.Net.Util;
using System.ComponentModel.DataAnnotations;

namespace UmbracoProject1.Models
{

   

	public class Movies
    {
        public int Id  { get; set; }
        [Required,MaxLength(250)]
        public string Title { get; set; }
        public double Rate { get; set; }
        public string Storyline { get; set; }
       
	}
}
