namespace FSE.Assignment20.MVC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tweet")]
    public partial class Tweet
    {
        [Key]
        public int TweetId { get; set; }

        [Required]
        [StringLength(25)]
        public string UserId { get; set; }

        [Required]
        [StringLength(140)]
        public string Message { get; set; }

        public DateTime Created { get; set; }

        public virtual Person Person { get; set; }
    }
}
