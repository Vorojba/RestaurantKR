namespace Restaurant.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderDish = new HashSet<OrderDish>();
        }

        public int ID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OrderTime { get; set; }

        public int? TableNumber { get; set; }

        public int? WaiterID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDish> OrderDish { get; set; }

        public virtual Workers Workers { get; set; }
    }
}
