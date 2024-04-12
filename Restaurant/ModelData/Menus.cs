namespace Restaurant.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menus()
        {
            OrderDish = new HashSet<OrderDish>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? Cost { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        public double? Weight { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(500)]
        public string Ingredients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDish> OrderDish { get; set; }
    }
}
