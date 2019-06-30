namespace FSE.Assignment20.MVC.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Tweets = new HashSet<Tweet>();
            Followers = new HashSet<Person>();
            Following = new HashSet<Person>();
        }

        [Key]
        [StringLength(25)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime Joined { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tweet> Tweets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Following { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Followers { get; set; }
    }
}
