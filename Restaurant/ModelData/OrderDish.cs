namespace Restaurant.ModelData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDish")]
    public partial class OrderDish
    {
        public int ID { get; set; }

        public int? OrderID { get; set; }

        public int? MenuID { get; set; }

        public int? StageID { get; set; }

        public virtual Menus Menu { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Stages Stages { get; set; }
    }
}
